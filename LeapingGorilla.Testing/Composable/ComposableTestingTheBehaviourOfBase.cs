using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace LeapingGorilla.Testing.Core.Composable
{
    /// <summary>
    /// Base class for implementations using the composable test pattern. Overrides the test setup process to use the
    /// configuration defined in the ComposeTest() method. Mocks and dependencies are still handled by the base
    /// implementation in <see cref="WhenTestingTheBehaviourOfBase"/>
    /// </summary>
    public abstract class ComposableTestingTheBehaviourOfBase : WhenTestingTheBehaviourOfBase
    {
        public override async Task SetupAsync()
        {
            var composedTest = ComposeTest();

            PrepareMocksDependenciesAndItemUnderTest();
            await ExecuteComposedGivenMethods(composedTest.GivenMethods);
            await ExecuteWhenMethod(composedTest.WhenMethod);
        }

        private async Task ExecuteComposedGivenMethods(IEnumerable<MethodInfo> composedTestGivens)
        {
            foreach (var method in composedTestGivens)
            {
                await InvokeMethodAsVoidOrTask(method);
            }
        }

        /// <summary>
        /// Implementations should use the native interface provided by TestComposer to return a <see cref="ComposedTest"/>
        /// instance which allows specifying the test configuration in a BDD style.
        /// </summary>
        /// <returns></returns>
        protected internal abstract ComposedTest ComposeTest();
    }
}