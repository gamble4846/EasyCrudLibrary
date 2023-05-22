using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [Table("ctbRolePagePermission")]
    public class CtbRolePagePermissionModel
    {
        public int Id { get; set; }
        public Guid GUIDRole { get; set; }
        public int PageId { get; set; }
        public bool Allow { get; set; }
    }
}
