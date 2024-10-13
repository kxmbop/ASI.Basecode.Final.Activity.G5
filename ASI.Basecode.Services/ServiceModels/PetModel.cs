using ASI.Basecode.Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.ServiceModels
{
    public class PetModel
    {
        public int PetId { get; set; }

        [Required(ErrorMessage = "Breed is required!")]
        public string PetBreed { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        public string PetName { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;
        

    }
}
