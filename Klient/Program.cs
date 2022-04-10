using System;
using System.Text;
using System.Net.Sockets;

namespace Klient
{
    class klient
    {
        public static void Main(string[] args)
        {
            string host = "localhost";
            int port = 2000;
            byte[] buffer;
            try
            {
                TcpClient client = new TcpClient(host,port);
                NetworkStream network = client.GetStream();
                buffer = new byte[client.ReceiveBufferSize];
                int length = network.Read(buffer, 0, client.ReceiveBufferSize);
                String time = Encoding.ASCII.GetString(buffer);
                Console.WriteLine("Na {0} jest:{1}", host, time.Substring(0,length));
            } catch
            {
                Console.WriteLine("Wyjątek!");
            }
        }
    }
}
