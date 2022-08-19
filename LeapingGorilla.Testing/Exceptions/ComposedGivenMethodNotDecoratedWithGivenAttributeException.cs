using System;

namespace LeapingGorilla.Testing.Core.Exceptions
{
    /// <summary>
    /// Exception raised when a method is requested to be used as a Given with the composable BDD test pattern but the
    /// method is not decorated with the [Given] attribute.
    /// </summary>
    public class ComposedGivenMethodNotDecoratedWithGivenAttributeException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComposedGivenMethodNotDecoratedWithGivenAttributeException"/> class.
        /// </summary>
        /// <param name="methodName">Name of the method.</param>
        public ComposedGivenMethodNotDecoratedWithGivenAttributeException(string methodName) :
            base($"The method {methodName} must be marked as [Given] to be used as a Given method with TestComposer")
        {
			
        }
    }
}