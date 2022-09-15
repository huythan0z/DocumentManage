using System;
using System.Collections.Generic;

namespace DocumentManage.Models
{
    public partial class Urgency
    {
        public Urgency()
        {
            Documents = new HashSet<Document>();
        }

        public int UrgencyId { get; set; }
        public string? Urgency1 { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
