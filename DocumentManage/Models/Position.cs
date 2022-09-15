using System;
using System.Collections.Generic;

namespace DocumentManage.Models
{
    public partial class Position
    {
        public Position()
        {
            Profiles = new HashSet<Profile>();
        }

        public int PositionId { get; set; }
        public string? Position1 { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
