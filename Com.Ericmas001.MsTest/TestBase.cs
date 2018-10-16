using System.Collections.Generic;
using System.Runtime.Serialization;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Kernel;

namespace Com.Ericmas001.MsTest
{
    /// <summary>
    /// TestBase
    /// </summary>
    public class TestBase<T> where T : class
    {
        private T _testInstance;
        private IFixture _fixture;

        /// <summary>
        /// TestInstance
        /// </summary>
        public T TestInstance => _testInstance ?? CreateInstance();

        /// <summary>
        /// AutoFixture
        /// </summary>
        public IFixture AutoFixture
        {
            get
            {
                _fixture = _fixture ?? CreateFixture();
                return _fixture;
            }
        }

        /// <summary>
        /// CustomizeAutoFixture
        /// </summary>
        protected virtual void CustomizeAutoFixture(Fixture autoFixture)
        {

        }

        /// <summary>
        /// GetCustomizations
        /// </summary>
        protected virtual List<ISpecimenBuilder> GetCustomizations()
        {
            return new List<ISpecimenBuilder>();
        }

        /// <summary>
        /// CreateFixture
        /// </summary>
        public IFixture CreateFixture()
        {
            var fixture = new Fixture();
            fixture.Customize(new AutoNSubstituteCustomization { ConfigureMembers = true });
            foreach (var customization in GetCustomizations())
            {
                fixture.Customizations.Add(customization);
            }
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            fixture.Register<ExtensionDataObject>(() => null);

            CustomizeAutoFixture(fixture);
            return fixture;
        }

        private T CreateInstance()
        {
            _testInstance = AutoFixture.Create<T>();
            return _testInstance;
        }
    }
}
