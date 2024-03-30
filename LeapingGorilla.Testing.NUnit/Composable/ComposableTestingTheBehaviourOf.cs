using System.Threading.Tasks;
using LeapingGorilla.Testing.Core.Composable;
using LeapingGorilla.Testing.NUnit.Attributes;
using NUnit.Framework;

namespace LeapingGorilla.Testing.NUnit.Composable
{
    /// <summary>
    /// Base class for NUnit tests using the Composable BDD test pattern.
    ///
    /// Implementors should override the ComposeTest() method and perform other test setup as with
    /// <see cref="WhenTestingTheBehaviourOf"/> tests.
    /// </summary>
    [ComposableBdd]
    public abstract class ComposableTestingTheBehaviourOf : ComposableTestingTheBehaviourOfBase
    {
        [OneTimeSetUp]
        public override async Task SetupAsync()
        {
            await base.SetupAsync();
        }
    }
}