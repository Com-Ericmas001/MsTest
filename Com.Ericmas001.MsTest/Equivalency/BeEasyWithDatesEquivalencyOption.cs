using System;
using FluentAssertions;
using FluentAssertions.Equivalency;

namespace Com.Ericmas001.MsTest.Equivalency
{
    public class BeEasyWithDatesEquivalencyOption : IEquivalencyOption
    {
        private readonly int _millisecondPrecision;

        public BeEasyWithDatesEquivalencyOption(int millisecondPrecision = 1000)
        {
            _millisecondPrecision = millisecondPrecision;
        }
        public void ExecuteOption<T>(EquivalencyAssertionOptions<T> op)
        {
            op.Using<DateTimeOffset>(ctx => ctx.Subject.Should().BeCloseTo(ctx.Expectation, _millisecondPrecision)).WhenTypeIs<DateTimeOffset>();
        }
    }
}