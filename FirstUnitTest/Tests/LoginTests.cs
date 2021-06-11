using NUnit.Framework;

namespace SeleniumTests
{
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidData()
        {
            AccountData user = new AccountData(Settings.Login, Settings.Password);
            app.Auth.Logout();
            app.Auth.Login(user);
            Assert.IsTrue(app.Auth.IsLoggedIn(user.Username));
        }
        [Test]
        public void LoginWithInvalidData()
        {
            AccountData user = new AccountData("user", "password");
            app.Auth.Logout();
            app.Auth.Login(user);
            Assert.IsFalse(app.Auth.IsLoggedIn(user.Username));
        }

    }
}
