using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ASI.Basecode.Data.Repositories
{
    public class UserMRepository : IUserMRepository
    {
        private readonly AsiBasecodeDBContext _dbContext;

        public UserMRepository(AsiBasecodeDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<UserM> ViewUserM()
        {
            return _dbContext.UserM.ToList();
        }

        public int AddUserM(UserM userm)
        {
            _dbContext.UserM.Add(userm);
            _dbContext.SaveChanges();
            return userm.Id;
        }

        public void DeleteUserM(int id)
        {
            var userm = _dbContext.UserM.Find(id);
            if (userm != null)
            {
                _dbContext.UserM.Remove(userm);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateUserM(UserM userm)
        {
            var existingUserM = _dbContext.UserM.FirstOrDefault(t => t.Id == userm.Id);
            if (existingUserM != null)
            {
                existingUserM.FName = userm.FName;
                existingUserM.LName = userm.LName;
                existingUserM.Email = userm.Email;
                existingUserM.Phone = userm.Phone;
                existingUserM.Address = userm.Address;
                existingUserM.Role = userm.Role;
                _dbContext.UserM.Update(existingUserM);
                _dbContext.SaveChanges();
            }
        }
    }
}
