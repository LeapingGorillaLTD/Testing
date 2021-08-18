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
using System.Diagnostics;
using System.Threading.Tasks;
using LeapingGorilla.Testing.Core.Attributes;
using LeapingGorilla.Testing.NUnit.Attributes;
using LeapingGorilla.Testing.NUnit.Tests.Mocks;
using NUnit.Framework;

namespace LeapingGorilla.Testing.NUnit.Tests
{
	public class WhenGivenMethodAwaitsTask : WhenTestingTheBehaviourOf
	{
		private int _newValue;
		private int _newValuePlusFive;
		private long _msPassed;
		private ClassWithAsyncMethods _classWithAsyncMethods;

		[Given(0)]
		public void WeHaveClassWithAsyncMethods()
		{
			_classWithAsyncMethods = new ClassWithAsyncMethods();
		}

		[Given(1)]
		public async Task WeCanAwaitMethod()
		{
			_newValue = await _classWithAsyncMethods.ReturnSomeNumberPlusOne(3);
		}

		[Given(1)]
		public async Task WeCanAwaitAsyncMethod()
		{
			var sw = Stopwatch.StartNew();
			_newValuePlusFive = await _classWithAsyncMethods.DelayThenReturnSomeNumberPlusFive(3);
			_msPassed = sw.ElapsedMilliseconds;
		}

		[Then]
		public void NewValueUpdated()
		{
			Assert.That(_newValue, Is.EqualTo(4));
		}

		[Then]
		public void AsyncClassCreated()
		{
			Assert.That(_classWithAsyncMethods, Is.Not.Null);
		}

		[Then]
		public void AsyncMethodReturnsResult()
		{
			Assert.That(_newValuePlusFive, Is.EqualTo(8));
		}

		[Then]
		public void AsyncMethodCorrectlyDelayed()
		{
			Console.WriteLine("Time taken: {0}", _msPassed);
			Assert.That(_msPassed, Is.GreaterThanOrEqualTo(ClassWithAsyncMethods.DelayInMilliseconds));
		}
	}
}
