using ClientProject.Connection;
using ClientProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ClientProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientTime = new Stopwatch();            
            clientTime.Start();
            var path = @"D:\Dowloads\access.log";
            var parse = new Stopwatch();
            List<Squid> squids = new List<Squid>();

            if (File.Exists(path))
            {
                var file = new FileInfo(path);
                using (var streamReader = file.OpenText())
                {
                    string row;
                    parse.Start();
                    while ((row = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine($"Lista: item[{squids.Count}]");
                        row = row
                            .Replace("      ", " ")
                            .Replace("     ", " ")
                            .Replace("    ", " ")
                            .Replace("   ", " ")
                            .Replace("  ", " ")
                            .Replace(" ", "|")
                            .Replace(" - ", "|");
                        squids.Add(Squid.ParseRow(row));
                    }
                    parse.Stop();
                }
            }
            clientTime.Stop();
            TimeSpan now = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            DataTransfer data = new DataTransfer(squids, squids.Count, clientTime.Elapsed, parse.Elapsed , now, now, now);
            TcpTransfer.Transfer(data);
        }
    }
}
