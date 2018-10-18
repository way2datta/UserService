using System;

namespace RegisterUser
{
    interface IValidator<T> where T:class
    {
        void Validate(T entity);
    }

    internal class UserValidator : IValidator<User>
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