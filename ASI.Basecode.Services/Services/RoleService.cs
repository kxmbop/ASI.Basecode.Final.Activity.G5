using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            this._roleRepository = roleRepository;
        }

        public string GetRoleTypeByID(int id)
        {
            var role = _roleRepository.GetRoleByID(id); 
            return role != null ? role.RoleType : "Unknown";
        }

        public (bool, IEnumerable<Role>) GetRoles()
        {
            var roles = _roleRepository.ViewRoles();

            if (roles != null)
            {
                return (true, roles);
            }
            return (false, null);

        }

        public Role GetRoleByID(int id)
        {
            return _roleRepository.GetRoleByID(id);
        }

        public void AddRole(Role role)
        {
            try
            {
                var newRole = new Role
                {
                    RoleType = role.RoleType,
                    Description = role.Description,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                };

                _roleRepository.AddRole(newRole);
            }
            catch (Exception)
            {
                throw new InvalidDataException("Error adding roles");
            }
        }

        public void EditRole(Role role)
        {
            var currentRole = _roleRepository.GetRoleByID(role.RoleId);

            if (currentRole == null)
            {
                throw new InvalidDataException("Role not found!");
            }

            currentRole.RoleType = role.RoleType;
            currentRole.Description = role.Description;
            currentRole.UpdatedTime = DateTime.Now;

            _roleRepository.EditRole(currentRole);
        }

        public void DeleteRole(int id)
        {
            var role = _roleRepository.GetRoleByID(id);

            _roleRepository.DeleteRole(role);
        }
    }
}
