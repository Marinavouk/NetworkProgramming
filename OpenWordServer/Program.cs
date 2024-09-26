using System.Net;
using System.Net.Sockets;
using System.Text;


 using var udpClient = new UdpClient(1100);
 Console.WriteLine("Server set up at port 1100");
 Console.WriteLine("Server ready & awaiting to receive");
 
 while (true)
 {
     try
     {
         string?  phrase = " ";
         List<string> savePhrase = new List<string>();
         
         var remoteEp = new IPEndPoint(IPAddress.Any, 1100); 
         var data = udpClient.Receive(ref remoteEp);
         Console.WriteLine("Message received from " + remoteEp);
         var receiveData = Encoding.UTF8.GetString(data);

         if (receiveData.Length <= 20)
         {
             var typeMessage = Console.ReadLine();
             Console.WriteLine("Numbers of character of received message " + receiveData.Length);
             if (typeMessage != null) savePhrase.Add(typeMessage);
         }
         
         var bytes = System.Text.Encoding.UTF8.GetBytes(receiveData);
         await udpClient.SendAsync(bytes, bytes.Length);
         
     } catch (Exception ex)
     {
         Console.WriteLine($"Error: {ex.Message}");
     }


 }
