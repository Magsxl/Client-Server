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
                    soc.Send(byData);
                    
                    /* byte[] buffer = new byte[1024];
                    int iRx = soc.Receive(buffer);
                    char[] chars = new char[iRx];

                    Decoder d = Encoding.UTF8.GetDecoder();
                    int charLen = d.GetChars(buffer, 0, iRx, chars, 0);
                    String recv = new String(chars); */

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
