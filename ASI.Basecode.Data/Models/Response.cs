using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Models
{
    public class Response
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResponseId { get; set; }
<<<<<<< HEAD
        public int PetId { get; set; }
        public string PetBreed{ get; set; }
        public string PetName { get; set; }
=======
        public int TicketId { get; set; }
        public string Sender { get; set; }
>>>>>>> 89387afed3219f92ab731ac777255bde340d1795
        public string Description { get; set; }
        public byte[] Attachment { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

    }
}
