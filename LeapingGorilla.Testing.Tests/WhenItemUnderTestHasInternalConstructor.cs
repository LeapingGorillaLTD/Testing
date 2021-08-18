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
using LeapingGorilla.Testing.NUnit.Attributes;
using LeapingGorilla.Testing.NUnit.Tests.Mocks;
using NUnit.Framework;

namespace LeapingGorilla.Testing.NUnit.Tests
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
            Assert.That(Item, Is.Not.Null);
        }

        [Then]
        public void LoggerShouldBeAssigned()
        {
	        Assert.That(Item.Logger, Is.Not.Null);
        }

        [Then]
        public void LoggerShouldBeOurMock()
        {
	        Assert.That(Item.Logger, Is.EqualTo(Logger));
        }
    }
}
