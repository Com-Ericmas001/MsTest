using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using AutoFixture.Kernel;

namespace Com.Ericmas001.MsTest
{
    /// <summary>
    /// 
    /// </summary>
    public class CollectionTypesToIgnore : ISpecimenBuilder
    {
        private readonly List<Type> _typesToIgnore;

        /// <summary>
        /// CollectionTypesToIgnore
        /// </summary>
        public CollectionTypesToIgnore(IEnumerable<Type> typesToIgnore)
        {
            _typesToIgnore = typesToIgnore.ToList();
        }

        private readonly Dictionary<Type, Type> _dictionary = new Dictionary<Type, Type>
        {
            { typeof(ICollection<>) , typeof(Collection<>) },
            { typeof(IList<>) , typeof(List<>) },
            { typeof(IDictionary<int,int>).GetGenericTypeDefinition() , typeof(Dictionary<int,int>).GetGenericTypeDefinition() },
            { typeof(IEnumerable<>) , typeof(List<>) }
        };

        /// <summary>
        /// AddGenericType
        /// </summary>
        public void AddGenericType(Type interfaceType, Type genericType)
        {
            _dictionary.Add(interfaceType, genericType);
        }

        /// <summary>
        /// Create
        /// </summary>
        public object Create(object request, ISpecimenContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var typeToInvest = GetTypeToInvest(request);

            if (typeToInvest == null) return new NoSpecimen();
            if (!typeToInvest.IsGenericType) return IgnoreType(typeToInvest) ? null : new NoSpecimen();

            return ContainsArgumentsToIgnore(typeToInvest) ? ProcessGenericType(typeToInvest) : new NoSpecimen();
        }

        private bool ContainsArgumentsToIgnore(Type typeToInvest)
        {
            return typeToInvest.GetGenericArguments().Any(IgnoreType);
        }

        private object ProcessGenericType(Type typeToInvest)
        {
            var genType = typeToInvest.GetGenericTypeDefinition();
            return Activator.CreateInstance(genType.IsInterface
                ? _dictionary[genType].MakeGenericType(typeToInvest.GetGenericArguments())
                : typeToInvest);

        }
        private static Type GetTypeToInvest(object request)
        {
            var typeToInvest = (request as PropertyInfo)?.PropertyType;
            if (typeToInvest != null) return typeToInvest;

            var paramInfo = request as ParameterInfo;
            return paramInfo?.ParameterType;
        }

        private bool IgnoreType(Type type)
        {
            return _typesToIgnore.Contains(type);
        }
    }
}
