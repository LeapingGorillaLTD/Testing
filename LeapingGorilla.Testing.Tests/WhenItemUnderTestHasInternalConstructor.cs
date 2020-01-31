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
