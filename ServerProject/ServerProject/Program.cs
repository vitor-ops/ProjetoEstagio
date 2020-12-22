using ClientProject.Models;
using ServerProject.Operations;
using ServerProject.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace ServerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch server = new Stopwatch();
            TcpListener listener = null;
            TcpClient client = null;
            NetworkStream stream = null;
            BinaryReader reader = null;
            List<Squid> squids = new List<Squid>();
            var received = new DataTransfer();

            try
            {
                listener = new TcpListener(new IPAddress(new byte[] { 192, 168, 1, 5 }), 1300);
                listener.Start();
                while (true)

                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("waiting...");
                    using (client = listener.AcceptTcpClient())
                    {
                        server.Start();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("connection request accepted...");
                        using (stream = client.GetStream())
                        {
                            reader = new BinaryReader(stream);                           
                            received = ByteArrayToObject(reader.ReadBytes(6311420));
                            received.Transfer = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) - received.Transfer; 
                            Console.WriteLine(received + " was received...");
                            squids = received.Logs;
                        }
                    }
                    SqlOperations sqlOperations = new SqlOperations();
                    sqlOperations.InsertSquid(squids);
                    server.Stop();
                    received.Server = server.Elapsed;
                    received.Full = server.Elapsed + received.Client + received.Transfer;
                    SendEmail.send(received);
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
            }
        }

        private static DataTransfer ByteArrayToObject(byte[] dataTransfer)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            ms.Write(dataTransfer, 0, dataTransfer.Length);
            ms.Seek(0, SeekOrigin.Begin);
            DataTransfer data = (DataTransfer)bf.Deserialize(ms);

            return data;
        }
    }
}
