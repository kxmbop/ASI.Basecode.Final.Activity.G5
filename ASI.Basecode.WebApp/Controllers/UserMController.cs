using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ASI.Basecode.WebApp.Controllers
{
    public class UserMController : Controller
    {
        private readonly IUserMService _userMService;

        public UserMController(IUserMService userMService)
        {
            _userMService = userMService;
        }

        // GET: UserM
        public IActionResult Index()
        {
            var (success, users) = _userMService.GetUserM();
            if (success)
            {
                return View(users); // Pass the list of users to the view
            }
            return View(new List<UserM>()); // Return an empty list if no users found
        }

        // GET: UserM/Details/5
        public IActionResult Details(int id)
        {
            var (success, users) = _userMService.GetUserM();
            var user = users?.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            return View(user); // Pass a single user to the view
        }

        // GET: UserM/Create
        public IActionResult Create()
        {
            return View(); // Return the create view
        }

        // POST: UserM/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserM model)
        {
            if (ModelState.IsValid)
            {
                _userMService.AddUserM(model);
                return RedirectToAction(nameof(Index)); // Redirect to Index after creation
            }

            return View(model); // Return model with errors
        }

        // GET: UserM/Edit/5
        public IActionResult Edit(int id)
        {
            var (success, users) = _userMService.GetUserM();
            var user = users?.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            return View(user); // Pass the user to the edit view
        }

        // POST: UserM/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UserM model)
        {
            if (ModelState.IsValid)
            {
                if (id != model.Id)
                {
                    return BadRequest("User ID mismatch.");
                }

                _userMService.UpdateUserM(model);
                return RedirectToAction(nameof(Index)); // Redirect to Index after update
            }

            return View(model); // Return model with errors
        }

        // GET: UserM/Delete/5
        public IActionResult Delete(int id)
        {
            var user = _userMService.GetUserM().Item2.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: UserM/DeleteConfirmed/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _userMService.DeleteUserM(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

