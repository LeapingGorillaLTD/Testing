/*    
   Copyright 2014-2021 Leaping Gorilla LTD

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

using LeapingGorilla.Testing.Core;

namespace LeapingGorilla.Testing.XUnit
{
    /// <summary>Base class used for writing BDD style Given/When/Then unit tests for a component with simplified mocking semantics</summary>
    public abstract class WhenTestingTheBehaviourOf : WhenTestingTheBehaviourOfBase
	{
        /// <summary>
        /// Performs setup for this instance - this will prepare all mocks, call the [Given]
        /// methods (if any) and then call the [When] methods (if any), ready for your test
        /// assertions
        /// </summary>
        /// <param name="shouldSetup">
        /// Should we perform the setup step? Pass false to skip setup. If you skip setup you will
        /// need to implement it yourself by calling the <see cref="WhenTestingTheBehaviourOfBase.Setup">base.Setup()</see>
        /// method.
        /// </param>
        protected WhenTestingTheBehaviourOf(bool shouldSetup = true)
        {
            if (shouldSetup)
            {
                base.Setup();
            }
        }
	}
}
