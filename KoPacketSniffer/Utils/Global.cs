using KoPacketSniffer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoPacketSniffer.Utils
{
    public static class Global
    {

        public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> source, int count)
        {
            var queue = new Queue<T>();
            using (var e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    if (queue.Count == count)
                    {
                        do
                        {
                            yield return queue.Dequeue();
                            queue.Enqueue(e.Current);
                        } while (e.MoveNext());
                    }
                    else
                    {
                        queue.Enqueue(e.Current);
                    }
                }
            }
        }
        public static List<WizPaketType> GetPacketTypes()
        {
            var packetTypes = new List<WizPaketType>();
            packetTypes.Add(new WizPaketType("WIZ_LOGIN", 0x01));
            packetTypes.Add(new WizPaketType("WIZ_NEW_CHAR", 0x02));
            packetTypes.Add(new WizPaketType("WIZ_DEL_CHAR", 0x03));
            packetTypes.Add(new WizPaketType("WIZ_SEL_CHAR", 0x04));
            packetTypes.Add(new WizPaketType("WIZ_SEL_NATION", 0x05));
            packetTypes.Add(new WizPaketType("WIZ_MOVE", 0x06));
            packetTypes.Add(new WizPaketType("WIZ_USER_INOUT", 0x07));
            packetTypes.Add(new WizPaketType("WIZ_ATTACK", 0x08));
            packetTypes.Add(new WizPaketType("WIZ_ROTATE", 0x09));
            packetTypes.Add(new WizPaketType("WIZ_NPC_INOUT", 0x0A));
            packetTypes.Add(new WizPaketType("WIZ_NPC_MOVE", 0x0B));
            packetTypes.Add(new WizPaketType("WIZ_ALLCHAR_INFO_REQ", 0x0C));
            packetTypes.Add(new WizPaketType("WIZ_GAMESTART", 0x0D));
            packetTypes.Add(new WizPaketType("WIZ_MYINFO", 0x0E));
            packetTypes.Add(new WizPaketType("WIZ_LOGOUT", 0x0F));
            packetTypes.Add(new WizPaketType("WIZ_CHAT", 0x10));
            packetTypes.Add(new WizPaketType("WIZ_DEAD", 0x11));
            packetTypes.Add(new WizPaketType("WIZ_REGENE", 0x12));
            packetTypes.Add(new WizPaketType("WIZ_TIME", 0x13));
            packetTypes.Add(new WizPaketType("WIZ_WEATHER", 0x14));
            packetTypes.Add(new WizPaketType("WIZ_REGIONCHANGE", 0x15));
            packetTypes.Add(new WizPaketType("WIZ_REQ_USERIN", 0x16));
            packetTypes.Add(new WizPaketType("WIZ_HP_CHANGE", 0x17));
            packetTypes.Add(new WizPaketType("WIZ_MSP_CHANGE", 0x18));
            packetTypes.Add(new WizPaketType("WIZ_ITEM_LOG", 0x19));
            packetTypes.Add(new WizPaketType("WIZ_EXP_CHANGE", 0x1A));
            packetTypes.Add(new WizPaketType("WIZ_LEVEL_CHANGE", 0x1B));
            packetTypes.Add(new WizPaketType("WIZ_NPC_REGION", 0x1C));
            packetTypes.Add(new WizPaketType("WIZ_REQ_NPCIN", 0x1D));
            packetTypes.Add(new WizPaketType("WIZ_WARP", 0x1E));
            packetTypes.Add(new WizPaketType("WIZ_ITEM_MOVE", 0x1F));
            packetTypes.Add(new WizPaketType("WIZ_NPC_EVENT", 0x20));
            packetTypes.Add(new WizPaketType("WIZ_ITEM_TRADE", 0x21));
            packetTypes.Add(new WizPaketType("WIZ_TARGET_HP", 0x22));
            packetTypes.Add(new WizPaketType("WIZ_ITEM_DROP", 0x23));
            packetTypes.Add(new WizPaketType("WIZ_BUNDLE_OPEN_REQ", 0x24));
            packetTypes.Add(new WizPaketType("WIZ_TRADE_NPC", 0x25));
            packetTypes.Add(new WizPaketType("WIZ_ITEM_GET", 0x26));
            packetTypes.Add(new WizPaketType("WIZ_ZONE_CHANGE", 0x27));
            packetTypes.Add(new WizPaketType("WIZ_POINT_CHANGE", 0x28));
            packetTypes.Add(new WizPaketType("WIZ_STATE_CHANGE", 0x29));
            packetTypes.Add(new WizPaketType("WIZ_LOYALTY_CHANGE", 0x2A));
            packetTypes.Add(new WizPaketType("WIZ_VERSION_CHECK", 0x2B));
            packetTypes.Add(new WizPaketType("WIZ_CRYPTION", 0x2C));
            packetTypes.Add(new WizPaketType("WIZ_USERLOOK_CHANGE", 0x2D));
            packetTypes.Add(new WizPaketType("WIZ_NOTICE", 0x2E));
            packetTypes.Add(new WizPaketType("WIZ_PARTY", 0x2F));
            packetTypes.Add(new WizPaketType("WIZ_EXCHANGE", 0x30));
            packetTypes.Add(new WizPaketType("WIZ_MAGIC_PROCESS", 0x31));
            packetTypes.Add(new WizPaketType("WIZ_SKILLPT_CHANGE", 0x32));
            packetTypes.Add(new WizPaketType("WIZ_OBJECT_EVENT", 0x33));
            packetTypes.Add(new WizPaketType("WIZ_CLASS_CHANGE", 0x34));
            packetTypes.Add(new WizPaketType("WIZ_CHAT_TARGET", 0x35));
            packetTypes.Add(new WizPaketType("WIZ_CONCURRENTUSER", 0x36));
            packetTypes.Add(new WizPaketType("WIZ_DATASAVE", 0x37));
            packetTypes.Add(new WizPaketType("WIZ_DURATION", 0x38));
            packetTypes.Add(new WizPaketType("WIZ_TIMENOTIFY", 0x39));
            packetTypes.Add(new WizPaketType("WIZ_REPAIR_NPC", 0x3A));
            packetTypes.Add(new WizPaketType("WIZ_ITEM_REPAIR", 0x3B));
            packetTypes.Add(new WizPaketType("WIZ_KNIGHTS_PROCESS", 0x3C));
            packetTypes.Add(new WizPaketType("WIZ_ITEM_COUNT_CHANGE", 0));
            packetTypes.Add(new WizPaketType("WIZ_KNIGHTS_LIST", 0x3E));
            packetTypes.Add(new WizPaketType("WIZ_ITEM_REMOVE", 0x3F));
            packetTypes.Add(new WizPaketType("WIZ_OPERATOR", 0x40));
            packetTypes.Add(new WizPaketType("WIZ_SPEEDHACK_CHECK", 0x41));
            packetTypes.Add(new WizPaketType("WIZ_COMPRESS_PACKET", 0x42));
            packetTypes.Add(new WizPaketType("WIZ_SERVER_CHECK", 0x43));
            packetTypes.Add(new WizPaketType("WIZ_CONTINOUS_PACKET", 0x44));
            packetTypes.Add(new WizPaketType("WIZ_WAREHOUSE", 0x45));
            packetTypes.Add(new WizPaketType("WIZ_SERVER_CHANGE", 0x46));
            packetTypes.Add(new WizPaketType("WIZ_REPORT_BUG", 0x47));
            packetTypes.Add(new WizPaketType("WIZ_HOME", 0x48));
            packetTypes.Add(new WizPaketType("WIZ_FRIEND_PROCESS", 0x49));
            packetTypes.Add(new WizPaketType("WIZ_GOLD_CHANGE", 0x4A));
            packetTypes.Add(new WizPaketType("WIZ_WARP_LIST", 0x4B));
            packetTypes.Add(new WizPaketType("WIZ_VIRTUAL_SERVER", 0x4C));
            packetTypes.Add(new WizPaketType("WIZ_ZONE_CONCURRENT", 0x4D));
            packetTypes.Add(new WizPaketType("WIZ_CORPSE", 0x4e));
            packetTypes.Add(new WizPaketType("WIZ_PARTY_BBS", 0x4f));
            packetTypes.Add(new WizPaketType("WIZ_MARKET_BBS", 0x50));
            packetTypes.Add(new WizPaketType("WIZ_KICKOUT", 0x51));
            packetTypes.Add(new WizPaketType("WIZ_CLIENT_EVENT", 0x52));
            packetTypes.Add(new WizPaketType("WIZ_MAP_EVENT", 0x53));
            packetTypes.Add(new WizPaketType("WIZ_WEIGHT_CHANGE", 0x54));
            packetTypes.Add(new WizPaketType("WIZ_SELECT_MSG", 0x55));
            packetTypes.Add(new WizPaketType("WIZ_NPC_SAY", 0x56));
            packetTypes.Add(new WizPaketType("WIZ_BATTLE_EVENT", 0x57));
            packetTypes.Add(new WizPaketType("WIZ_AUTHORITY_CHANGE", 0x58));
            packetTypes.Add(new WizPaketType("WIZ_EDIT_BOX", 0x59));
            packetTypes.Add(new WizPaketType("WIZ_SANTA", 0x5A));
            packetTypes.Add(new WizPaketType("WIZ_ITEM_UPGRADE", 0x5B));
            packetTypes.Add(new WizPaketType("WIZ_PACKET1", 0x5C));
            packetTypes.Add(new WizPaketType("WIZ_PACKET2", 0x5D));
            packetTypes.Add(new WizPaketType("WIZ_ZONEABILITY", 0x5E));
            packetTypes.Add(new WizPaketType("WIZ_EVENT", 0x5F));
            packetTypes.Add(new WizPaketType("WIZ_STEALTH", 0x60));
            packetTypes.Add(new WizPaketType("WIZ_ROOM_PACKETPROCESS", 0x6));
            packetTypes.Add(new WizPaketType("WIZ_ROOM", 0x62));
            packetTypes.Add(new WizPaketType("WIZ_PACKET3", 0x63));
            packetTypes.Add(new WizPaketType("WIZ_QUEST", 0x64));
            packetTypes.Add(new WizPaketType("WIZ_PACKET4", 0x65));
            packetTypes.Add(new WizPaketType("WIZ_KISS", 0x66));
            packetTypes.Add(new WizPaketType("WIZ_RECOMMEND_USER", 0x67));
            packetTypes.Add(new WizPaketType("WIZ_MERCHANT", 0x68));
            packetTypes.Add(new WizPaketType("WIZ_MERCHANT_INOUT", 0x69));
            packetTypes.Add(new WizPaketType("WIZ_SHOPPING_MALL", 0x6A));
            packetTypes.Add(new WizPaketType("WIZ_SERVER_INDEX", 0x6B));
            packetTypes.Add(new WizPaketType("WIZ_EFFECT", 0x6C));
            packetTypes.Add(new WizPaketType("WIZ_SIEGE", 0x6D));
            packetTypes.Add(new WizPaketType("WIZ_NAME_CHANGE", 0x6E));
            packetTypes.Add(new WizPaketType("WIZ_WEBPAGE", 0x6F));
            packetTypes.Add(new WizPaketType("WIZ_CAPE", 0x70));
            packetTypes.Add(new WizPaketType("WIZ_PREMIUM", 0x71));
            packetTypes.Add(new WizPaketType("WIZ_HACKTOOL", 0x72));
            packetTypes.Add(new WizPaketType("WIZ_RENTAL", 0x73));
            packetTypes.Add(new WizPaketType("WIZ_PACKET5", 0x74));
            packetTypes.Add(new WizPaketType("WIZ_CHALLENGE", 0x75));
            packetTypes.Add(new WizPaketType("WIZ_PET", 0x76));
            packetTypes.Add(new WizPaketType("WIZ_CHINA", 0x77));
            packetTypes.Add(new WizPaketType("WIZ_KING", 0x78));
            packetTypes.Add(new WizPaketType("WIZ_SKILLDATA", 0x79));
            packetTypes.Add(new WizPaketType("WIZ_PROGRAMCHECK", 0x7A));
            packetTypes.Add(new WizPaketType("WIZ_BIFROST", 0x7B));
            packetTypes.Add(new WizPaketType("WIZ_REPORT", 0x7C));
            packetTypes.Add(new WizPaketType("WIZ_LOGOSSHOUT", 0x7D));
            packetTypes.Add(new WizPaketType("WIZ_PACKET6", 0x7E));
            packetTypes.Add(new WizPaketType("WIZ_PACKET7", 0x7F));
            packetTypes.Add(new WizPaketType("WIZ_RANK", 0x80));
            packetTypes.Add(new WizPaketType("WIZ_STORY", 0x81));
            packetTypes.Add(new WizPaketType("WIZ_PACKET8", 0x82));
            packetTypes.Add(new WizPaketType("WIZ_PACKET9", 0x83));
            packetTypes.Add(new WizPaketType("WIZ_PACKET10", 0x84));
            packetTypes.Add(new WizPaketType("WIZ_PACKET11", 0x85));
            packetTypes.Add(new WizPaketType("WIZ_MINING", 0x86));
            packetTypes.Add(new WizPaketType("WIZ_HELMET", 0x87));
            packetTypes.Add(new WizPaketType("WIZ_PVP", 0x88));
            packetTypes.Add(new WizPaketType("WIZ_CHANGE_HAIR", 0x89));
            packetTypes.Add(new WizPaketType("WIZ_PACKET12", 0x8A));
            packetTypes.Add(new WizPaketType("WIZ_PACKET13", 0x8B));
            packetTypes.Add(new WizPaketType("WIZ_PACKET14", 0x8C));
            packetTypes.Add(new WizPaketType("WIZ_PACKET15", 0x8D));
            packetTypes.Add(new WizPaketType("WIZ_PACKET16", 0x8E));
            packetTypes.Add(new WizPaketType("WIZ_PACKET17", 0x8F));
            packetTypes.Add(new WizPaketType("WIZ_DEATH_LIST", 0x90));
            packetTypes.Add(new WizPaketType("WIZ_CLANPOINTS_BATTLE", 0x91));
            packetTypes.Add(new WizPaketType("_____XINCODE_____", 0xA0));


            return packetTypes;
        }
    }
}
