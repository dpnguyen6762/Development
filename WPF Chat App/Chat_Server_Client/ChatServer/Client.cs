using ChatServer.Net.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    internal class Client
    {
        public string UserName { get; set; }
        public Guid UID { get; set; }
        public TcpClient ClientSocket { get; set; }

        PacketReader _packageReader;
        public Client(TcpClient client)
        {
            ClientSocket = client;

            // Generate a UserId
            UID = Guid.NewGuid();

            _packageReader = new PacketReader(ClientSocket.GetStream());
            var opcode = _packageReader.ReadByte();

            // todo: test if the 1st package opcode = 0,else drop the connection


            UserName = _packageReader.ReadMessage();

            Console.WriteLine($"[{DateTime.Now}]: Client has connected with the username: {UserName}");

            Task.Run(() => Process());


        }
        void Process()
        {
            while (true)
            {
                try
                {
                    var opcode = _packageReader.ReadByte();
                    switch (opcode)
                    {
                        case 5:
                            var msg = _packageReader.ReadMessage();
                            Console.WriteLine($"[{DateTime.Now}] : Message received! {msg}");
                            Program.BroadcastMessage($"[{DateTime.Now}]:[{UserName}]: {msg} ");
                            break;

                        default:
                            break;
                    }

                }
                catch
                {
                    Console.WriteLine($"[{UID.ToString()}]: Disconnected!  ");
                    Program.BroadcastDisconnect(UID.ToString());
                    ClientSocket.Close();
                    //throw;
                }

            }

        }

    }
}
