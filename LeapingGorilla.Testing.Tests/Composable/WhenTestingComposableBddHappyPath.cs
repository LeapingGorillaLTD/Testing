using System;
using LeapingGorilla.Testing.Core.Attributes;
using LeapingGorilla.Testing.NUnit.Attributes;
using LeapingGorilla.Testing.NUnit.Composable;
using NUnit.Framework;

namespace LeapingGorilla.Testing.NUnit.Tests.Composable;

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
		Assert.Pass();
	}
	
	[Then]
	public void AnotherThingWasCorrect()
	{
		Assert.Pass();
	}

	[Then]
	public void NotActuallyInvoked()
    {
		Assert.Fail();
    }
}