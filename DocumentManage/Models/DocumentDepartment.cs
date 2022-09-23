using System;
using System.Collections.Generic;

namespace DocumentManage.Models
{
    public partial class DocumentDepartment
    {
        public int DocumentId { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Document { get; set; } = null!;
        public virtual Document DocumentNavigation { get; set; } = null!;
    }
}
