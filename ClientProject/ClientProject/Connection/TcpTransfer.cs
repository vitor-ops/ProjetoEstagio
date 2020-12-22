using ClientProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ClientProject.Connection
{
    public static class TcpTransfer
    {

        public static void Transfer(DataTransfer dataTransfer)
        {
            TcpListener listener = null;
            TcpClient client = null;
            NetworkStream stream = null;
            BinaryWriter writer = null;
            BinaryReader reader = null;

            try
            {
                using (client = new TcpClient("192.168.1.5", 1300))
                {
                    Console.WriteLine("connection was established...");
                    using (stream = client.GetStream())
                    {
                        string received = null;
                        Console.WriteLine("stream was retrieved from the connection...");
                        writer = new BinaryWriter(stream);
                        writer.Write(ObjectToByteArray(dataTransfer));                       
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static byte[] ObjectToByteArray(DataTransfer data)
        {
            if (data == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, data);

            return ms.ToArray();
        }
    }
}
