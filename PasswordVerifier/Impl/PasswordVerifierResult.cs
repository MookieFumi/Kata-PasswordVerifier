using System.Collections.Generic;
using System.Linq;

namespace PasswordVerifier.Impl
{
    public class PasswordVerifierResult
    {
        public PasswordVerifierResult(bool isValid) : this(isValid, Enumerable.Empty<string>())
        {
        }

        public PasswordVerifierResult(bool isValid, IEnumerable<string> reasons)
        {
            IsValid = isValid;
            Reasons = reasons;
        }

        public bool IsValid { get; private set; }
        public IEnumerable<string> Reasons { get; private set; }
    }
}