using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using Basecode.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Repositories
{
    public class RoleRepository : BaseRepository, IRoleRepository
    {
        private readonly AsiBasecodeDBContext _dbContext;

        public RoleRepository(AsiBasecodeDBContext dbContext, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = dbContext;
        }

        public void AddRole(Role role)
        {
            this.GetDbSet<Role>().Add(role);
            UnitOfWork.SaveChanges();
        }

        public void DeleteRole(Role role)
        {
            _dbContext.Remove(role);
            UnitOfWork.SaveChanges();
        }

        public void EditRole(Role role)
        {
            var currentRole = _dbContext.Roles.FirstOrDefault(role => role.RoleId == role.RoleId);

            if (currentRole == null)
            {
                throw new Exception("Role not found!");
            }

            currentRole = role;

            UnitOfWork.SaveChanges();

        }

        public Role GetRoleByID(int id)
        {
            var role = _dbContext.Roles.FirstOrDefault(role => role.RoleId == id);

            if (role == null)
            {
                throw new Exception("Role not found!");
            }

            return role;
        }

        public IEnumerable<Role>? ViewRoles()
        {
            return _dbContext.Roles.ToList();
        }
    }
}
