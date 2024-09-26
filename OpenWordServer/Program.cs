using System.Net;
using System.Net.Sockets;
using System.Text;


 using var udpClient = new UdpClient(0);
 var remoteEp = new IPEndPoint(IPAddress.Any, 1100); 
 Console.WriteLine("Server set up at port " + remoteEp);
 
 while (true)
 {
     try
     {
         string?  phrase = " ";
         List<string> savePhrase = new List<string>();
         
         var data = udpClient.Receive(ref remoteEp);
         Console.WriteLine("Server ready & awaiting to receive");
         var receiveData = Encoding.UTF8.GetString(data);

         if (receiveData.Length <= 20)
         {
             var typeMessage = Console.ReadLine();
             Console.WriteLine("Numbers of character of received message " + receiveData.Length);
             if (typeMessage != null) savePhrase.Add(typeMessage);
         }
         
         
     } catch (Exception ex)
     {
         Console.WriteLine($"Error: {ex.Message}");
     }


 }
