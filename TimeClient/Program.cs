
using System.Net.Sockets;
using System.Text;


using var client = new TcpClient("127.0.0.1", 44444);
using var reader = new StreamReader(client.GetStream());
Console.WriteLine(reader.ReadToEnd());
/*
  Console.WriteLine("Connecting to the server...");
    var client = new TcpClient();
    client.Connect("192.168.1.57", 44444);
    //client.Connect("127.0.0.1", 44444);
    Console.WriteLine("Server accepted" + client.Client.RemoteEndPoint);

    var buffer = new byte[1000];
    var bytesRecieved = client.GetStream().Read(buffer, 0, buffer.Length);

    var currentTime = Encoding.ASCII.GetString(buffer);
    Console.WriteLine(currentTime);
*/