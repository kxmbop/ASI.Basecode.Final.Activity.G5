using ASI.Basecode.Data.Models;
using System.Collections.Generic;

namespace ASI.Basecode.Data.Interfaces
{
    public interface IUserMRepository
    {
        IEnumerable<UserM> ViewUserM();
        int AddUserM(UserM userm);
        void DeleteUserM(int usermId);
        void UpdateUserM(UserM userm);
    }
}
