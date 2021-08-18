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
using LeapingGorilla.Testing.XUnit.Attributes;
using LeapingGorilla.Testing.XUnit.Tests.Mocks;
using Xunit;

namespace LeapingGorilla.Testing.XUnit.Tests
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
			Assert.NotNull(ThrownException);
		}
		
		[Then]
		public void LoggedExceptionShouldBeExpectedType()
		{
			Assert.IsType<ApplicationException>(ThrownException);
		}
		
		[Then]
		public void LoggedExceptionShouldHaveExpectedMessage()
		{
			Assert.Equal(SimpleClassToTest.ExceptionMessage, ThrownException?.Message);
		}

		
	}
}
