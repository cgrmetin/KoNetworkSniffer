using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoPacketSniffer.Model
{
    public static class Enum
    {
        public enum PaketType
        {
            Gelen,
            Giden
        }
        public enum CryptionType
        {
            Client,
            Server,
            UnKnown
        }
    }
}
