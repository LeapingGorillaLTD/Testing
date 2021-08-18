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

using System.Threading.Tasks;

namespace LeapingGorilla.Testing.NUnit.Tests.Mocks
{
	public class ClassWithAsyncMethods
	{
		public const int DelayInMilliseconds = 25;

		public Task<int> ReturnSomeNumberPlusOne(int initialNumber)
		{
			return Task.FromResult(initialNumber + 1);
		}
		
		public async Task<int> DelayThenReturnSomeNumberPlusFive(int initialNumber)
		{
			await Task.Delay(DelayInMilliseconds);
			return initialNumber + 5;
		}
	}
}
