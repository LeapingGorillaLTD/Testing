using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LeapingGorilla.Testing.Core.Extensions
{
    internal static class TypeExtensions
    {
        internal static IEnumerable<MethodInfo> GetMethodsWithAttribute(this Type classType, Type attributeType) {

            return classType
                .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(mi => mi.IsDefined(attributeType, true));
        }
    }
}