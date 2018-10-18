using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RegisterUser.ClassLibrary.Tests
{
    [TestClass]
    public class UserValidatorUnitTests
    {
        private readonly UserValidator userValidator = new UserValidator();

        [TestMethod]
        public void WhenEmailIsNotProvided_ThenThrowException()
        {
            var user = new User { Name = "John Doe" };
            try
            {
                userValidator.Validate(user);
            }
            catch (Exception ex)
            {
                var fieldIsRequiredMessage = ValidationMessages.GetFieldIsRequiredMessage(nameof(User.Email));
                Assert.AreEqual(fieldIsRequiredMessage, ex.Message);
                return;
            }

            Assert.Fail("Should throw exception when email is not provided.");
        }

        [TestMethod]
        public void WhenNameIsNotProvided_ThenThrowException()
        {
            var user = new User { Email = "John.Doe@test.com" };
            try
            {
                userValidator.Validate(user);
            }
            catch (Exception ex)
            {
                var fieldIsRequiredMessage = ValidationMessages.GetFieldIsRequiredMessage(nameof(User.Name));
                Assert.AreEqual(fieldIsRequiredMessage, ex.Message);
                return;
            }

            Assert.Fail("Should throw exception when email is not provided.");
        }

        [TestMethod]
        public void WhenUserDetailsIsProvided_ThenShouldNotThrowException()
        {
            var user = new User { Email = "John.Doe@test.com", Name = "John Doe" };
            userValidator.Validate(user);
        }
    }
}