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
using System.Collections.Generic;
using System.Linq;

namespace LeapingGorilla.Testing.Core.Exceptions
{
	///<summary>Exception raised if a class contains multiple [When] methods. This includes sub-classes</summary>
	public class WhenMethodMayOnlyAppearOnceException : ApplicationException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="WhenMethodMayOnlyAppearOnceException"/> class.
		/// </summary>
		/// <param name="methodNames">The method names marked with the WhenAttribute.</param>
		public WhenMethodMayOnlyAppearOnceException(IEnumerable<string> methodNames) :
			base(
			String.Format("Only a single method may be marked with the [When] attribute. You have marked the methods: {0}",
				String.Join(", ", methodNames.ToArray())))
		{
			
		}
	}
}
