using System;
using System.Collections.Generic;

namespace DocumentManage.Models
{
    public partial class Request
    {
        //public int Id { get; set; }
        public int? DocumentId { get; set; }
        public int? ProfileId { get; set; }
        //public DateTime? Deadline { get; set; }
        //public string? Note { get; set; }
        //public int? StatusId { get; set; }

        //public virtual Document? Document { get; set; }
        //public virtual Profile? Profile { get; set; }
        //public virtual Status? Status { get; set; }
    }
}
