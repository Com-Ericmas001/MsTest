using System;
using FluentAssertions;
using FluentAssertions.Specialized;

namespace Com.Ericmas001.MsTest.Extensions
{
    /// <summary>
    /// ActionAssertionsExtensions
    /// </summary>
    public static class ActionAssertionsExtensions
    {
        /// <summary>
        /// ThrowArgumentNullException
        /// </summary>
        public static void ThrowArgumentNullException(this ActionAssertions assert, string paramName)
        {
            assert.ThrowExactly<ArgumentNullException>().And.ParamName.Should().Be(paramName);
        }

        /// <summary>
        /// ThrowArgumentException
        /// </summary>
        public static void ThrowArgumentException(this ActionAssertions assert, string paramName)
        {
            assert.ThrowExactly<ArgumentException>().And.ParamName.Should().Be(paramName);
        }
    }
}
