using ASI.Basecode.Services.Objects;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ASI.Basecode.WebApp.Models
{
    public class PetViewModel
    {
        
        public IEnumerable<PetObj> Pets { get; set; } = new List<PetObj>();

    }
}
