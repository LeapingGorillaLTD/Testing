using LeapingGorilla.Testing.Core.Composable;

namespace LeapingGorilla.Testing.XUnit.Composable
{
    /// <summary>
    /// Base class for XUnit tests using the Composable BDD test pattern.
    ///
    /// Implementors should override the ComposeTest() method and perform other test setup as with
    /// <see cref="WhenTestingTheBehaviourOf"/> tests.
    /// </summary>
    public abstract class ComposableTestingTheBehaviourOf : ComposableTestingTheBehaviourOfBase
    {
        protected ComposableTestingTheBehaviourOf(bool shouldSetup = true)
        {
            if (shouldSetup)
            {
                base.Setup();
            }
        }
    }
}