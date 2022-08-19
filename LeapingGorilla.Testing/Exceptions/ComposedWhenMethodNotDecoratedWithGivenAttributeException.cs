using System;

namespace LeapingGorilla.Testing.Core.Exceptions
{
    /// <summary>
    /// Exception raised when a method is requested to be used as a When with the composable BDD test pattern but the
    /// method is not decorated with the [When] attribute.
    /// </summary>
    public class ComposedWhenMethodNotDecoratedWithWhenAttributeException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComposedWhenMethodNotDecoratedWithWhenAttributeException"/> class.
        /// </summary>
        /// <param name="methodName">Name of the method.</param>
        public ComposedWhenMethodNotDecoratedWithWhenAttributeException(string methodName) :
            base($"The method {methodName} must be marked as [When] to be used as a When method with TestComposer")
        {
			
        }
    }
}