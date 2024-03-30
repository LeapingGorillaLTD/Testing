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
using LeapingGorilla.Testing.Core.Attributes;
using LeapingGorilla.Testing.Core.Composable;
using LeapingGorilla.Testing.XUnit.Attributes;
using LeapingGorilla.Testing.XUnit.Composable;

namespace LeapingGorilla.Testing.XUnit.Tests.Composable;

public class WhenRunningATestWithFailingSetup : ComposableTestingTheBehaviourOf
{
    protected override ComposedTest ComposeTest() =>
        TestComposer
            .Given(SetupThrowsAnException)
            .When(TheThingIsDone)
            .Then(TestStillShowsAsAFailInTestExplorer);

    [Given]
    public void SetupThrowsAnException()
    {
        throw new Exception("Failing setup!");
    }
    
    [When(true)]
    public void TheThingIsDone()
    {
        Console.WriteLine("When invoked");
    }

    [Then(Skip = "Skipped so that there isn't a failing test in the results")]
    public void TestStillShowsAsAFailInTestExplorer()
    {
        // Must be run manually by removing the skip. This is because the behaviour this test demonstrates
        // necessitates a test failure so can't be included in the regular test run.
        
        // There is no failing assert causing the test failure. The test setup fails which presents as a
        // failure of all the included [Then] methods within the class.
        
        // This test (when not skipped) demonstrates that failures in test setup don't cause the test
        // to disappear from the test explorer. Previously the test setup was executed during [Then]
        // discovery. This resulted in all [Then] methods within the class disappearing from the test
        // explorer if there was an exception thrown from the setup. This behaviour is undesirable as
        // it removes visibility of setup failures and makes debugging more difficult.
    }
}