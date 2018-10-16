using System;
using System.Collections.Generic;
using System.Reflection;

namespace Com.Ericmas001.MsTest.Attributes
{

    /// <summary>
    /// NullOrEmptyAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class NullOrEmptyAttribute : BaseAttribute
    {
        private readonly object[] _null;
        private readonly object[] _empty;

        /// <summary>
        /// NullOrEmptyAttribute
        /// </summary>
        public NullOrEmptyAttribute() : this(new object[0])
        {
        }

        /// <summary>
        /// NullOrEmptyAttribute
        /// </summary>
        public NullOrEmptyAttribute(params object[] values)
        {
            _null = GetObject(null, values);
            _empty = GetObject("", values);
        }

        /// <summary>
        /// GetData
        /// </summary>
        public override IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            return new List<object[]> {
                _null,
                _empty
            };
        }
    }
}
