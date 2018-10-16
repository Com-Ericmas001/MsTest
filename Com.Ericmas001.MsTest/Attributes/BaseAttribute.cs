using System;
using System.Collections.Generic;
using System.Reflection;
using Com.Ericmas001.MsTest.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Com.Ericmas001.MsTest.Attributes
{

    /// <summary>
    /// BaseAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class BaseAttribute : Attribute, ITestDataSource
    {

        /// <summary>
        /// GetData
        /// </summary>
        public abstract IEnumerable<object[]> GetData(MethodInfo methodInfo);

        /// <summary>
        /// GetDisplayName
        /// </summary>
        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            return methodInfo.GetDisplayName(data);
        }

        /// <summary>
        /// GetObject
        /// </summary>
        protected static object[] GetObject(object value, params object[] values)
        {
            var list = new List<object> { value };
            list.AddRange(values);
            return list.ToArray();
        }
    }
}
