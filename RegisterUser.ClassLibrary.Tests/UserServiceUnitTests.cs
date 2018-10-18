using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RegisterUser.ClassLibrary.Tests
{
    [TestClass]
    public class UserServiceUnitTests
    {
        private IUserService userService;
        private Mock<INotificationSender> mockNotificationSender;
        private Mock<IValidator<User>> mockUserValidator;

        [TestInitialize]
        public void Initialize()
        {
            mockNotificationSender = new Mock<INotificationSender>();
            mockUserValidator = new Mock<IValidator<User>>();

            userService = new UserService(mockNotificationSender.Object,
                                          mockUserValidator.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotValidException))]
        public void CannotCreateUserWhenDataIsNotProvided()
        {
            var user = new User();
            mockUserValidator.Setup(x => x.Validate(user)).Throws(new EntityNotValidException(""));
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

        [TestMethod]
        public void SendNotificationWhenNewUserIsCreated()
        {
            userService.Register(new User { Name="John Doe", Email="John.Doe@test.com"});
            mockNotificationSender.Verify();
        }
    }
}