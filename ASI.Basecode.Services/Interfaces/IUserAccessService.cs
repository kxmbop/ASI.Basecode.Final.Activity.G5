using ASI.Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Interfaces
{
    public interface IUserAccessService
    {
        public (bool, IEnumerable<UserAccess>) GetUsers();
        public void AddUsers(UserAccess userAccess);
        public UserAccess GetUserByID(int id);
        public void EditUsers(UserAccess userAccess);
        public void DeleteUsers(int id);
    }
}
