What is it
==========

LeapingGorilla.Testing is an attribute based framework for BDD style Given/When/Then unit testing without the ceremony.

Getting It
==========

The LeapingGorilla.Testing is now available on NuGet. Get it using:

```PowerShell
PM> install-package LeapingGorilla.Testing
```

Philosophy
==========

We at Leaping Gorilla strive to remove as much friction as possible from our testing methodology. To that end we wanted a drop dead simple way to create unit tests that adhered to a few core principles:

1. Must support constructor-based dependency injection
2. Must have the ability to automatically mock any dependencies we wish to use with our item under test
3. Must have the ability to override automatic mocking should the need arise
4. Must support a clean syntax for stubbing method calls on our depndencies
5. Must have a clean BDD style Given/When/Then flow

From these needs LeapingGorilla.Testing was born.

Technology
==========

LeapingGorilla.Testing builds on the shoulders of giants. We use [NUnit](http://www.nunit.org/) as our core testing framework, [NSubstitute](http://nsubstitute.github.io/) performs mocking duties and [Fast-member](http://code.google.com/p/fast-member/) provides quick reflective access to members on our classes.

Enough of the introductions, lets look at how it works.

Quick Sample
============

```CSHARP
public class WhenTestingStubbing : WhenTestingTheBehaviourOf
{
  [ItemUnderTest]
  public ClassRaisingAnEvent ClassRaisingEvent { get; set; }

  [Dependency]
  public IMockEventRaiser EventRaiser { get; set; }

  private string _severeResponse;
  private string _nonSevereResponse;

  private string _severeReturn;
  private string _nonSevereReturn;

  [Given]
  protected void TheEventRaiserShouldHaveDifferentReturnsBasedOnTheEventSeverity()
  {
    _severeResponse = "This is a severe response";
    _nonSevereResponse = "This is a non-severe response";

    EventRaiser.RaiseEvent(true).Returns(_severeResponse);
    EventRaiser.RaiseEvent(false).Returns(_nonSevereResponse);
  }

  [When]
  protected void TheEventRaiserRaisesASevereAndNonSevereEvent()
  {
    _severeReturn = ClassRaisingEvent.DoSomethingWithTheEventRaiser(true);
    _nonSevereReturn = ClassRaisingEvent.DoSomethingWithTheEventRaiser(false);
  }

  [Then]
  public void SevereReturnShouldMatchResponse()
  {
    Assert.That(_severeReturn, Is.EqualTo(_severeResponse));
  }

  [Then]
  public void NonSevereReturnShouldMatchResponse()
  {
    Assert.That(_nonSevereReturn, Is.EqualTo(_nonSevereResponse));
  }

  [Then]
  public void EventRaiserShouldBeCalledTwice()
  {
    EventRaiser.Received(2).RaiseEvent(Arg.Any<bool>());
  }
}
```

Here you can see the attribute led style that LeapingGorilla.Testing uses to make testing painless. We start with the concept of an ```ItemUnderTest```. This is the concrete instance that the framework will create for us. This concrete instance has dependencies injected via the constructor - in this case an ```IMockEventRaiser```. We mark a property of this with a ```DependencyAttribute``` and we're good to go. 

LeapingGorilla.Testing starts by locating all of our Dependencies, creating a mock of each and loading them into the test class. Next it finds the item under test, finds the constructor that best matches our dependencies and then creates an instance of the item under test passing the dependencies into the constructor and loads it into the test class. 

From here we look for any methods marked with a ```GivenAttribute```. You can have as many Given methods as you want (zero, one or more). LeapingGorilla.Testing will find and execute each in turn. The order it will do so is undefined so if you need to be specific on the order that we call them use the optional Order property like:

```CSHARP
[Given(Order = 1)]
```

You should use your ```Given``` methods to setup your stubbing in dependencies. We leverage NSubstitute for this so take a look at [the NSubstitute website](http://nsubstitute.github.io/). With our given methods executed the framework then finds your optional ```When``` method. You may have zero or one method marked with a ```WhenAttribute```. If one is found it will be called and at this point we hand over to the NUnit framework to assert each of yor test cases. 

NUnit will find all public methods marked with a ```ThenAttribute``` and run each of them as an individual test. It's best practice to avoid modifying any state in your ```Then``` tests - you can't guarantee the order they will run in so it's easy to trip yourself up.

My First Test
=============

1. Create a new test class inheriting from ```WhenTestingTheBehaviourOf```
2. Add a property to the class you want to test, mark it with an ```ItemUnderTest``` attribute
3. If your item under test has any dependencies to inject in the constructor, add a property for each with a ```Dependency``` attribute.
4. If you need to do any test setup (stubbing dependency methods, preparing input parameters or expected output parameters) create a method to do so and mark it with a ```Given``` attribute. To make life easier you can split your setup into multiple ```Given``` methods for readability.
5. If your test needs to call any functionality on your item under test create a method to do so and mark it with a ```When``` attribute.
6. Create as many public void methods as necessary to assert that your item under test has performed as expected. Mark each with a ```Then``` attribute and add what ```Assert``` statements you need.

FAQ
===

####Q: How do I provide my own dependencies?
A: Override the ```CreateManualDependencies``` method and assign them from there

####Q: How can I mock an item that I need for my test but is not a dependency?
A: Mark it with a ```Mock``` attribute

####Q: Why can I only have a single ```When``` method?
A: Convention. At Leaping Gorilla we stick to the rule that each test class tests a single behaviour. If a behaviour can't be expressed as a single "When I  X" then we take it as a sign that our code probably needs refactoring.

####Q: How do I control the ordering of my ```Given``` methods?
A: Use the optional ```Order``` property at the point of decoration like:

```CSHARP
[Given(Order=2)] 
```

####Q: How do I mock a dependency that is a concrete class?
A: The short answer is: You can't. The longer answer is: you can override the ```CreateManualDependencies``` method and substitute your own mock object there but we cannot generate an automatic mock. This is down to the nature of the .Net framework and short of using an expensive tool like TypeMock or JustMock itisn't going to change. Take it instead as an opportunity to do some glorious refactoring to break that concrete dependency into an interface.

####Q: How do I test an async method?
A: Make sure that your method returns Task, not void and it will Just Work (tm) like:

```CSHARP
[When]
public async Task SomethingAsyncHappens()
{
  _result = await MyAsyncThing();
}
```

####Q: How do I contribute?
A: Fork and submit a pull request! For your pull request to be considered it should include tests as well as functional code. 

####Q: What license do you distribute the framework under?
A: LeapingGorilla.Testing is made available under the [Apache 2.0 License](http://www.apache.org/licenses/LICENSE-2.0). You are free to use the software in any way you choose as long as you adhere to the license.

####Q: Do you provide any support for implementation?
A: We are open to talk with you or your business! Drop us a line via our [contact form](http://www.leapinggorilla.com/Home/Contact).
