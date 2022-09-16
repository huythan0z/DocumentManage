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

        public int Id { get; set; }
        public string? Positionn { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
