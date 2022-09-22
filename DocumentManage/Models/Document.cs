using System;
using System.Collections.Generic;

namespace DocumentManage.Models
{
    public partial class Document
    {
        public Document()
        {
            Departments = new HashSet<Department>();
            Profiles = new HashSet<Profile>();
        }

        public int Id { get; set; }
        public string? Address { get; set; }
        public string? Signer { get; set; }
        public DateTime? SignDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? Note { get; set; }
        public string? DocumentFile { get; set; }
        public string? Receiver { get; set; }
        public string? Sender { get; set; }
        public int? TypeId { get; set; }
        public int? UrgencyId { get; set; }
        public int? StatusId { get; set; }

        public virtual Status? Status { get; set; }
        public virtual Type? Type { get; set; }
        public virtual Urgency? Urgency { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
