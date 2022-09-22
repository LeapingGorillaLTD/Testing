using LeapingGorilla.Testing.Core.Composable;

namespace LeapingGorilla.Testing.NUnit.Tests.Composable;

/// <summary>
/// Verifies that subclassing works as expected. The previous implementation failed to find the Then methods
/// unless they were in the same class.
///
/// See <see cref="LeapingGorilla.Testing.NUnit.Composable.ComposedThensFilter"/> for more details about the resolution.
/// </summary>
public class WhenTestingComposableBddSubclass : WhenTestingComposableBddHappyPath
{
    protected override ComposedTest ComposeTest() =>
        TestComposer
            .Given(SomeSetupIsPerformed)
            .And(SomeMoreSetupIsPerformed)
            .When(TheThingIsDone)
            .Then(CheckTheThingWasCorrect)
            .And(AnotherThingWasCorrect);
}