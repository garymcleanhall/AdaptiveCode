using System;
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    /// <summary>
    ///     Logs messages to the console. A strategy pattern implementation of <see cref="ILogger" />.
    /// </summary>
    /// <seealso cref="SingleResponsibilityPrinciple.Contracts.ILogger" />
    public class ConsoleLogger : ILogger
    {
        /// <summary>
        ///     Logs warning messages.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public void LogWarning(string message, params object[] args)
        {
            Console.WriteLine(string.Concat("WARN: ", message), args);
        }

        /// <summary>
        ///     Logs information messages.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public void LogInfo(string message, params object[] args)
        {
            Console.WriteLine(string.Concat("INFO: ", message), args);
        }
    }
}