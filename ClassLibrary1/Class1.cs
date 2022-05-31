using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PacketClass
{
    public class Class1
    {
    }

    public enum PacketType
    {
        Init = 0,
        Explorer,
        DetailAndDownload
    }

    public enum PacketSendERROR
    {
        normal = 0,
        error
    }

    [Serializable]
    public class Packet
    {
        public int Length;
        public int Type;

        public Packet()
        {
            this.Length = 0;
            this.Type = 0;
        }

        public static byte[] Serialize(Object o)
        {
            MemoryStream memoryS = new MemoryStream(1024 * 4);
            BinaryFormatter binaryF = new BinaryFormatter();
            binaryF.Serialize(memoryS, o);
            return memoryS.ToArray();
        }

        public static Object Desserialize(byte[] bt)
        {
            MemoryStream memoryS = new MemoryStream(1024 * 4);
            foreach (byte b in bt)
                memoryS.WriteByte(b);

            memoryS.Position = 0;
            BinaryFormatter bf = new BinaryFormatter();
            Object obj = bf.Deserialize(memoryS);
            memoryS.Close();
            return obj;
        }
    }

    [Serializable]
    public class Initialize : Packet // 초기화 데이터
    {
        public string buffer = null;
    }

    [Serializable]
    public class Browser : Packet // 원격 탐색기 요청
    {
        public string message = null;
        public DirectoryInfo[] di;
        public string fullpath = null;
        public int num = 0; // 1 : beforeExpand, 2 : beforeSelect
        public FileInfo[] fi;
    }

    [Serializable]
    public class Detail : Packet
    {
        public string message = null;
    }
}