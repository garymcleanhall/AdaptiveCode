using System;
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class SimpleTradeValidator : ITradeValidator
    {
        private readonly ILogger _logger;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SimpleTradeValidator" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public SimpleTradeValidator(ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            _logger = logger;
        }

        /// <summary>
        ///     Validates the specified trade data.
        /// </summary>
        /// <param name="tradeData">The trade data.</param>
        /// <returns></returns>
        public bool Validate(string[] tradeData)
        {
            if (tradeData == null)
            {
                throw new ArgumentNullException(nameof(tradeData));
            }

            if (tradeData.Length != 3)
            {
                _logger.LogWarning("Line malformed. Only {0} field(s) found.", tradeData.Length);
                return false;
            }

            if (tradeData[0]?.Length != 6)
            {
                _logger.LogWarning("Trade currencies malformed: '{0}'", tradeData[0]);
                return false;
            }

            int tradeAmount;
            if (!int.TryParse(tradeData[1], out tradeAmount))
            {
                _logger.LogWarning("Trade not a valid integer: '{0}'", tradeData[1]);
                return false;
            }

            decimal tradePrice;
            if (!decimal.TryParse(tradeData[2], out tradePrice))
            {
                _logger.LogWarning("Trade price not a valid decimal: '{0}'", tradeData[2]);
                return false;
            }

            return true;
        }
    }
}