using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace LeapingGorilla.Testing.XUnit.XunitExtensions
{
    /// <summary>
    /// Custom test case class derived from XunitTestCase. This is required so that we can create a
    /// chain of custom overrides that culminates in <see cref="LeapingGorillaTestInvoker"/>.
    /// It also keeps a record of all the test methods in the associated test class which is required
    /// for lifecycle management behaviour that is overriden.
    /// </summary>
    public class LeapingGorillaTestCase : XunitTestCase
    {
        public LeapingGorillaTestCase(IMessageSink diagnosticMessageSink,
            TestMethodDisplay defaultMethodDisplay,
            TestMethodDisplayOptions defaultMethodDisplayOptions,
            ITestMethod testMethod,
            IEnumerable<MethodInfo> allTestMethodsInClass) : 
                base(
                    diagnosticMessageSink,
                    defaultMethodDisplay,
                    defaultMethodDisplayOptions,
                    testMethod)
        {
            AllTestMethodsInClass = allTestMethodsInClass;
        }

        public IEnumerable<MethodInfo> AllTestMethodsInClass { get; private set; }

        public override Task<RunSummary> RunAsync(IMessageSink diagnosticMessageSink, IMessageBus messageBus, object[] constructorArguments,
            ExceptionAggregator aggregator, CancellationTokenSource cancellationTokenSource)
        {
            return new LeapingGorillaTestCaseRunner(this, this.DisplayName, this.SkipReason, constructorArguments, this.TestMethodArguments, messageBus, aggregator, cancellationTokenSource).RunAsync();
        }

#pragma warning disable CS0618 // Type or member is obsolete - Obsolete inherited from xUnit base class
        public LeapingGorillaTestCase() : base()
        {
        }
#pragma warning restore CS0618 // Type or member is obsolete
    }
}