using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using ASI.Basecode.Services.ServiceModels;
using ASI.Basecode.WebApp.Models;
using ASI.Basecode.WebApp.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace ASI.Basecode.WebApp.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var pets = _petService.GetPets();

            var viewModel = new PetViewModel
            {
                Pets = pets
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(PetModel model)
        {
            if (ModelState.IsValid)
            {
                _petService.AddPet(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(PetModel model)
        {
            if (ModelState.IsValid)
            {
                _petService.UpdatePet(model);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(string petId)
        {
            _petService.DeletePet(petId);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult GetPetById(string petId)
        {
            var (result, pet) = _petService.GetPetById(petId);
            if(!result || pet == null)
            {
                return NotFound();
            }
            return Json(new
            {
            petId = pet.PetId.ToString(),
            petBreed = pet.PetBreed,
            petName = pet.PetName,
            updatedTime = pet.UpdatedTime
            });
        }
    }
}
