using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.Net.IO
{
    class PacketReader : BinaryReader
    {
        private NetworkStream _ns;
        public PacketReader(NetworkStream ns): base(ns)
        {
            _ns = ns;
        }

        public string ReadMessage()
        {
            Byte[] msgBuffer;
            var length = ReadInt32();
            msgBuffer = new Byte[length];
            _ns.Read(msgBuffer, 0, length);



            // Reading the payload of the package.
            var msg = Encoding.ASCII.GetString(msgBuffer);
            return msg;
        }

    }
}
