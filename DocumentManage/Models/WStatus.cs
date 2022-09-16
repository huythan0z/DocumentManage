using System;
using System.Collections.Generic;

namespace DocumentManage.Models
{
    public partial class WStatus
    {
        public WStatus()
        {
            Profiles = new HashSet<Profile>();
        }

        public int Id { get; set; }
        public string? WStatuss { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
