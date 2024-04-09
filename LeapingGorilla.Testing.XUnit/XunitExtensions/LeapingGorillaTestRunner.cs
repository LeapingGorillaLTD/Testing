using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace LeapingGorilla.Testing.XUnit.XunitExtensions
{
    /// <summary>
    /// Custom test runner required by <see cref="LeapingGorillaTestCaseRunner" />
    /// Overrides InvokeTestMethodAsync to invoke test method via a <see cref="LeapingGorillaTestInvoker" /> instance
    /// </summary>
    public class LeapingGorillaTestRunner : XunitTestRunner
    {
        public LeapingGorillaTestRunner(ITest test,
            IMessageBus messageBus,
            Type testClass,
            object[] constructorArguments,
            MethodInfo testMethod,
            object[] testMethodArguments,
            string skipReason,
            IReadOnlyList<BeforeAfterTestAttribute> beforeAfterAttributes,
            ExceptionAggregator aggregator,
            CancellationTokenSource cancellationTokenSource) :
            base(test,
                messageBus,
                testClass,
                constructorArguments,
                testMethod,
                testMethodArguments,
                skipReason,
                beforeAfterAttributes,
                aggregator,
                cancellationTokenSource)
        {
        }
        
        protected override Task<Decimal> InvokeTestMethodAsync(ExceptionAggregator aggregator)
        {
            return new LeapingGorillaTestInvoker(Test, MessageBus, TestClass, ConstructorArguments, TestMethod, TestMethodArguments, BeforeAfterAttributes, aggregator, CancellationTokenSource)
                .RunAsync();
        }
    }
}