namespace SingleResponsibilityPrinciple.Contracts
{
    public interface ILogger
    {
        void LogWarning(string message, params object[] args);

        void LogInfo(string message, params object[] args);
    }
}