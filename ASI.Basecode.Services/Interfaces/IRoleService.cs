using ASI.Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Interfaces
{
    public interface IRoleService
    {
        public (bool, IEnumerable<Role>) GetRoles();
        public void AddRole(Role role);
        public Role GetRoleByID(int id);
        public void EditRole(Role role);
        public void DeleteRole(int id);
        public string GetRoleTypeByID(int id);
    }
}
