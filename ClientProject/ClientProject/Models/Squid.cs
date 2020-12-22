using System;
using System.Collections.Generic;
using System.Text;

namespace ClientProject.Models
{
    [Serializable()]
    public class Squid
    {
        public string Timestamp { get; set; }
        public int Elapsed { get; set; }
        public string ClientIPAddress { get; set; }
        public string ActionCode { get; set; }
        public int Size { get; set; }
        public string Method { get; set; }
        public string Uri { get; set; }
        public string Identity { get; set; }
        public string HierarchyFrom { get; set; }
        public string MimeType { get; set; }

        public static Squid ParseRow(string row)
        {
            var fields = row.Split(new[] { "|", " " }, StringSplitOptions.None);

            return new Squid
            {
                Timestamp = fields[0],
                Elapsed = int.Parse(fields[1]),
                ClientIPAddress = fields[2],
                ActionCode = fields[3],
                Size = int.Parse(fields[4]),
                Method = fields[5],
                Uri = fields[6],
                Identity = fields[7],
                HierarchyFrom = fields[8],
                MimeType = fields[9]
            };
        }
    }    
}
