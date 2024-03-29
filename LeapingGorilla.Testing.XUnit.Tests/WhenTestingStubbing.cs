﻿/*    
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

using LeapingGorilla.Testing.Core.Attributes;
using LeapingGorilla.Testing.XUnit.Attributes;
using LeapingGorilla.Testing.XUnit.Tests.Mocks;
using NSubstitute;
using Xunit;

namespace LeapingGorilla.Testing.XUnit.Tests
{
	public class WhenTestingStubbing : WhenTestingTheBehaviourOf
	{
		[ItemUnderTest]
		public ClassRaisingAnEvent ClassRaisingEvent { get; set; }

		[Dependency]
		public IMockEventRaiser EventRaiser { get; set; }

		private string _severeResponse;
		private string _nonSevereResponse;

		private string _severeReturn;
		private string _nonSevereReturn;

		[Given]
		protected void TheEventRaiserShouldHaveDifferentReturnsBasedOnTheEventSeverity()
		{
			_severeResponse = "This is a severe response";
			_nonSevereResponse = "This is a non-severe response";

			EventRaiser.RaiseEvent(true).Returns(_severeResponse);
			EventRaiser.RaiseEvent(false).Returns(_nonSevereResponse);
		}

		[When]
		protected void TheEventRaiserRaisesASevereAndNonSevereEvent()
		{
			_severeReturn = ClassRaisingEvent.DoSomethingWithTheEventRaiser(true);
			_nonSevereReturn = ClassRaisingEvent.DoSomethingWithTheEventRaiser(false);
		}

		[Then]
		public void WeShouldHaveASevereReturn()
		{
			Assert.NotNull(_severeReturn);
		}

		[Then]
		public void WeShouldHaveANonSevereReturn()
		{
			Assert.NotNull(_nonSevereReturn);
		}

		[Then]
		public void SevereReturnShouldMatchResponse()
		{
			Assert.Equal(_severeResponse, _severeReturn);
		}

		[Then]
		public void NonSevereReturnShouldMatchResponse()
		{
			Assert.Equal(_nonSevereResponse, _nonSevereReturn);
		}

		[Then]
		public void EventRaiserShouldBeCalledTwice()
		{
			EventRaiser.Received(2).RaiseEvent(Arg.Any<bool>());
		}
	}
}
