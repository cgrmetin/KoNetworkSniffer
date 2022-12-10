using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KoPacketSniffer.Model.Enum;

namespace KoPacketSniffer.Model
{
    public class Paket
    {
        public PaketType Type { get; set; }
        public CryptionType CryptionType { get; set; }
        public string BasePacket { get; set; }
        public int Len { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Trimmed { get; set; }
        public string Text { get; set; }
        public byte[] bytes { get; set; }
        public AesModel Decrypted { get; set; }
        public DateTime time { get; set; }
        public WizPaketType WizPaketType { get; set; }
    }

    public class WizPaketType
    {
        public byte _byte { get; set; }
        public string Name { get; set; }

        public WizPaketType(string name, byte @byte)
        {
            _byte = @byte;
            Name = name;
        }
    }
}
