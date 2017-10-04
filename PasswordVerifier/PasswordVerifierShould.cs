using FluentAssertions;
using Xunit;

namespace PasswordVerifier
{
    public class PasswordVerifierShould
    {
        [Fact]
        public void password_must_have_at_least_8_characters()
        {
            var passwordVerifier = new PasswordVerifier();
            bool result = passwordVerifier.Verify("pass");
            result.Should().Be(false);
        }
    }

    public class PasswordVerifier
    {
        public bool Verify(string password)
        {
            return password.Length == 8;
        }
    }
}
