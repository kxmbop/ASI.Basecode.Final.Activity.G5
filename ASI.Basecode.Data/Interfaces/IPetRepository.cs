using ASI.Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Interfaces
{
    public interface IPetRepository
    {
        IEnumerable<Pet> GetPets();
        bool PetExists(string petId);
        void AddPet(Pet pet);
        void DeletePet(string petId);
        void UpdatePet(Pet pet);
        Pet GetPetById(string petId);

    }
}
