using System;

namespace RegisterUser.ClassLibrary
{
    public class UserValidator : IValidator<User>
    {
        public void Validate(User user)
        {
            if (string.IsNullOrEmpty(user.Email))
            {
                var fieldIsRequiredMessage = ValidationMessages.GetFieldIsRequiredMessage(nameof(User.Email));
                throw new EntityNotValidException(fieldIsRequiredMessage);
            }

            if (string.IsNullOrEmpty(user.Name))
            {
                var fieldIsRequiredMessage = ValidationMessages.GetFieldIsRequiredMessage(nameof(User.Name));
                throw new EntityNotValidException(fieldIsRequiredMessage);
            }
        }
    }
}