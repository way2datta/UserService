using System.Collections.Generic;

namespace RegisterUser.ClassLibrary
{
    public interface IUserService
    {
        List<User> GetUsers();

        void Register(User user);
    }
}