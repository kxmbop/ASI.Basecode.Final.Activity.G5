using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using Basecode.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Repositories
{
    public class PetRepository : BaseRepository, IPetRepository
    {
        private readonly AsiBasecodeDBContext _dbContext;

        public PetRepository(AsiBasecodeDBContext dBContext, UnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = dBContext;
        }
        public IEnumerable<Pet> ViewPets()
        {
            return _dbContext.Pets.ToList();
        }

        public void AddPet(Pet pet)
        {
            pet.CreatedTime = DateTime.Now;
            _dbContext.Pets.Add(pet);
            _dbContext.SaveChanges();
        }

        public void DeletePet(string petId)
        {
            if (int.TryParse(petId, out int parsedPetId))
            {
                var pet = _dbContext.Pets.Find(parsedPetId);
                if (pet == null)
                {
                    throw new Exception("Pet not Found");
                }

                _dbContext.Pets.Remove(pet);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Invalid Pet ID.");
            }
        }

        public void UpdatePet(Pet pet)
        {
            var existingPet = _dbContext.Pets.FirstOrDefault(t => t.PetId == pet.PetId);
            if (existingPet == null)
            {
                throw new Exception("Pet not Found");
            }

            existingPet.PetBreed = pet.PetBreed;
            existingPet.PetName = pet.PetName;
            existingPet.UpdatedTime = DateTime.Now;
            _dbContext.Pets.Update(existingPet);
            _dbContext.SaveChanges();
        }

        public Pet GetPetById(string petId)
        {
            var pet = _dbContext.Pets.FirstOrDefault(t => t.PetId.ToString() == petId);
            if (pet == null)
            {
                throw new Exception("Pet not Found.");
            }

            return pet;
        }

        public IEnumerable<Pet> GetPets()
        {
            return _dbContext.Pets.ToList();
        }

        public bool PetExists(string petId)
        {
            throw new NotImplementedException();
        }


        
    }
}
