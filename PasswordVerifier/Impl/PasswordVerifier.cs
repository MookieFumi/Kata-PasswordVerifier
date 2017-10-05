using System.Collections.ObjectModel;
using System.Linq;

namespace PasswordVerifier.Impl
{
    public class PasswordVerifier
    {
        private readonly Collection<PasswordVerifierRule> _rules = new Collection<PasswordVerifierRule>
        {
            new PasswordVerifierRule(password => !string.IsNullOrEmpty(password?.Value) || password.Value.Length >= 8,
                new PasswordVerifierRuleResult("Not valid length")),
            new PasswordVerifierRule(password => password.Value.ToCharArray().Any(char.IsNumber),
                new PasswordVerifierRuleResult("Not exists any number")),
            new PasswordVerifierRule(password => password.Value.ToCharArray().Any(char.IsUpper),
                new PasswordVerifierRuleResult("Not exists any upper character")),
            new PasswordVerifierRule(password => password.Value.ToCharArray().Any(char.IsLower),
                new PasswordVerifierRuleResult("Not exists any lower character")),
            new PasswordVerifierRule(password => password.Value.ToCharArray().Any(char.IsSymbol),
                new PasswordVerifierRuleResult("Not exists any upper symbol"))
        };

        public PasswordVerifierResult Verify(Password password)
        {
            return HasRequiredRules(password) ?
                new PasswordVerifierResult(true) :
                new PasswordVerifierResult(false, _rules.Where(p => !p.MatchingCondition(password)).Select(p => p.Result.Reason));
        }

        private bool HasRequiredRules(Password password)
        {
            return _rules.Count(p => p.MatchingCondition(password)) >= 3;
        }
    }
}