﻿using System.Linq;
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

        [Fact]
        public void password_not_be_null()
        {
            var passwordVerifier = new PasswordVerifier();
            bool result = passwordVerifier.Verify(null);
            result.Should().Be(false);
        }

        [Fact]
        public void password_must_have_at_least_one_uppercase()
        {
            var passwordVerifier = new PasswordVerifier();
            bool result = passwordVerifier.Verify("AAAAAAAA");
            result.Should().Be(true);
        }
    }

    public class PasswordVerifier
    {
        public bool Verify(string password)
        {
            return HasMinimunLength(password) && HaveAtLeastOneUppercase(password);
        }

        private static bool HaveAtLeastOneUppercase(string password)
        {
            return password.ToCharArray().Any(char.IsUpper);
        }

        private static bool HasMinimunLength(string password)
        {
            return password?.Length == 8;
        }
    }
}
