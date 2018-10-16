using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Com.Ericmas001.MsTest.Attributes
{

    /// <summary>
    /// NullEmptyOrWhiteSpacesAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class NullEmptyOrWhiteSpacesAttribute : NullOrEmptyAttribute
    {
        private readonly object[] _whitespaces;
        /// <summary>
        /// NullEmptyOrWhiteSpacesAttribute
        /// </summary>
        public NullEmptyOrWhiteSpacesAttribute() : this(new object[0])
        {
        }

        /// <summary>
        /// NullEmptyOrWhiteSpacesAttribute
        /// </summary>
        public NullEmptyOrWhiteSpacesAttribute(params object[] values) : base(values)
        {
            _whitespaces = GetObject("   ", values);
        }

        /// <summary>
        /// GetData
        /// </summary>
        public override IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            return base.GetData(methodInfo).Concat(new []{_whitespaces}).ToList();
        }
    }
}
