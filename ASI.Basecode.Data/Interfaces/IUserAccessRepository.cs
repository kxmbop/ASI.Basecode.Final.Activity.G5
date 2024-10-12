using ASI.Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Interfaces
{
    public interface IUserAccessRepository
    {
        public IEnumerable<UserAccess> ViewAccessControls();
        public void AddUser(UserAccess userAccess);
        public UserAccess GetUserByID(int id);
        public void EditUser(UserAccess userAccess);
        public void DeleteUser(UserAccess userAccess);
    }
}
