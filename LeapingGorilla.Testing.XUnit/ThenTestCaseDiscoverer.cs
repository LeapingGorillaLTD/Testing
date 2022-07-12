using System;
using System.Collections.Generic;
using System.Linq;
using LeapingGorilla.Testing.Core.Composable;
using LeapingGorilla.Testing.XUnit.Composable;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace LeapingGorilla.Testing.XUnit
{
    /// <summary>
    /// Custom test case discoverer required to support the Composable BDD pattern.
    /// 
    /// If the test class does not derive from <see cref="ComposableTestingTheBehaviourOf"/>> this will default to all
    /// [Then] cases being run.
    /// Alternatively when the test class does derive from <see cref="ComposableTestingTheBehaviourOf"/> the discoverer
    /// will execute the ComposeTest() method to discover the defined [Then] cases for the test and only include them.
    /// 
    /// WARNING: Be careful if moving this. The type name and namespace is referenced from a string in
    /// <see cref="LeapingGorilla.Testing.XUnit.Attributes.ThenAttribute"/>
    /// </summary>
    public class ThenTestCaseDiscoverer : IXunitTestCaseDiscoverer
    {
        private readonly IMessageSink _messageSink;

        public ThenTestCaseDiscoverer(IMessageSink messageSink)
        {
            _messageSink = messageSink;
        }
        
        public IEnumerable<IXunitTestCase> Discover(ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod,
            IAttributeInfo factAttribute)
        {
            var testClassType = testMethod.TestClass.Class.ToRuntimeType();
            var testClassUsesComposablePattern = testClassType.IsSubclassOf(typeof(ComposableTestingTheBehaviourOf));

            var cases = new List<IXunitTestCase>();
            
            if (testClassUsesComposablePattern)
            {
                TestComposer.ThrowOnValidationFailure = false;
                var testClassInstance = Activator.CreateInstance(testClassType) as ComposableTestingTheBehaviourOf;
                
                var composedTest = testClassInstance.ComposeTest();
                TestComposer.ThrowOnValidationFailure = true;

                if (composedTest.ThenMethods.All(x => x.Name != testMethod.Method.Name))
                {
                    return cases;
                }
            }
            
            cases.Add(new XunitTestCase(_messageSink, TestMethodDisplay.Method, TestMethodDisplayOptions.None, testMethod));
            return cases;
        }
    }
}