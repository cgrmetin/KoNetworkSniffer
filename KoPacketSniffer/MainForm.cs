using KoPacketSniffer.Model;
using KoPacketSniffer.Utils;
using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static KoPacketSniffer.Model.Enum;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KoPacketSniffer
{
    public partial class MainForm : Form
    {
        private LibPcapLiveDevice libCapDevice;
        private Thread sniffing;
        private string _deviceAddress;

        private string clientKey;
        private string clientKeyHex;
        private string IvHex = "324EAA58BCB3AEE36BC74C56364734F2";
        private string PrivateHex = "871FE52378A188AD22CF5EAA5B181E67";

        private List<WizPaketType> WizPaketTypes = Global.GetPacketTypes();

        private AES ServerSide;
        private AES ClientSide;

        public MainForm()
        {
            InitializeComponent();

            gelenListView.View = View.Details;
            gelenListView.GridLines = true;
            gelenListView.FullRowSelect = true;
            gelenListView.AllowColumnReorder = true;
            gelenListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            gelenListView.Columns.Add("Time",100);
            gelenListView.Columns.Add("WIZ",100);
            gelenListView.Columns.Add("Cryption", 100);
            gelenListView.Columns.Add("Length",50);
            gelenListView.Columns.Add("Data", 300);
            gelenListView.Columns.Add("String",300);

            gidenListView.View = View.Details;
            gidenListView.GridLines = true;
            gidenListView.FullRowSelect = true;
            gidenListView.AllowColumnReorder = true;
            gidenListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            gidenListView.Columns.Add("Time", 100);
            gidenListView.Columns.Add("WIZ", 100);
            gidenListView.Columns.Add("Cryption", 100);
            gidenListView.Columns.Add("Length", 50);
            gidenListView.Columns.Add("Data", 300);
            gidenListView.Columns.Add("String", 300);


            gidenGroupBox.Width = this.Width / 2;

            ServerSide = new AES(IvHex, PrivateHex);
            
            LibPcapLiveDeviceList devices = LibPcapLiveDeviceList.Instance;
            foreach (var dev in devices)
            {
                devicesComboBox.Items.Add(dev.Interface.Description);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            gidenGroupBox.Width = this.Width / 2;
        }

        private void startListeningToolStripButton_Click(object sender, EventArgs e)
        {
            LibPcapLiveDeviceList devices = LibPcapLiveDeviceList.Instance;

            libCapDevice = devices.FirstOrDefault(p => p.Interface.Description == devicesComboBox.SelectedItem.ToString());
            _deviceAddress = libCapDevice.Addresses[0].Addr.ipAddress.ToString();

            libCapDevice.OnPacketArrival += new PacketArrivalEventHandler(Device_OnPacketArrival);

            sniffing = new Thread(new ThreadStart(SniffingProcess));
            sniffing.Start();
        }

        private void SniffingProcess()
        {
            int timeOutMS = 1000;
            libCapDevice.Open(DeviceMode.Promiscuous, timeOutMS);

            if (libCapDevice.Opened)
            {
                libCapDevice.Filter = "tcp portrange 15100-15109 || port 15001";
            }
            libCapDevice.Capture();
        }

        public void Device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            var packet = PacketDotNet.Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
            var ipPacket = (IpPacket)packet.Extract(typeof(IpPacket));

            byte[] data = ipPacket.Bytes.Skip(ipPacket.Header.Length * 2).ToArray();
            string dataStr = ByteArrayToString(data);

            Paket paket = new Paket();

            paket.time = DateTime.Now;
            paket.Source = ipPacket.SourceAddress.ToString();
            paket.Destination = ipPacket.DestinationAddress.ToString();

            paket.bytes = data;
            paket.BasePacket = dataStr;

            if (paket.Source == _deviceAddress)
            {
                paket.Type = PaketType.Giden;
            }
            else
            {
                paket.Type = PaketType.Gelen;
            }


            if (data.Length > 0)
            {
                byte[] temp = data.Skip(2).ToArray();
                temp = temp.SkipLast(2).ToArray();
                paket.bytes = temp;
                paket.Trimmed = ByteArrayToString(temp);
                paket.Text = Encoding.UTF8.GetString(temp);
            }

            if (paket.Type == PaketType.Gelen && data.Length > 3 && data[2] == 0x16 && data[3] == 0x00 && data[4] == 0x2b)
            {
                paket.bytes = paket.bytes.Skip(7).ToArray();
                paket.bytes = paket.bytes.SkipLast(1).ToArray();


                paket.Trimmed = ByteArrayToString(paket.bytes);
                paket.Text = Encoding.ASCII.GetString(paket.bytes);

                clientKey = paket.Text;
                clientKeyHex = paket.Trimmed;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(clientKey);
                Console.WriteLine(clientKeyHex);

                ClientSide = new AES(IvHex, clientKeyHex);
            }

            if (paket.bytes != null && paket.bytes.Length > 2)
            {
                if (paket.bytes[2] == 0x01 && !String.IsNullOrEmpty(clientKey))
                {
                    paket.CryptionType = CryptionType.Client;
                    paket.bytes = paket.bytes.Skip(3).ToArray();
                    paket.Trimmed = ByteArrayToString(paket.bytes);
                    var dec = ClientSide.Decrypt(paket.Trimmed);
                    if (dec != null)
                    {
                        paket.Decrypted = dec;
                    }
                }
                else if (paket.bytes[2] == 0x02)
                {
                    paket.CryptionType = CryptionType.Server;
                    paket.bytes = paket.bytes.Skip(3).ToArray();
                    paket.Trimmed = ByteArrayToString(paket.bytes);
                    var dec = ServerSide.Decrypt(paket.Trimmed);
                    if (dec != null)
                    {
                        paket.Decrypted = dec;
                    }
                }
                else
                {
                    paket.CryptionType = CryptionType.UnKnown;
                }

                if (paket.Type == PaketType.Gelen && paket.CryptionType != CryptionType.UnKnown && paket.Decrypted != null)
                {
                    paket.WizPaketType = WizPaketTypes.FirstOrDefault(p => p._byte == paket.Decrypted.bytes[0]);
                }
                if (paket.Type == PaketType.Giden && paket.CryptionType != CryptionType.UnKnown && paket.Decrypted != null)
                {
                    paket.WizPaketType = WizPaketTypes.FirstOrDefault(p => p._byte == paket.Decrypted.bytes[1]);
                }
            }

            AddToList(paket);
        }

        private string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        private void stopListeningToolStripButton_Click(object sender, EventArgs e)
        {
            sniffing.Abort();
            libCapDevice.StopCapture();
            libCapDevice.Close();
        }

        private void AddToList(Paket paket)
        {
            if (paket.bytes.Length == 0)
                return;

            if (paket.Type==PaketType.Gelen)
            {
                if(paket.Decrypted != null)
                {
                    ListViewItem item = new ListViewItem(paket.time.ToString("dd/MM/yyyy HH:mm:ss"));

                    if (paket.WizPaketType != null)
                        item.SubItems.Add(paket.WizPaketType.Name);
                    else
                        item.SubItems.Add("UnKnown WIZ");

                    item.SubItems.Add("Decrypted");
                    item.SubItems.Add(paket.Decrypted.bytes.Length.ToString());
                    item.SubItems.Add(paket.Decrypted.HexString);
                    item.SubItems.Add(paket.Decrypted.Text);

                    Action action1 = () => gelenListView.Items.Add(item);
                    gelenListView.Invoke(action1);



                }
                else
                {
                    ListViewItem item = new ListViewItem(paket.time.ToString("dd/MM/yyyy HH:mm:ss"));
                    item.SubItems.Remove(item.SubItems[0]);

                    if (paket.WizPaketType != null)
                        item.SubItems.Add(paket.WizPaketType.Name);
                    else
                        item.SubItems.Add("UnKnown WIZ");

                    item.SubItems.Add("Crypted");
                    item.SubItems.Add(paket.bytes.Length.ToString());
                    item.SubItems.Add(paket.Trimmed);
                    item.SubItems.Add(paket.Text);

                    Action action1 = () => gelenListView.Items.Add(item);
                    gelenListView.Invoke(action1);
                }    
            }
            else
            {
                if (paket.Decrypted != null)
                {
                    ListViewItem item = new ListViewItem(paket.time.ToString("dd/MM/yyyy HH:mm:ss"));
                    item.SubItems.Remove(item.SubItems[0]);

                    if (paket.WizPaketType != null)
                        item.SubItems.Add(paket.WizPaketType.Name);
                    else
                        item.SubItems.Add("UnKnown WIZ");

                    item.SubItems.Add("Decrypted");
                    item.SubItems.Add(paket.Decrypted.bytes.Length.ToString());
                    item.SubItems.Add(paket.Decrypted.HexString);
                    item.SubItems.Add(paket.Decrypted.Text);

                    Action action1 = () => gidenListView.Items.Add(item);
                    gidenListView.Invoke(action1);

                }
                else
                {
                    ListViewItem item = new ListViewItem(paket.time.ToString("dd/MM/yyyy HH:mm:ss"));
                    item.SubItems.Remove(item.SubItems[0]);

                    if (paket.WizPaketType != null)
                        item.SubItems.Add(paket.WizPaketType.Name);
                    else
                        item.SubItems.Add("UnKnown WIZ");

                    item.SubItems.Add("Crypted");
                    item.SubItems.Add(paket.bytes.Length.ToString());
                    item.SubItems.Add(paket.Trimmed);
                    item.SubItems.Add(paket.Text);

                    Action action1 = () => gidenListView.Items.Add(item);
                    gidenListView.Invoke(action1);

                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(sniffing.ThreadState != ThreadState.Aborted)
            {
                sniffing.Abort();
                libCapDevice.StopCapture();
                libCapDevice.Close();
            }
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            gelenListView.Items.Clear();
            gidenListView.Items.Clear();
        }
    }
}
