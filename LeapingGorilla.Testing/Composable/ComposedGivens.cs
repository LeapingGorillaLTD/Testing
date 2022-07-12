using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using LeapingGorilla.Testing.Core.Attributes;
using LeapingGorilla.Testing.Core.Exceptions;

namespace LeapingGorilla.Testing.Core.Composable
{
    public class ComposedGivens
    {
        private readonly List<MethodInfo> _givenMethods = new List<MethodInfo>();
        
        /// <summary>
        /// Adds a Given precondition for the test being composed
        /// </summary>
        /// <param name="firstGiven">The method to use as a Given</param>
        /// <returns></returns>
        internal ComposedGivens(Action firstGiven)
        {
            ValidateAndAddGiven(firstGiven.Method);
        }

        internal ComposedGivens(Func<Task> firstGiven)
        {
            ValidateAndAddGiven(firstGiven.Method);
        }
        
        public ComposedGivens Given(Action anotherGiven)
        {
            ValidateAndAddGiven(anotherGiven.Method);
            return this;
        }
        
        /// <summary>
        /// Adds a Given precondition for the test being composed
        /// </summary>
        /// <param name="anotherGiven">The method to use as a Given</param>
        /// <returns></returns>
        public ComposedGivens Given(Func<Task> anotherGiven)
        {
            ValidateAndAddGiven(anotherGiven.Method);
            return this;
        }

        /// <summary>
        /// Adds a Given precondition for the test being composed
        /// </summary>
        /// <param name="anotherGiven">The method to use as a Given</param>
        /// <returns></returns>
        public ComposedGivens And(Action anotherGiven)
        {
            ValidateAndAddGiven(anotherGiven.Method);
            return this;
        }
        
        /// <summary>
        /// Adds a Given precondition for the test being composed
        /// </summary>
        /// <param name="anotherGiven">The method to use as a Given</param>
        /// <returns></returns>
        public ComposedGivens And(Func<Task> anotherGiven)
        {
            ValidateAndAddGiven(anotherGiven.Method);
            return this;
        }

        /// <summary>
        /// Specifies the when action for the test being composed
        /// </summary>
        /// <param name="whenAction">The method to use as the test's When action</param>
        /// <returns></returns>
        public ComposedGivensAndWhen When(Action whenAction)
        {
            return new ComposedGivensAndWhen(_givenMethods, whenAction.Method);
        }
        
        /// <summary>
        /// Specifies the when action for the test being composed
        /// </summary>
        /// <param name="whenAction">The method to use as the test's When action</param>
        /// <returns></returns>
        public ComposedGivensAndWhen When(Func<Task> whenAction)
        {
            return new ComposedGivensAndWhen(_givenMethods, whenAction.Method);
        }

        private void ValidateAndAddGiven(MethodInfo methodInfo)
        {
            var hasGivenAttribute = methodInfo.IsDefined(typeof(GivenAttribute), true);

            if (!hasGivenAttribute && TestComposer.ThrowOnValidationFailure)
            {
                throw new ComposedGivenMethodNotDecoratedWithGivenAttributeException(methodInfo.Name);
            }
            
            _givenMethods.Add(methodInfo);
        }
    }
}