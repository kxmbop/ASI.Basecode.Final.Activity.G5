using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.ServiceModels;
using System;
using ASI.Basecode.Services.Objects;
using ASI.Basecode.Services.ServiceModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Interfaces
{
    public interface IPetService
    {
        (bool, Pet?) GetPetById(string petId);
        void AddPet(PetModel model);
        void DeletePet(string petId);
        void UpdatePet(PetModel model);
        IEnumerable<PetObj> GetPets();
    }
}
