using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Starting Up the server...");
var listener = new TcpListener(IPAddress.Any, 44444);
listener.Start();
Console.WriteLine("Listening for incoming connections on" + listener.LocalEndpoint + "...");
var client = listener.AcceptTcpClient();
Console.WriteLine("Server accepted: " + client.Client.RemoteEndPoint);
string currentTime = "Tuesday, today!";

byte[] bytes = Encoding.ASCII.GetBytes(currentTime);

client.GetStream().Write(bytes);
client.Close();

