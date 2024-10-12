using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace ASI.Basecode.Services.Services
{
    public class UserMService : IUserMService
    {
        private readonly IUserMRepository _usermRepository;

        public UserMService(IUserMRepository usermRepository)
        {
            _usermRepository = usermRepository;
        }

        public (bool, IEnumerable<UserM>) GetUserM()
        {
            var userm = _usermRepository.ViewUserM();
            if (userm != null)
            {
                return (true, userm);
            }
            else
            {
                return (false, null);
            }
        }

        public int AddUserM(UserM userm)
        {
            if (userm == null)
            {
                throw new ArgumentNullException(nameof(userm));
            }

            return _usermRepository.AddUserM(userm);
        }

        public void DeleteUserM(int id)
        {
            _usermRepository.DeleteUserM(id);
        }

        public void UpdateUserM(UserM userm)
        {
            if (userm == null)
            {
                throw new ArgumentNullException(nameof(userm));
            }
            _usermRepository.UpdateUserM(userm);
        }
    }
}
