using DeanChatClient.Net.IO;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace DeanChatClient.Net
{
    internal class Server
    {
        TcpClient _client;
        public PacketReader PacketReader;

        public event Action connectedEvent;
        public event Action msgReceivedEvent;
        public event Action userDisconnectedEvent;

        public Server()
        {
            _client = new TcpClient();
        }
        public void ConnectToServer(string username)
        {
            if (!_client.Connected)
            {
                _client.Connect("127.0.0.1", 7891);
                PacketReader = new PacketReader(_client.GetStream());
                if (!string.IsNullOrEmpty(username))
                {
                    var connectPackage = new PacketBuilder();
                    connectPackage.WriteOpCode(0);
                    connectPackage.WriteMessage(username);

                    //Send a package to a server
                    _client.Client.Send(connectPackage.GetPacketBytes());
                }

                ReadPackets();

            }
        }

        private void ReadPackets()
        {
            Task.Run(() =>
            {
                while (true)
	            {
                    var opcode = PacketReader.ReadByte();
                    switch (opcode)
                    {
                        case 1:
                            connectedEvent?.Invoke();
                            break;
                        case 5:
                            msgReceivedEvent?.Invoke();
                            break;
                        case 10:
                            userDisconnectedEvent?.Invoke();
                            break;

                        default:
                            Console.WriteLine("ah yes...");
                            break;
                    }

                }
            });
            
            //throw new NotImplementedException();
        }

        public void SendMessageToServer(string message)
        {
            var messagePacket = new PacketBuilder();
            messagePacket.WriteOpCode(5);    // 5 is the opcode to send a message
            messagePacket.WriteMessage(message);
            _client.Client.Send(messagePacket.GetPacketBytes());

        }
    }
}
