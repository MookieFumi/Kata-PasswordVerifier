namespace PasswordVerifier.Impl
{
    public class Password
    {
        public Password(string value)
        {
            Value = value ?? string.Empty;
        }
        public string Value { get; }
    }
}