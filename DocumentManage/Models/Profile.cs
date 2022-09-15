﻿using System;
using System.Collections.Generic;

namespace DocumentManage.Models
{
    public partial class Profile
    {
        public Profile()
        {
            Requests = new HashSet<Request>();
        }

        public int ProfileId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? PositionId { get; set; }
        public int? WStatusId { get; set; }

        public virtual Position? Position { get; set; }
        public virtual WStatus? WStatus { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}