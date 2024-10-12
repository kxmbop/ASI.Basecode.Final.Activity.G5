using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using ASI.Basecode.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ASI.Basecode.WebApp.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            this._roleService = roleService;
        }

        public IActionResult Index()
        {
            (bool result, IEnumerable<Role> roles) = _roleService.GetRoles();

            if (result)
            {
                return View(roles);
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Role role)
        {
            if (!ModelState.IsValid)
            {
                return View(role);
            }

            _roleService.AddRole(role);
            return RedirectToAction("Index", "Role");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var role = _roleService.GetRoleByID(id);

            if (role == null)
            {
                return NotFound();
            }

            var editRole = new Role
            {
                RoleId = id,
                RoleType = role.RoleType,
                Description = role.Description,
            };

            return View(editRole);
        }

        [HttpPost]
        public IActionResult Edit(Role role)
        {
            _roleService.EditRole(role);

            return RedirectToAction("Index", "Role");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var role = _roleService.GetRoleByID(id);
            if (role == null)
            {
                return NotFound();
            }

            _roleService.DeleteRole(id);
            return RedirectToAction("Index");
        }
    }
}
