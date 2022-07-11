using LeapingGorilla.Testing.Core.Composable;

namespace LeapingGorilla.Testing.XUnit.Composable
{
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