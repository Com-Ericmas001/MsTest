using System;
using FluentAssertions;
using FluentAssertions.Execution;
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
            var exception = assert.Throw<Exception>().And;
            switch (exception)
            {
                case ArgumentNullException anE:
                {
                    anE.ParamName.Should().Be(paramName);
                    break;
                }
                case AggregateException aggE:
                {
                    aggE.InnerExceptions.Count.Should().Be(1);
                    aggE.InnerException.Should().BeOfType<ArgumentNullException>();
                    var anE = (ArgumentNullException)aggE.InnerException;
                    anE?.ParamName.Should().Be(paramName);
                    break;
                }

                default:
                {
                    throw new AssertionFailedException($"Expected type to be {typeof(ArgumentNullException)}, but found {exception.GetType()}.");
                }
            }
        }

        /// <summary>
        /// ThrowArgumentException
        /// </summary>
        public static void ThrowArgumentException(this ActionAssertions assert, string paramName)
        {
            var exception = assert.Throw<Exception>().And;
            switch (exception)
            {
                case ArgumentException aE:
                {
                    aE.ParamName.Should().Be(paramName);
                    break;
                }
                case AggregateException aggE:
                {
                    aggE.InnerExceptions.Count.Should().Be(1);
                    aggE.InnerException.Should().BeOfType<ArgumentException>();
                    var aE = (ArgumentException)aggE.InnerException;
                    aE?.ParamName.Should().Be(paramName);
                    break;
                }

                default:
                {
                    throw new AssertionFailedException($"Expected type to be {typeof(ArgumentException)}, but found {exception.GetType()}.");
                }
            }
        }
    }
}
