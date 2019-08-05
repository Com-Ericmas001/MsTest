using Com.Ericmas001.MsTest.Equivalency;
using FluentAssertions;
using FluentAssertions.Primitives;

namespace Com.Ericmas001.MsTest.Extensions
{
    public static class EquivalentExtensions
    {
        public static bool IsEquivalentTo(this object o1, object o2, params IEquivalencyOption[] options)
        {
            try
            {
                var ops = new EquivalencyOptions(options);
                o1.Should().BeEquivalentTo(o2, ops.ExecuteOptions);
                o2.Should().BeEquivalentTo(o1, ops.ExecuteOptions);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static void BeEquivalentTo<T>(this ObjectAssertions assertion, T expectation, params IEquivalencyOption[] options)
        {
            var ops = new EquivalencyOptions(options);
            assertion.BeEquivalentTo(expectation, ops.ExecuteOptions);
        }
    }
}
