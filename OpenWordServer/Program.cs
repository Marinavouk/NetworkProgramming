// See https://aka.ms/new-console-template for more information

using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new UdpClient(44446);

var sentence = string.Empty;
while (true)
{
    IPEndPoint remoteEp = new IPEndPoint(IPAddress.Any, 0);
    var bytes = client.Receive(ref remoteEp);

    Console.WriteLine("Received bytes from: " + remoteEp);
    var word = Encoding.UTF8.GetString(bytes);
    Console.WriteLine("The word is: " + word);
    sentence += " " + word.Trim();
    bytes = Encoding.UTF8.GetBytes(sentence);
    client.Send(bytes, bytes.Length, remoteEp);
}