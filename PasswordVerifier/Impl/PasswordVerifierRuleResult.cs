namespace PasswordVerifier.Impl
{
    public class PasswordVerifierRuleResult
    {
        public PasswordVerifierRuleResult(string reason)
        {
            Reason = reason;
        }
        public string Reason { get; private set; }
    }
}