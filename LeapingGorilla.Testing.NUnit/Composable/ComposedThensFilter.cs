using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework.Interfaces;

namespace LeapingGorilla.Testing.NUnit.Composable
{
    internal class ComposedThensFilter : IPreFilter
    {
        private readonly IEnumerable<MethodInfo> _composedThens;

        public ComposedThensFilter(IEnumerable<MethodInfo> composedThens)
        {
            _composedThens = composedThens;
        }

        public bool IsMatch(Type type)
        {
            return true;
        }

        public bool IsMatch(Type type, MethodInfo method)
        {
            // HACK:
            // We can't use a == or .Equals() to compare MethodInfo instances here even though this should be correct
            // It is not exactly the same as this issue according to the provided repro but looks very similar
            // https://github.com/dotnet/runtime/issues/6798.
            // MethodHandle represents a pointer to the actual method in memory and it remains equal even if the
            // MethodInfo instances themselves don't evaluate as equal.
            
            return _composedThens.Any(x => x.MethodHandle == method.MethodHandle);
        }
    }
}