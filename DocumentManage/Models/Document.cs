using System;
using System.Collections.Generic;

namespace DocumentManage.Models
{
    public partial class Document
    {
        public Document()
        {
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string? Sender { get; set; }
        public string? DateSend { get; set; }
        public string? Receiver { get; set; }
        public string? Note { get; set; }
        public string? DocumentFile { get; set; }
        public int? TypeId { get; set; }
        public int? UrgencyId { get; set; }

        public virtual Type? Type { get; set; }
        public virtual Urgency? Urgency { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
