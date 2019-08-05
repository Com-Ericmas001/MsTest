using FluentAssertions.Equivalency;

namespace Com.Ericmas001.MsTest.Equivalency
{
    public class EquivalencyOptions
    {
        private readonly IEquivalencyOption[] _options;

        public EquivalencyOptions(params IEquivalencyOption[] options)
        {
            _options = options;
        }
        public EquivalencyAssertionOptions<T> ExecuteOptions<T>(EquivalencyAssertionOptions<T> op)
        {
            foreach (var o in _options)
                o.ExecuteOption(op);
            return op;
        }
    }
}