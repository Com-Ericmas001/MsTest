using System.Linq;
using System.Reflection;

namespace Com.Ericmas001.MsTest.Extensions
{
    internal static class MethodInfoExtensions
    {
        internal static string GetDisplayName(this MethodInfo methodInfo, object[] data)
        {
            return data != null ? $"{methodInfo.Name} ({string.Join(",", data.Select(GetObjectValue))})" : "<null>";
        }

        private static string GetObjectValue(object value)
        {
            var valueStr = value?.ToString();
            return valueStr == null ? "<null>" : $"\"{valueStr}\"";
        }
    }
}
