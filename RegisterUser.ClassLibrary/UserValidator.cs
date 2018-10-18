using System;

namespace RegisterUser.ClassLibrary
{
    public class UserValidator : IValidator<User>
    {
        public void Validate(User user)
        {
            if (string.IsNullOrEmpty(user.Email))
            {
                throw new Exception("Users email is required.");
            }

            if (string.IsNullOrEmpty(user.Name))
            {
                throw new Exception("Users name is required.");
            }
        }
    }
}