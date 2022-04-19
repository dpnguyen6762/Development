using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeanChatClient.Net.IO
{
    class PacketBuilder
    {
        //Append the data from the client in the bytes form 
        //to the server

        MemoryStream _ms;
        public PacketBuilder()
        {
            _ms = new MemoryStream();

        }

        // Write an op code to the package as a flag for the server to interpret the package in different ways
        public void WriteOpCode(byte opcode)
        {
            _ms.WriteByte(opcode);
        }

        public void WriteMessage(string msg)
        {
            var msgLength = msg.Length;
            _ms.Write(BitConverter.GetBytes(msg.Length));    // 4 bytes
            _ms.Write(Encoding.ASCII.GetBytes(msg));
        }

        //Get the memory of the actual bytes
        public byte[] GetPacketBytes()
        {
            return _ms.ToArray();
        }

    }
}
