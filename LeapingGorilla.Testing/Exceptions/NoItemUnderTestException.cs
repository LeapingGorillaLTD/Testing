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

using System;

namespace LeapingGorilla.Testing.Core.Exceptions
{
	///<summary>Exception raised when a class contains fields marked with [Dependency] but no [ItemUnderTest]</summary>
	public class NoItemUnderTestException : ApplicationException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="NoItemUnderTestException"/> class.
		/// </summary>
		public NoItemUnderTestException() : base("This test class does not contain a field or property marked with the [ItemUnderTest] attribute but some fields or properties have been marked with the [Dependency] attribute. You can use the [Mock] attribute if you just need to mock a field or property") {}
	}
}
