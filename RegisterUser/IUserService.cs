using System.Collections.Generic;

namespace RegisterUser
{
    internal interface IUserService
    {
        List<User> GetUsers();

        void Register(User user);
    }
}