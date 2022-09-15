using System;
using System.Collections.Generic;

namespace DocumentManage.Models
{
    public partial class Status
    {
        public Status()
        {
            Requests = new HashSet<Request>();
        }

        public int StatusId { get; set; }
        public string? Statuss { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
