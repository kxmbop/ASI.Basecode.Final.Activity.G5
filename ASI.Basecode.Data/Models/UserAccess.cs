using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Models
{
    public class UserAccess
    {
        [Key]
        public int UserAcID { get; set; }

        [Required(ErrorMessage = "Please enter your FirstName.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your LastName.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your Email.")]
        public string Email { get; set; }
        public int RoleId { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }


        // Navigation property
        public Role Role { get; set; }
    }
}
