using ClientProject.Models;
using ServerProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ServerProject.Operations
{
    class SqlOperations
    {     

        public void InsertSquid(List<Squid> data)
        {
            using (var db = new EFContext())
            {
                for(int i = 0; i < data.Count; i++)
                {
                    Logs log = new Logs(data[i].Timestamp, data[i].Elapsed, data[i].ClientIPAddress, data[i].ActionCode, data[i].Size, data[i].Method, data[i].Uri, data[i].Identity, data[i].HierarchyFrom, data[i].MimeType);
                    db.Add(log);
                    Random r = new Random();
                    Console.ForegroundColor = (ConsoleColor)r.Next(0, 16);
                    Console.WriteLine($"Insert row {i};");
                }

                db.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"All items insert in database");
            }
        }
    }
}
