using FluentAssertions.Equivalency;

namespace Com.Ericmas001.MsTest.Equivalency
{
    public interface IEquivalencyOption
    {
        void ExecuteOption<T>(EquivalencyAssertionOptions<T> op);
    }
}
