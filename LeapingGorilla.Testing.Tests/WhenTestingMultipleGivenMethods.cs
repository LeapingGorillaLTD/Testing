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
using LeapingGorilla.Testing.NUnit.Attributes;
using NUnit.Framework;

namespace LeapingGorilla.Testing.NUnit.Tests
{
	public class WhenTestingMultipleGivenMethods : WhenTestingTheBehaviourOf
	{
		private int _given1 = -1;
		private int _given2 = -1;
		private int _given3 = -1;

		private int _givenCounter;

		[Given(Order = 3)]
		public void HaveGivenThree()
		{
			_given3 = ++_givenCounter;
		}

		[Given(Order = 1)]
		public void HaveGivenOne()
		{
			_given1 = ++_givenCounter;
		}

		[Given(Order = 2)]
		public void HaveGivenTwo()
		{
			_given2 = ++_givenCounter;
		}

		[Then]
		public void TheCounterShouldBeSetAtThree()
		{
			Assert.That(_givenCounter, Is.EqualTo(3));
		}

		[Then]
		public void Given1ShouldBe1()
		{
			Assert.That(_given1, Is.EqualTo(1));
		}

		[Then]
		public void Given2ShouldBe2()
		{
			Assert.That(_given2, Is.EqualTo(2));
		}

		[Then]
		public void Given3ShouldBe3()
		{
			Assert.That(_given3, Is.EqualTo(3));
		}
	}
}
