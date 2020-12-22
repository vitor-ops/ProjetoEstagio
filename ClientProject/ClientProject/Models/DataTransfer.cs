using System;
using System.Collections.Generic;
using System.Text;

namespace ClientProject.Models
{
    [Serializable()]
    public class DataTransfer
    {
        public DataTransfer()
        {
        }

        public DataTransfer(List<Squid> logs, int registros, TimeSpan client, TimeSpan parse, TimeSpan transfer, TimeSpan server, TimeSpan full)
        {
            Logs = logs;
            Registros = registros;
            Client = client;
            Parse = parse;
            Transfer = transfer;
            Server = server;
            Full = full;
        }

        public List<Squid> Logs { get; set; }
        public int Registros { get; set; }
        public TimeSpan Client { get; set; }
        public TimeSpan Parse { get; set; }
        public TimeSpan Transfer { get; set; }
        public TimeSpan? Server { get; set; }
        public TimeSpan? Full { get; set; }
    }
}
