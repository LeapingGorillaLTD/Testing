using System;
using System.Threading.Tasks;

namespace LeapingGorilla.Testing.Core.Composable
{
    /// <summary>
    /// Static class exposing a native interface for building up BDD style tests
    /// Example:
    /// TestComposer
    ///     .Given(SomeSetupIsDone)
    ///     .When(AnActionIsPerformed)
    ///     .Then(AnAssertionIsMade)
    ///
    /// This should be used to create the object returned from the ComposeTest() method of a test class deriving from
    /// ComposableTestingTheBehaviourOf.
    ///
    /// The Given/When/Then methods each accept a delegate of Action of Func<Task> representing
    /// parameterless synchronous or asynchronous methods which perform the appropriate behaviour.
    ///
    /// Note: Given/When/Then methods must still be decorated with the corresponding attributes.
    /// </summary>
    public class TestComposer
    {
        /// <summary>
        /// Used by internal code to determine whether an invocation of a test ComposeTest() call is being done during
        /// the test discovery phase or test execution/setup phase.
        /// We don't throw exceptions from the TestComposer if invoked during the test discovery phase as this doesn't
        /// result in any user visible error output.
        /// We do throw exceptions during test setup as the error will be displayed in the test runner output
        /// </summary>
        internal static bool ThrowOnValidationFailure { get; set; } = true;
        
        /// <summary>
        /// Adds a Given precondition for the test being composed
        /// </summary>
        /// <param name="firstGiven">The method to use as a Given</param>
        /// <returns></returns>
        public static ComposedGivens Given(Action firstGiven)
        {
            return new ComposedGivens(firstGiven);
        }
        
        /// <summary>
        /// Adds a Given precondition for the test being composed
        /// </summary>
        /// <param name="firstGiven">The method to use as a Given</param>
        /// <returns></returns>
        public static ComposedGivens Given(Func<Task> firstGiven)
        {
            return new ComposedGivens(firstGiven);
        }        
    }
}