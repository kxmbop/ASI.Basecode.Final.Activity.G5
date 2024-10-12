using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using ASI.Basecode.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace ASI.Basecode.WebApp.Controllers
{
    public class UserAccessController : Controller
    {
        private readonly IUserAccessService _userAccessService;
        private readonly IRoleService _roleService;
        public UserAccessController(IUserAccessService userAccessService, IRoleService roleService)
        {
            this._userAccessService = userAccessService;
            this._roleService = roleService;
        }

        public IActionResult Index()
        {
            (bool result, IEnumerable<UserAccess> userAccesses) = _userAccessService.GetUsers();

            if (result)
            {
                return View(userAccesses);
            }
            return View();
        }

        public IActionResult Create()
        {
            // Fetch roles for dropdown
            (bool result, IEnumerable<Role> roles) = _roleService.GetRoles();

            if (result)
            {
                ViewBag.Roles = new SelectList(roles, "RoleId", "RoleType");
            }
            else
            {
                ViewBag.Roles = new SelectList(new List<Role>(), "RoleId", "RoleType");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Create(UserAccess userAccess)
        {
            if (!ModelState.IsValid)
            {
                (bool result, IEnumerable<Role> roles) = _roleService.GetRoles();
                if (result)
                {
                    ViewBag.Roles = new SelectList(roles, "RoleId", "RoleType");
                }
                else
                {
                    ViewBag.Roles = new SelectList(new List<Role>(), "RoleId", "RoleType");
                }

                return View(userAccess);
            }

            _userAccessService.AddUsers(userAccess);
            return RedirectToAction("Index", "UserAccess");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _userAccessService.GetUserByID(id);

            if (user == null)
            {
                return NotFound();
            }

            // Get roles for dropdown
            (bool result, IEnumerable<Role> roles) = _roleService.GetRoles();

            if (result)
            {
                ViewBag.Roles = new SelectList(roles, "RoleId", "RoleType");
            }
            else
            {
                ViewBag.Roles = new SelectList(new List<Role>(), "RoleId", "RoleType");
            }

            var editUser = new UserAccess
            {
                UserAcID = id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                RoleId = user.RoleId,
            };

            return View(editUser);
        }

        [HttpPost]
        public IActionResult Edit(UserAccess userAccess)
        {
            _userAccessService.EditUsers(userAccess);

            return RedirectToAction("Index", "UserAccess");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var user = _userAccessService.GetUserByID(id);
            if (user == null)
            {
                return NotFound();
            }

            _userAccessService.DeleteUsers(id);
            return RedirectToAction("Index");
        }
    }
}
