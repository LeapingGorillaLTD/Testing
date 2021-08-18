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

using System;
using LeapingGorilla.Testing.Core.Attributes;
using LeapingGorilla.Testing.NUnit.Attributes;
using LeapingGorilla.Testing.NUnit.Tests.Mocks;
using NUnit.Framework;

namespace LeapingGorilla.Testing.NUnit.Tests
{
	public class WhenTestThrowsExceptionAndWeWantToCatch : WhenTestingTheBehaviourOf
	{
		[ItemUnderTest]
		public SimpleClassToTest Item { get; set; }

		[NullDependency]
		public IMockLogger Dependency { get; set; }
		
		[When(DoNotRethrowExceptions: true)]
		public void WeCauseAnException()
		{
			Item.MethodThatThrowsAnException();
		}
		
		[Then]
		public void ExceptionShouldBeLogged()
		{
			Assert.That(ThrownException, Is.Not.Null);
		}
		
		[Then]
		public void LoggedExceptionShouldBeExpectedType()
		{
			Assert.That(ThrownException, Is.TypeOf<ApplicationException>());
		}
		
		[Then]
		public void LoggedExceptionShouldHaveExpectedMessage()
		{
			Assert.That(ThrownException?.Message, Is.EqualTo(SimpleClassToTest.ExceptionMessage));
		}

		
	}
}
