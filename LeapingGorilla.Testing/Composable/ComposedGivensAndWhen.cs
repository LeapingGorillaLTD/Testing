using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using LeapingGorilla.Testing.Core.Attributes;
using LeapingGorilla.Testing.Core.Exceptions;

namespace LeapingGorilla.Testing.Core.Composable
{
    public class ComposedGivensAndWhen
    {
        private List<MethodInfo> _givenMethods = new List<MethodInfo>();
        private readonly MethodInfo _whenMethod;
        
        internal ComposedGivensAndWhen(List<MethodInfo> givenMethods, MethodInfo whenMethod)
        {
            var whenMethodHasWhenAttribute = whenMethod.IsDefined(typeof(WhenAttribute), true);

            if (!whenMethodHasWhenAttribute && TestComposer.ThrowOnValidationFailure)
            {
                throw new ComposedWhenMethodNotDecoratedWithWhenAttributeException(whenMethod.Name);
            }
            
            _givenMethods = givenMethods;
            _whenMethod = whenMethod;
        }

        /// <summary>
        /// Defines a Then assertion method for the test being composed
        /// </summary>
        /// <param name="firstThen">The method to use as a Then action</param>
        /// <returns></returns>
        public ComposedTest Then(Action firstThen)
        {
            return new ComposedTest(_givenMethods, _whenMethod, firstThen.Method);
        }
        
        /// <summary>
        /// Defines a Then assertion method for the test being composed
        /// </summary>
        /// <param name="firstThen">The method to use as a Then action</param>
        /// <returns></returns>
        public ComposedTest Then(Func<Task> firstThen)
        {
            return new ComposedTest(_givenMethods, _whenMethod, firstThen.Method);
        }
    }
}