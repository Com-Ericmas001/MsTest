using System;
using System.Collections.Generic;
using System.Reflection;

namespace Com.Ericmas001.MsTest.Attributes
{

    /// <summary>
    /// NullOrEmptyListAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class NullOrEmptyListAttribute : BaseAttribute
    {

        private static readonly Type ListGenericType = typeof(List<int>).GetGenericTypeDefinition();
        private readonly object[] _listValue;
        private readonly object[] _null;

        /// <summary>
        /// NullOrEmptyListAttribute
        /// </summary>
        public NullOrEmptyListAttribute(Type listType, params object[] values)
        {
            _listValue = GetObject(Activator.CreateInstance(ListGenericType.MakeGenericType(listType)), values ?? new object[0]);
            _null = GetObject(null, values ?? new object[0]);
        }

        /// <summary>
        /// GetData
        /// </summary>
        public override IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            return new List<object[]> {
                _null,
                _listValue
            };
        }
    }
}
