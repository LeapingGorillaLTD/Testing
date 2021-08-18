/*    
   Copyright 2020 Leaping Gorilla LTD

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

using LeapingGorilla.Testing.Core.Attributes;
using LeapingGorilla.Testing.XUnit.Attributes;
using LeapingGorilla.Testing.XUnit.Tests.Mocks;
using Xunit;

namespace LeapingGorilla.Testing.XUnit.Tests
{

    public class ClassWithInternalConstructor
    {
	    public IMockLogger Logger { get;}

        private ClassWithInternalConstructor() { }

        internal ClassWithInternalConstructor(IMockLogger logger)
        {
	        Logger = logger;
        }
    }
    
    public class WhenItemUnderTestHasInternalConstructor : WhenTestingTheBehaviourOf
    {
        [ItemUnderTest]
        public ClassWithInternalConstructor Item;
        
        [Dependency]
        public IMockLogger Logger { get; set; }

        [Then]
        public void SetupShouldCreateClass()
        {
            Assert.NotNull(Item);
        }

        [Then]
        public void LoggerShouldBeAssigned()
        {
	        Assert.NotNull(Item.Logger);
        }

        [Then]
        public void LoggerShouldBeOurMock()
        {
	        Assert.Equal(Logger, Item.Logger);
        }
    }
}
