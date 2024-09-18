using System;
using System.IO;
using System.Net.Sockets;



Console.WriteLine("Client");


bool keepSending = true;


//If no server is responding an exception is thrown
TcpClient socket = new TcpClient("127.0.0.1", 7);

//Gets the stream object from the socket. The stream object is able to recieve and send data
NetworkStream ns = socket.GetStream();
//The StreamReader is an easier way to read data from a Stream, it uses the NetworkStream
StreamReader reader = new StreamReader(ns);
//The StreamWriter is an easier way to write data to a Stream, it uses the NetworkStream
StreamWriter writer = new StreamWriter(ns);

while (keepSending)
{
    //Read message from the console up until the user presses enter (a line break)
    //This function is blocking, meaning it will not execute any more code until the line break occurs
    string message = Console.ReadLine();

    writer.WriteLine(message);
   
    writer.Flush();

    
    string response = reader.ReadLine();

   
    Console.WriteLine(response);

    if (message.ToLower() == "close")
    {
        keepSending = false;
    }
}

//closes the connection, as it can only send one message before the server closes the connection
socket.Close();

