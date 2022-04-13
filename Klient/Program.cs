using System;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace Klient
{
    class klient
    {
        //public static string getter = "GET https://www.wp.pl/ HTTP/1.1" + " Host: www.wp.pl";
        public static void Main(string[] args)
        {        
            try
            {
                while (true)
                {
                    String msg = Console.ReadLine();
                    byte[] byData = Encoding.UTF8.GetBytes(msg + "\n");
                    //byte[] byData2 = Encoding.UTF8.GetBytes(getter);
                    byte[] data = new byte[1024];
                    Socket soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPAddress ipAdd = IPAddress.Parse("127.0.0.1");
                    IPEndPoint remoteEP = new IPEndPoint(ipAdd, 2000);
                    soc.Connect(remoteEP);
                    int byteCount = soc.Send(byData);
                   // soc.Send(byData2);
                    Console.WriteLine("Sent {0} bytes", byteCount);
                    soc.Shutdown(SocketShutdown.Send);
                    int bytesRec = soc.Receive(data);
                    if (bytesRec > 0)
                    {
                        Console.WriteLine(Encoding.ASCII.GetString(data, 0, bytesRec));
                    }
                    soc.Shutdown(SocketShutdown.Receive);
                    soc.Close();                 
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Wyjątek!: " + ex);
            }
        }
    }
}
