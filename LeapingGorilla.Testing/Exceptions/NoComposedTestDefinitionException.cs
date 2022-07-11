using System;

namespace LeapingGorilla.Testing.Core.Exceptions
{
    public class NoComposedTestDefinitionException : ApplicationException
    {
        public NoComposedTestDefinitionException()
            : base(
                "The ComposeTest() method for this composable test returned null. It must return a ComposedTest object. This can be created using the fluent BDD syntax exposed by TestComposer")
        {
        }
    }
}