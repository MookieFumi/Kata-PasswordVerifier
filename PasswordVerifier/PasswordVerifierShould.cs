using System.Diagnostics;
using FluentAssertions;
using PasswordVerifier.Impl;
using Xunit;

namespace PasswordVerifier
{
    public class PasswordVerifierShould
    {
        private readonly Impl.PasswordVerifier _sut;

        public PasswordVerifierShould()
        {
            _sut = new Impl.PasswordVerifier();
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("x", false)]
        [InlineData("aB34567", true)]
        [InlineData("12345678", false)]
        [InlineData("1234567H", true)]
        [InlineData("1234567h", true)]
        [InlineData("aB345678", true)]
        [InlineData("@A345678", true)]
        public void returns_isvalid_ok_when_at_least_three_conditions_are_passed(string password, bool expectedResult)
        {
            var result = _sut.Verify(new Password(password));
            result.IsValid.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("x")]
        public void returns_reasons_if_not_is_valid(string password)
        {
            var result = _sut.Verify(new Password(password));
            result.Reasons.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData("1234567h")]
        [InlineData("aB345678")]
        public void returns_no_reason_if_is_valid(string password)
        {
            var result = _sut.Verify(new Password(password));
            result.Reasons.Should().BeEmpty();
        }
    }
}
