using LeapingGorilla.Testing.Core.Composable;
using LeapingGorilla.Testing.NUnit.Attributes;
using NUnit.Framework;

namespace LeapingGorilla.Testing.NUnit.Composable
{
    [ComposableBdd]
    public abstract class ComposableTestingTheBehaviourOf : ComposableTestingTheBehaviourOfBase
    {
        [OneTimeSetUp]
        public override void Setup()
        {
            base.Setup();
        }
    }
}