/*    
   Copyright 2014 Leaping Gorilla LTD

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

namespace LeapingGorilla.Testing.Exceptions
{
	public class NoMatchingConstructorFoundException : ApplicationException
	{
#if NET45
		public NoMatchingConstructorFoundException(IReadOnlyCollection<Dependency> expectedDependencies) : 
#else
		public NoMatchingConstructorFoundException(ICollection<Dependency> expectedDependencies) : 
#endif
			base(
				String.Format("No constructor could be found with the correct number of parameters which have types matching the [Dependency] attributes in the test class.{0}{0}Expected Constructor For {1} Dependencies:{0}------------{0}{2}", 
					/* 0 */		Environment.NewLine,
					/* 1 */		expectedDependencies.Count,
					/* 2 */		String.Join(", ", expectedDependencies.Select(d => String.Format("{0} ({1})", d.Name, d.Type)).ToArray())  ))
		{

		}
	}
}
