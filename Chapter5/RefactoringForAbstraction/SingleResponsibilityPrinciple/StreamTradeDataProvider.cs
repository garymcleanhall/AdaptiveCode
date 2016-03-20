using System;
using System.Collections.Generic;
using System.IO;
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    /// <summary>
    ///     TradeDataProvider implementation using a Stream to read data. Implements <see cref="ITradeDataProvider" />.
    /// </summary>
    /// <seealso cref="SingleResponsibilityPrinciple.Contracts.ITradeDataProvider" />
    public class StreamTradeDataProvider : ITradeDataProvider
    {
        private readonly Stream _stream;

        /// <summary>
        ///     Initializes a new instance of the <see cref="StreamTradeDataProvider" /> class.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public StreamTradeDataProvider(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            _stream = stream;
        }

        /// <summary>
        ///     Gets the trade data.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetTradeData()
        {
            List<string> tradeData = new List<string>();

            using (StreamReader reader = new StreamReader(_stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    tradeData.Add(line);
                }
            }

            return tradeData;
        }
    }
}