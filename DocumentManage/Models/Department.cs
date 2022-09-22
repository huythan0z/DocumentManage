using System;
using System.Collections.Generic;

namespace DocumentManage.Models
{
    public partial class Department
    {
        public Department()
        {
            Profiles = new HashSet<Profile>();
            Documents = new HashSet<Document>();
        }

        public int Id { get; set; }
        public string? DepartmentName { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
