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
            return _composedThens.Any(x => x == method);
        }
    }
}