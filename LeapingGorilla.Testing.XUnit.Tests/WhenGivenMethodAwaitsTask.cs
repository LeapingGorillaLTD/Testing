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
using LeapingGorilla.Testing.XUnit.Attributes;
using LeapingGorilla.Testing.XUnit.Tests.Mocks;
using Xunit;

namespace LeapingGorilla.Testing.XUnit.Tests
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
			Assert.Equal(4, _newValue);
		}

		[Then]
		public void AsyncClassCreated()
		{
			Assert.NotNull(_classWithAsyncMethods);
		}

		[Then]
		public void AsyncMethodReturnsResult()
		{
			Assert.Equal(8, _newValuePlusFive);
		}

		[Then]
		public void AsyncMethodCorrectlyDelayed()
		{
			Console.WriteLine("Time taken: {0}", _msPassed);
			Assert.True(_msPassed >= ClassWithAsyncMethods.DelayInMilliseconds);
		}
	}
}
