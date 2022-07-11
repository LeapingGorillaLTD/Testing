using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace LeapingGorilla.Testing.Core.Composable
{
    public class ComposedGivensAndWhen
    {
        private List<MethodInfo> _givenMethods = new List<MethodInfo>();
        private readonly MethodInfo _whenMethod;
        
        internal ComposedGivensAndWhen(List<MethodInfo> givenMethods, MethodInfo whenAction)
        {
            _givenMethods = givenMethods;
            _whenMethod = whenAction;
        }

        public ComposedTest Then(Action firstThen)
        {
            return new ComposedTest(_givenMethods, _whenMethod, firstThen.Method);
        }
        
        public ComposedTest Then(Func<Task> firstThen)
        {
            return new ComposedTest(_givenMethods, _whenMethod, firstThen.Method);
        }
    }
}