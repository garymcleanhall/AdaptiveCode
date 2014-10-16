using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SubtypeCovariance;

using NUnit.Framework;
using FluentAssertions;

namespace SubtypeCovarianceTests
{
    [TestFixture]
    public class ComparisonTests
    {
        /// <remarks>
        /// Without contravariance in the generic parameter for the IEqualityComparer interface,
        /// an EntityEqualityComparer (which is an IEqualityComparer&lt;Entity&gt;) cannot be used 
        /// where clients require an IEqualityComparer&lt;User&gt;.
        /// </remarks>
        [Test]
        public void UserCanBeComparedWithEntityComparer()
        {
            IEqualityComparer<User> entityComparer = new EntityEqualityComparer();
            var user1 = new User();
            var user2 = new User();
            entityComparer.Equals(user1, user2)
                .Should().BeFalse();
        }
    }
}
