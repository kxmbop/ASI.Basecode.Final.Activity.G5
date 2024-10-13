using ASI.Basecode.Data.Models;
using System.Collections.Generic;

namespace ASI.Basecode.Services.Interfaces
{
    public interface IUserMService
    {
        (bool success, IEnumerable<UserM> userms) GetUserM();
        int AddUserM(UserM userm);
        void DeleteUserM(int id);
        void UpdateUserM(UserM userm);
    }
}
