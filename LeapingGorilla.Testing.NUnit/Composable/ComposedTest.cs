using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace LeapingGorilla.Testing.NUnit.Composable
{
    public class ComposedTest
    {
        private List<MethodInfo> _thenMethods = new List<MethodInfo>();
        internal ComposedTest(List<MethodInfo> givenMethods, MethodInfo whenMethod, MethodInfo firstThen)
        {
            GivenMethods = givenMethods;
            WhenMethod = whenMethod;
            _thenMethods.Add(firstThen);
        }

        public ComposedTest Then(Action anotherThen)
        {
            _thenMethods.Add(anotherThen.Method);
            return this;
        }
        
        public ComposedTest Then(Func<Task> anotherThen)
        {
            _thenMethods.Add(anotherThen.Method);
            return this;
        }
        
        public ComposedTest And(Action anotherThen)
        {
            _thenMethods.Add(anotherThen.Method);
            return this;
        }
        
        public ComposedTest And(Func<Task> anotherThen)
        {
            _thenMethods.Add(anotherThen.Method);
            return this;
        }

        internal IEnumerable<MethodInfo> GivenMethods { get; }
        internal MethodInfo WhenMethod { get; }
        internal IEnumerable<MethodInfo> ThenMethods => _thenMethods;
    }
}