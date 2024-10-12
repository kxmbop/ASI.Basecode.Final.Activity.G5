using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Objects
{
    public class PetObj
    {
        public int PetId { get; set; }
        public string PetBreed { get; set; }
        public string PetName { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
    }
}
