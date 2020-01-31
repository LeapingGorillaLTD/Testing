using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeapingGorilla.Testing.Attributes;
using LeapingGorilla.Testing.Exceptions;
using LeapingGorilla.Testing.Tests.Mocks;
using NUnit.Framework;

namespace LeapingGorilla.Testing.Tests
{

    public class ClassWithInternalConstructor
    {
        private ClassWithInternalConstructor() { }

        internal ClassWithInternalConstructor(IMockLogger logger) { }
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
    }
}
