using System;
using System.Collections.Generic;

namespace DocumentManage.Models
{
    public partial class Profile
    {
        public Profile()
        {
            Documents = new HashSet<Document>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? PositionId { get; set; }
        public int? WStatusId { get; set; }

        public virtual Position? Position { get; set; }
        public virtual WStatus? WStatus { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
