using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Invariance;

using NUnit.Framework;
using FluentAssertions;

namespace InvarianceTests
{
    /// <remarks>
    /// This test does not compile, because the IDictionary interface is not declared as variant - it is invariant.
    /// Our attempts to cast 
    /// </remarks>
    [TestFixture]
    public class DictionaryTests
    {
        [Test]
        public void DictionaryIsInvariant()
        {
            // Attempt covariance...
            IDictionary<Supertype, Supertype> supertypeDictionary = new Dictionary<Subtype, Subtype>();
            
            // Attempt contravariance...
            IDictionary<Subtype, Subtype> subtypeDictionary = new Dictionary<Supertype, Supertype>();
        }
    }
}
