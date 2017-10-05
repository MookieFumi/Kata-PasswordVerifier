using System;

namespace PasswordVerifier.Impl
{
    public class PasswordVerifierException : Exception
    {
        public PasswordVerifierException(string reason) : base(reason)
        {

        }
    }
}