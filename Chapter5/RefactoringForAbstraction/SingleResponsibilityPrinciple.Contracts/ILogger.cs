namespace SingleResponsibilityPrinciple.Contracts
{
    /// <summary>
    /// Interface for Logger strategy implemenations.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs warning messages.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        void LogWarning(string message, params object[] args);

        /// <summary>
        /// Logs information messages.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        void LogInfo(string message, params object[] args);
    }
}