using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServerProject.Models
{
    public class Logs
    {
        public Logs(string timestamp, int elapsed, string clientIPAddress, string actionCode, int size, string method, string uri, string identity, string hierarchyFrom, string mimeType)
        {
            Timestamp = timestamp;
            Elapsed = elapsed;
            ClientIPAddress = clientIPAddress;
            ActionCode = actionCode;
            Size = size;
            Method = method;
            Uri = uri;
            Identity = identity;
            HierarchyFrom = hierarchyFrom;
            MimeType = mimeType;
        }

        [Key]
        public int Id { get; set; }
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
    }
}
