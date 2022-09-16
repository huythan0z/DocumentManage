using System;
using System.Collections.Generic;

namespace DocumentManage.Models
{
    public partial class Type
    {
        public Type()
        {
            Documents = new HashSet<Document>();
        }

        public int Id { get; set; }
        public string? DocumentType { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
