Composable Tests
================

Composable BDD tests is a new addition to LeapingGorilla.Testing to attempt to address some issues that can arise as test complexity increases.

To share test setup and assertion code when using LeapingGorilla.Testing it is normal to use inheritance to achieve this. This is ok up to a point but can get complex as more shared code is added. This typically ends up with a choice between copying and pasting a subset of the [Given] and [Then] methods or building increasingly complex type hierarchies with virtual methods and special case overrides.

Neither of these approaches is ideal and the composable test pattern tries to offer an additional option to avoid the compromises described above. The composable pattern can be used in addition to the existing LeapingGorilla.Testing features.

How To Use It
-------------
Composable BDD tests are set up like any other LeapingGorilla.Testing test with two small differences:
1. The test should inherit from `ComposableTestingTheBehaviourOf`
2. The test must provide an implementation of `ComposeTest()`
   * This method should return a `ComposedTest` instance which can be constructed using the native interface provided by `TestComposer`

Example ComposeTest() implementation:
```csharp
protected override ComposedTest ComposeTest() => 
    TestComposer
        .Given(SomeSetupIsPerformed)
        .And(SomeMoreSetupIsPerformed)
        .When(TheThingIsDone)
        .Then(CheckTheThingWasCorrect)
        .And(AnotherThingWasCorrect);
```

Once using `ComposableTestingTheBehaviourOf`, methods with the Given/When/Then BDD attributes are no longer executed automatically during a test run. A test must explicitly define the included methods when composing the test.

**Note:** Given/When/Then methods currently still require the corresponding attribute on the method. This makes the classes containing behaviours more readable without cross referencing `ComposeTest()` methods.

Benefits
--------
* Readability - When using complex test type hierarchies, it can be difficult to follow the flow of the test setup and assertions. Composable BDD tests contain an explicit BDD-style test setup statement defining all of the test behaviour in one place.
* Implicit ordering - Methods defined as Given execute in the order they are specified during test composition. This avoids the need to override execution order with the Given attribute's order parameter
* Simplified inheritance hierarchies - Inheritance can still be used organise behaviours shared between related tests. However because every [Given] and [Then] method is no longer automatically included in a particular test, it allows for a simplified structure where more complex overrides would have been required before.

