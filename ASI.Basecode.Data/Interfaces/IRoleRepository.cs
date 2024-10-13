using ASI.Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Interfaces
{
    public interface IRoleRepository
    {
        public IEnumerable<Role> ViewRoles();
        public void AddRole(Role role);
        public Role GetRoleByID(int id);
        public void EditRole(Role role);
        public void DeleteRole(Role role);
    }
}
