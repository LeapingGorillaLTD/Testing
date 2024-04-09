/*    
   Copyright 2014-2024 Leaping Gorilla LTD

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LeapingGorilla.Testing.Core.Attributes;
using LeapingGorilla.Testing.Core.Composable;
using LeapingGorilla.Testing.XUnit.Attributes;
using LeapingGorilla.Testing.XUnit.Composable;
using LeapingGorilla.Testing.XUnit.Exceptions;
using LeapingGorilla.Testing.XUnit.XunitExtensions;
using NSubstitute;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace LeapingGorilla.Testing.XUnit.Tests;

/// <summary>
/// Replicates how xUnit invokes tests so we can validate that the correct exception is
/// thrown if a test class is sealed.
/// </summary>
public class WhenTestingASealedTestClass : ComposableTestingTheBehaviourOf
{
    protected override ComposedTest ComposeTest() =>
        TestComposer
            .Given(LeapingGorillaTestInvokerConfiguredToBeInvokedForASealedClass)
            .When(TestIsInvoked)
            .Then(SealedClassExceptionIsThrown);
    
    public ExceptionAggregator ExceptionAggregator { get; set; }
    public LeapingGorillaTestInvoker TestInvoker { get; set; }

    [Given]
    public void LeapingGorillaTestInvokerConfiguredToBeInvokedForASealedClass()
    {
        // Actual setup is performed in CreateManualDependencies() due to
        // the class structure imposed by XunitTestInvoker
    }
		
    [When]
    public async Task TestIsInvoked()
    {
        await TestInvoker.RunAsync();
    }

    [Then]
    public void SealedClassExceptionIsThrown()
    {
        Assert.True(ExceptionAggregator.HasExceptions);
			
        Assert.IsType<TestClassMustNotBeSealedException>(ExceptionAggregator.ToException());
    }

    protected override void CreateManualDependencies()
    {
        // Given the LeapingGorillaTestInvoker is configured to
        // execute a sealed test class (SealedLgTestClass)...
        
        var test = Substitute.For<ITest>(); 
        test.TestCase.Returns(new LeapingGorillaTestCase());
			
        var messageBus = Substitute.For<IMessageBus>();

        var method = typeof(SealedLgTestClass)
            .GetMethods()
            .Single(x => x.Name == "AMethod");

        ExceptionAggregator = new ExceptionAggregator();
			
        TestInvoker = new LeapingGorillaTestInvoker(
            test,
            messageBus,
            typeof(SealedLgTestClass),
            Array.Empty<object>(),
            method,
            Array.Empty<object>(),
            Array.Empty<BeforeAfterTestAttribute>(),
            ExceptionAggregator,
            new CancellationTokenSource());
    }
}

/// <summary>
/// Sealed test class to facilitate the <see cref="WhenTestingASealedTestClass"/> test.
/// Skipped by default so that the failure state doesn't occur. Unskip to see how this
/// presents during a test run.
/// </summary>
public sealed class SealedLgTestClass : WhenTestingTheBehaviourOf
{
    [Then(Skip = "Unskip to see failed state")]
    public void AMethod()
    {
    }
}