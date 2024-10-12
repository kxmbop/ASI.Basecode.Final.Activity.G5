using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using Basecode.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Repositories
{
    public class UserAccessRepository : BaseRepository, IUserAccessRepository
    {
        private readonly AsiBasecodeDBContext _dbContext;

        public UserAccessRepository(AsiBasecodeDBContext dbContext, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = dbContext;
        }

        public void AddUser(UserAccess userAccess)
        {
            this.GetDbSet<UserAccess>().Add(userAccess);
            UnitOfWork.SaveChanges();
        }

        public void DeleteUser(UserAccess userAccess)
        {
            _dbContext.Remove(userAccess);
            UnitOfWork.SaveChanges();
        }

        public void EditUser(UserAccess userAccess)
        {
            var currentUser = _dbContext.Access.FirstOrDefault(u => u.UserAcID == userAccess.UserAcID);

            if (currentUser == null)
            {
                throw new Exception("User not found!");
            }

            currentUser = userAccess;
            UnitOfWork.SaveChanges();
        }

        public UserAccess GetUserByID(int id)
        {
            var user = _dbContext.Access
                                    .Include(u => u.Role)
                                    .FirstOrDefault(u => u.UserAcID == id);

            if (user == null)
            {
                throw new Exception("User not found!");
            }

            return user;
        }

        public IEnumerable<UserAccess> ViewAccessControls()
        {
            return _dbContext.Access.ToList();
        }
    }
}
