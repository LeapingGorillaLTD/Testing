using System.Threading;
using LeapingGorilla.Testing.Core.Attributes;
using LeapingGorilla.Testing.XUnit.Attributes;
using Xunit;

namespace LeapingGorilla.Testing.XUnit.Tests;

public class WhenTestingSetupOnlyRunsOncePerClass : WhenTestingTheBehaviourOf
{
    public static int SetupCount = 0;

    [Given]
    public void ThereIsSomeSetup()
    {
        // Record that setup has executed
        Interlocked.Increment(ref SetupCount);
    }

    // Order isn't guaranteed but one of these will fail if the setup is executed
    // for each [Then]. This is what happens by default with XUnit where every [Fact] 
    // results in a new instance of the containing class to be created.
    [Then]
    public void FirstThen()
    {
        Assert.Equal(1, SetupCount);
    }

    [Then]
    public void SecondThen()
    {
        Assert.Equal(1, SetupCount);
    }
}