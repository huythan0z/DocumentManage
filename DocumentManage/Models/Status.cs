using System;
using System.Collections.Generic;

namespace DocumentManage.Models
{
    public partial class Status
    {
        public Status()
        {
            Documents = new HashSet<Document>();
        }

        public int Id { get; set; }
        public string? Statuss { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
