using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Starting up server...");
var listener = new TcpListener(IPAddress.Any, 44444);
listener.Start();

while (true)
{
    Console.WriteLine("Listening for incoming connections on " + listener.LocalEndpoint + "...");
   
    var client = listener.AcceptTcpClient(); // blocking
    Console.WriteLine("Client accepted: " + client.Client.RemoteEndPoint);
   
   // string currentTime = "This is Marina's server, current time is: " + DateTime.Now;
   Console.Write("Your message: ");
   string currentTime = Console.ReadLine();
    byte[] bytes = Encoding.ASCII.GetBytes(currentTime);
  
    client.GetStream().Write(bytes);
    client.Close();
    Console.WriteLine("Closed connection...");
}
