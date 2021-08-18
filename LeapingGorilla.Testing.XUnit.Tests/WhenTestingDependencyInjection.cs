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
	public class WhenTestingDependencyInjection : WhenTestingTheBehaviourOf
	{
		[ItemUnderTest]
		public SimpleClassToTest SimpleClass { get; set; }

		[Dependency]
		public IMockLogger FakeLogger { get; set; }

		[When]
		protected void MyClassRaisesALoggingEvent()
		{
			SimpleClass.MethodThatGeneratesALogMessage();
		}

		[Then]
		public void TheFakeLoggerShouldBeCreated()
		{
			Assert.NotNull(FakeLogger);
		}

		[Then]
		public void WeShouldReceiveACallToLog()
		{
			FakeLogger.Received().Log(Arg.Any<string>());
		}

		[Then]
		public void TheSimpleClassShouldBeCreated()
		{
			Assert.NotNull(SimpleClass);
		}
	}
}
