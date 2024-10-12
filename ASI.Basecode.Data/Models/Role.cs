using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Type of role is required!")]
        public string RoleType { get; set; }

        [Required(ErrorMessage = "Role description is required!")]
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
