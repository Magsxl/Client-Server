using System;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace Klient
{
    class klient
    {
        public static void Main(string[] args)
        {        
            try
            {
                while (true)
                {
                    Socket soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPAddress ipAdd = IPAddress.Parse("127.0.0.1");
                    IPEndPoint remoteEP = new IPEndPoint(ipAdd, 2000);
                    soc.Connect(remoteEP);
                    String msg = Console.ReadLine();
                    byte[] byData = Encoding.ASCII.GetBytes(msg);
                    int byteCount = soc.Send(byData, 0, byData.Length, SocketFlags.None);
                    byData = new Byte[1024]; // Add receiving message
                    String responseData = String.Empty;
                    byteCount = soc.Receive(byData, 0, byData.Length, SocketFlags.None);
                    if (byteCount > 0)
                    {
                        Console.WriteLine(Encoding.UTF8.GetString(byData, 0, byteCount));
                    }
                    soc.Disconnect(false);
                    soc.Close();
                }
            } catch
            {
                Console.WriteLine("Wyjątek!");
            }
        }
    }
}
