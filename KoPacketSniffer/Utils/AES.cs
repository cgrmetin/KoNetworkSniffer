using KoPacketSniffer.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KoPacketSniffer.Utils
{
    public class AES
    {
        private byte[] IvKey;
        private byte[] AesKey;

        public AES(string IvHex, string AesKeyHex)
        {
            this.IvKey = StringToByte(IvHex);
            this.AesKey = StringToByte(AesKeyHex);
        }

        public AesModel Decrypt(string text)
        {
            try
            {
                byte[] bytes = StringToByteArray(text);
                //string decText = DecryptStringFromBytes_Aes(bytes, AesKey, IvKey);
                var decbyte = Decrypt(bytes, AesKey, IvKey);

                string hexString = ByteArrayToString(decbyte);

                AesModel aes = new AesModel();
                aes.bytes = decbyte;
                aes.HexString = hexString;
                aes.Text = Encoding.ASCII.GetString(aes.bytes);
                return aes;
            }
            catch { }
            return null; ;
        }
        public byte[] Decrypt(byte[] data, byte[] key, byte[] iv)
        {
            using (var aes = Aes.Create())
            {
                aes.KeySize = 128;
                aes.BlockSize = 128;
                aes.Padding = PaddingMode.PKCS7;

                aes.Key = key;
                aes.IV = iv;

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    return PerformCryptography(data, decryptor);
                }
            }
        }
        private byte[] PerformCryptography(byte[] data, ICryptoTransform cryptoTransform)
        {
            using (var ms = new MemoryStream())
            using (var cryptoStream = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
            {
                cryptoStream.Write(data, 0, data.Length);
                cryptoStream.FlushFinalBlock();

                return ms.ToArray();
            }
        }

        public byte[] ConvertHexStringToByteArray(string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            }

            byte[] data = new byte[hexString.Length / 2];
            for (int index = 0; index < data.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return data;
        }
        private byte[] StringToByteArrayFastest(string hex)
        {
            if (hex.Length % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");

            byte[] arr = new byte[hex.Length >> 1];

            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            }

            return arr;
        }
        private int GetHexVal(char hex)
        {
            int val = (int)hex;
            //For uppercase A-F letters:
            //return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }

        private byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public byte[] StringToByte(string text)
        {
            var tmpbyte = new byte[text.Length / 2];
            var count = 0;
            for (int i = 0; i < text.Length; i += 2)
            {
                var val = byte.MinValue;
                try
                {
                    if (text.Substring(i, 2) != "XX")
                        val = byte.Parse(text.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);

                    tmpbyte[count] = val;
                    count++;
                }
                catch (Exception)
                {
                }
            }
            return tmpbyte;
        }
        public string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}
