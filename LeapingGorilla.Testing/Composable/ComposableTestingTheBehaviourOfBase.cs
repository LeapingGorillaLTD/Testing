using System.Collections.Generic;
using System.Reflection;

namespace LeapingGorilla.Testing.Core.Composable
{
    public abstract class ComposableTestingTheBehaviourOfBase : WhenTestingTheBehaviourOfBase
    {
        public override void Setup()
        {
            var composedTest = ComposeTest();

            PrepareMocksDependenciesAndItemUnderTest();
            ExecuteComposedGivenMethods(composedTest.GivenMethods);
            ExecuteWhenMethod(composedTest.WhenMethod);
        }

        private void ExecuteComposedGivenMethods(IEnumerable<MethodInfo> composedTestGivens)
        {
            foreach (var method in composedTestGivens)
            {
                InvokeMethodAsVoidOrTask(method);
            }
        }

        protected internal abstract ComposedTest ComposeTest();
    }
}