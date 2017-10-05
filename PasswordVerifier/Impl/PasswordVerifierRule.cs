using System;

namespace PasswordVerifier.Impl
{
    public class PasswordVerifierRule
    {
        public Func<Password, bool> MatchingCondition { get; }
        public PasswordVerifierRuleResult Result { get; }

        public PasswordVerifierRule(Func<Password, bool> matchingCondition, PasswordVerifierRuleResult result)
        {
            MatchingCondition = matchingCondition;
            Result = result;
        }
    }
}