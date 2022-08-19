using System;
using LeapingGorilla.Testing.Core.Attributes;
using LeapingGorilla.Testing.Core.Composable;
using LeapingGorilla.Testing.XUnit.Attributes;
using LeapingGorilla.Testing.XUnit.Composable;
using Xunit;

namespace LeapingGorilla.Testing.XUnit.Tests.Composable;

public class WhenTestingComposableBddHappyPath : ComposableTestingTheBehaviourOf
{
	protected override ComposedTest ComposeTest() => 
		TestComposer
			.Given(SomeSetupIsPerformed)
			.And(SomeMoreSetupIsPerformed)
			.When(TheThingIsDone)
			.Then(CheckTheThingWasCorrect)
			.And(AnotherThingWasCorrect);

	[Given]
	public void SomeSetupIsPerformed()
	{
		Console.WriteLine("First Given");
	}
    
	[Given]
	public void SomeMoreSetupIsPerformed()
	{
		Console.WriteLine("Second Given");
	}
	
	[When]
	public void TheThingIsDone()
	{
	    Console.WriteLine("When invoked");
	}
	
	[Then]
	public void CheckTheThingWasCorrect()
	{
		Assert.True(true);
	}
	
	[Then]
	public void AnotherThingWasCorrect()
	{
		Assert.True(true);
	}

	[Then]
	public void NotActuallyInvoked()
    {
		Assert.True(false);
    }
}