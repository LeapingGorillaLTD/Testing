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

using LeapingGorilla.Testing.Core.Attributes;
using LeapingGorilla.Testing.XUnit.Attributes;
using Xunit;

namespace LeapingGorilla.Testing.XUnit.Tests
{
	public class WhenTestingMultipleGivenMethodsUsingTheAttributeConstructor : WhenTestingTheBehaviourOf
	{
		private int _given1 = -1;
		private int _given2 = -1;
		private int _given3 = -1;

		private int _givenCounter;

		[Given(3)]
		public void HaveGivenThree()
		{
			_given3 = ++_givenCounter;
		}

		[Given(1)]
		public void HaveGivenOne()
		{
			_given1 = ++_givenCounter;
		}

		[Given(2)]
		public void HaveGivenTwo()
		{
			_given2 = ++_givenCounter;
		}

		[Then]
		public void TheCounterShouldBeSetAtThree()
		{
			Assert.Equal(3, _givenCounter);
		}

		[Then]
		public void Given1ShouldBe1()
		{
			Assert.Equal(1, _given1);
		}

		[Then]
		public void Given2ShouldBe2()
		{
			Assert.Equal(2, _given2);
		}

		[Then]
		public void Given3ShouldBe3()
		{
			Assert.Equal(3, _given3);
		}
	}
}
