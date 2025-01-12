using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                IPAddress localAddress = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAddress, 7777);

                Console.WriteLine("Server started:");
                server.Start();

                while (true)
                {
                    Console.WriteLine("Server is waiting for a client");
                    TcpClient client = server.AcceptTcpClient();

                    NetworkStream stream = client.GetStream();

                    string response = "Hello from the server";
                    byte[] data = Encoding.UTF8.GetBytes(response);

                    stream.Write(data, 0, data.Length);
                    Console.WriteLine($"Send {response}");

                    stream.Close();
                    client.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
            finally
            {
                if (server != null)
                    server.Stop();
            }
        }
    }
}
