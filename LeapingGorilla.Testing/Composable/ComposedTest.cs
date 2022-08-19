using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using LeapingGorilla.Testing.Core.Exceptions;

namespace LeapingGorilla.Testing.Core.Composable
{
    public class ComposedTest
    {
        private const string NUnitThenAttributeName = "LeapingGorilla.Testing.NUnit.Attributes.ThenAttribute";
        private const string XUnitThenAttributeName = "LeapingGorilla.Testing.XUnit.Attributes.ThenAttribute";
        
        private List<MethodInfo> _thenMethods = new List<MethodInfo>();
        
        internal IEnumerable<MethodInfo> GivenMethods { get; }
        internal MethodInfo WhenMethod { get; }
        internal IEnumerable<MethodInfo> ThenMethods => _thenMethods;
        
        internal ComposedTest(List<MethodInfo> givenMethods, MethodInfo whenMethod, MethodInfo firstThen)
        {
            GivenMethods = givenMethods;
            WhenMethod = whenMethod;
            
            ValidateAndAddThen(firstThen);
        }

        /// <summary>
        /// Defines a Then assertion method for the test being composed
        /// </summary>
        /// <param name="anotherThen">The method to use as a Then action</param>
        /// <returns></returns>
        public ComposedTest Then(Action anotherThen)
        {
            ValidateAndAddThen(anotherThen.Method);
            return this;
        }
        
        /// <summary>
        /// Defines a Then assertion method for the test being composed
        /// </summary>
        /// <param name="anotherThen">The method to use as a Then action</param>
        /// <returns></returns>
        public ComposedTest Then(Func<Task> anotherThen)
        {
            ValidateAndAddThen(anotherThen.Method);
            return this;
        }
        
        /// <summary>
        /// Defines a Then assertion method for the test being composed
        /// </summary>
        /// <param name="anotherThen">The method to use as a Then action</param>
        /// <returns></returns>
        public ComposedTest And(Action anotherThen)
        {
            ValidateAndAddThen(anotherThen.Method);
            return this;
        }
        
        /// <summary>
        /// Defines a Then assertion method for the test being composed
        /// </summary>
        /// <param name="anotherThen">The method to use as a Then action</param>
        /// <returns></returns>
        public ComposedTest And(Func<Task> anotherThen)
        {
            ValidateAndAddThen(anotherThen.Method);
            return this;
        }

        private void ValidateAndAddThen(MethodInfo methodInfo)
        {
            // We have to check the attributes using a string comparison here as this code does not have visibility of
            // the XUnit and NUnit [Then] attributes. If those attributes are renamed/moved without that change being
            // reflected in the type name strings in this class, this validation will start failing.
            var hasThenAttribute = methodInfo
                .CustomAttributes
                .Any(x => 
                    x.AttributeType.FullName == NUnitThenAttributeName || 
                    x.AttributeType.FullName == XUnitThenAttributeName);

            if (!hasThenAttribute && TestComposer.ThrowOnValidationFailure)
            {
                throw new ComposedThenMethodNotDecoratedWithThenAttributeException(methodInfo.Name);
            }
            
            _thenMethods.Add(methodInfo);
        }
    }
}