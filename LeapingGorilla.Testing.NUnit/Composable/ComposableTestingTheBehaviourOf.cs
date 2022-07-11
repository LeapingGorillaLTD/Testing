using System.Collections.Generic;
using System.Reflection;
using LeapingGorilla.Testing.Core;
using LeapingGorilla.Testing.NUnit.Attributes;
using NUnit.Framework;

namespace LeapingGorilla.Testing.NUnit.Composable
{
    [ComposableBdd]
    public abstract class ComposableTestingTheBehaviourOf : WhenTestingTheBehaviourOfBase
    {
        [OneTimeSetUp]
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

        protected abstract ComposedTest ComposeTest();
    }
}