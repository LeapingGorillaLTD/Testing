using System;

namespace LeapingGorilla.Testing.Core.Exceptions
{
    /// <summary>
    /// Exception raised when a method is requested to be used as a Then with the composable BDD test pattern but the
    /// method is not decorated with the [Then] attribute.
    /// </summary>
    public class ComposedThenMethodNotDecoratedWithThenAttributeException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComposedThenMethodNotDecoratedWithThenAttributeException"/> class.
        /// </summary>
        /// <param name="methodName">Name of the method.</param>
        public ComposedThenMethodNotDecoratedWithThenAttributeException(string methodName) :
            base($"The method {methodName} must be marked as [Then] to be used as a Then method with TestComposer")
        {
			
        }
    }
}