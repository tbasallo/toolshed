using Toolshed;

namespace ToolGrinder
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        public void IsEmail_ValidEmails_ReturnsTrue()
        {
            string[] validEmails = new[]
            {
                "user@example.com",
                "user.name@example.co",
                "user_name-123@example-domain.com",
                "user+tag@example.io",
                "mixed.CHARS_123+tag@example.travel",
                "MURILLONICOLE43@GMAIL.COM",
                "TONY@BASALLO.COM",
                "tony@basallo.com"
            };

            foreach (var email in validEmails)
            {
                Assert.IsTrue(email.IsEmail(), $"Expected valid email to return true: {email}");
            }
        }

        [TestMethod]
        public void IsEmail_InvalidEmails_ReturnsFalse()
        {
            string? nullEmail = null;
            Assert.IsFalse(nullEmail.IsEmail(), "Null should be invalid");

            string[] invalidEmails = new[]
            {
                string.Empty,              // empty
                "UserExample.com",        // missing @
                "@example.com",           // missing local part
                "user@@example.com",      // double @
                "user@.com",              // @.
                "user@-domain.com",       // @-
                "user.@example.com",      // .@ sequence
                "user@exa mple.com",      // space in domain
                " user@example.com",      // leading space
                "user@example.com ",      // trailing space
                "us er@example.com"       // space in local part
            };

            foreach (var email in invalidEmails)
            {
                Assert.IsFalse(email.IsEmail(), $"Expected invalid email to return false: '{email}'");
            }
        }
    }
}
