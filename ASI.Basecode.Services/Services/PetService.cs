using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using ASI.Basecode.Services.Objects;
using System.Collections.Generic;
using System;
using System.Linq;
using ASI.Basecode.Services.ServiceModels;

public class PetService : IPetService
{
    private readonly IPetRepository _petRepository;

    public PetService(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public (bool, Pet?) GetPetById(string petId)
    {
        var pet = _petRepository.GetPetById(petId);

        if (pet == null)
        {
            return (false, pet);
        }
        
        return (true, pet);
    }

    public void AddPet(PetModel model)
    {
        var pet = new Pet
        {
            PetBreed = model.PetBreed,
            PetName = model.PetName,
            CreatedTime = DateTime.Now,
        };

        _petRepository.AddPet(pet);
    }

    public void DeletePet(string petId)
    {
        _petRepository.DeletePet(petId);
    }

    public void UpdatePet(PetModel model)
    {
        if (model == null)
        {
            throw new AccessViolationException();
        }

        var pet = new Pet
        {
            PetId = model.PetId,
            PetBreed = model.PetBreed,
            PetName = model.PetName,
        };

        _petRepository.UpdatePet(pet);
    }

    public IEnumerable<PetObj> GetPets()
    {
        var pets = _petRepository.GetPets();
        if (!pets.Any())
        {
            return new List<PetObj>();
        }

        var petObjs = pets.Select(t => new PetObj
        {
            PetId = t.PetId,
            PetBreed = t.PetBreed,
            PetName = t.PetName,
            CreatedTime = t.CreatedTime,
        });

        return petObjs;
    }
}
