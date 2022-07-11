using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace LeapingGorilla.Testing.Core.Composable
{
    public class ComposedGivens
    {
        private readonly List<MethodInfo> _givenMethods = new List<MethodInfo>();
        
        internal ComposedGivens(Action firstGiven)
        {
            _givenMethods.Add(firstGiven.Method);
        }
        
        internal ComposedGivens(Func<Task> firstGiven)
        {
            _givenMethods.Add(firstGiven.Method);
        }
        
        public ComposedGivens Given(Action anotherGiven)
        {
            _givenMethods.Add(anotherGiven.Method);
            return this;
        }
        
        public ComposedGivens Given(Func<Task> anotherGiven)
        {
            _givenMethods.Add(anotherGiven.Method);
            return this;
        }

        public ComposedGivens And(Action anotherGiven)
        {
            _givenMethods.Add(anotherGiven.Method);
            return this;
        }
        
        public ComposedGivens And(Func<Task> anotherGiven)
        {
            _givenMethods.Add(anotherGiven.Method);
            return this;
        }

        public ComposedGivensAndWhen When(Action whenAction)
        {
            return new ComposedGivensAndWhen(_givenMethods, whenAction.Method);
        }
        
        public ComposedGivensAndWhen When(Func<Task> whenAction)
        {
            return new ComposedGivensAndWhen(_givenMethods, whenAction.Method);
        }
    }
}