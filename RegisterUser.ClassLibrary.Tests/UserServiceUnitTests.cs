using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RegisterUser.ClassLibrary.Tests
{
    [TestClass]
    public class UserServiceUnitTests
    {
        private IUserService userService;

        [TestInitialize]
        public void Initialize()
        {
            userService = new UserService(new EmailNotificationSender(), new UserValidator());
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotValidException))]
        public void CannotCreateUserWhenEmailIsNotProvided()
        {
            var user = new User { Name = "John Doe" };
            userService.Register(user);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotValidException))]
        public void CannotCreateUserWhenNameIsNotProvided()
        {
            var user = new User { Email = "John.Doe@test.com" };
            userService.Register(user);
        }

        [TestMethod]
        public void NewUserIsCreated()
        {
            var user = new User { Name = "John Doe", Email = "John.Doe@test.com" };

            Assert.AreEqual(0, userService.GetUsers().Count, "No user found");
            userService.Register(user);
            Assert.AreEqual(1, userService.GetUsers().Count, "Should have created a user");
        }

        //[TestMethod]
        //public void SendNotificationWhenNewUserIsCreated()
        //{
        //    var user = new User { Name = "John Doe", Email = "John.Doe@test.com" };
        //    userService.Register(user);
        //}
    }
}