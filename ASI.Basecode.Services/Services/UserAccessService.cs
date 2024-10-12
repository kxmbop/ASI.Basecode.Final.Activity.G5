using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Services
{
    public class UserAccessService : IUserAccessService
    {
        private readonly IUserAccessRepository _userAccessRepository;
        private readonly IRoleRepository _roleRepository;

        public UserAccessService(IUserAccessRepository userAccessRepository, IRoleRepository roleRepository)
        {
            this._userAccessRepository = userAccessRepository;
            this._roleRepository = roleRepository;
        }

        public void AddUsers(UserAccess userAccess)
        {
            try
            {
                // Validate if RoleID exists before adding user
                var role = _roleRepository.GetRoleByID(userAccess.RoleId);
                if (role == null)
                {
                    throw new InvalidDataException("Invalid RoleId provided");
                }

                var newUsers = new UserAccess();
                newUsers.FirstName = userAccess.FirstName;
                newUsers.LastName = userAccess.LastName;
                newUsers.Email = userAccess.Email;
                newUsers.RoleId = userAccess.RoleId;
                newUsers.CreatedTime = DateTime.Now;
                newUsers.UpdatedTime = DateTime.Now;

                _userAccessRepository.AddUser(newUsers);
            }
            catch (Exception)
            {
                throw new InvalidDataException("Error adding users");
            }
        }

        public void DeleteUsers(int id)
        {
            var users = _userAccessRepository.GetUserByID(id);

            _userAccessRepository.DeleteUser(users);
        }

        public void EditUsers(UserAccess userAccess)
        {
            var currentUsers = _userAccessRepository.GetUserByID(userAccess.UserAcID);

            if (currentUsers == null)
            {
                throw new InvalidDataException("User not found");
            }

            var role = _roleRepository.GetRoleByID(userAccess.RoleId);

            if (role == null)
            {
                throw new InvalidDataException("Invalid RoleID provided");
            }

            currentUsers.FirstName = userAccess.FirstName;
            currentUsers.LastName = userAccess.LastName;
            currentUsers.Email = userAccess.Email;
            currentUsers.RoleId = userAccess.RoleId;

            _userAccessRepository.EditUser(currentUsers);
        }

        public UserAccess GetUserByID(int id)
        {
            return _userAccessRepository.GetUserByID(id);
        }

        public (bool, IEnumerable<UserAccess>) GetUsers()
        {
            var users = _userAccessRepository.ViewAccessControls();

            if (users != null)
            {
                return (true, users);
            }
            return (false, null);
        }
    }
}
