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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LeapingGorilla.Testing.Core.Exceptions
{
	/// <summary>Exception raised when multiple dependencies exist with the same type and the names do not match the constructor.</summary>
	public class DependencyMismatchException : ApplicationException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DependencyMismatchException"/> class.
		/// </summary>
		/// <param name="expectedType">The expected type.</param>
		/// <param name="expectedName">The expected name.</param>
		/// <param name="index">The zero-based index of the parameter in the constructor.</param>
		/// <param name="allParams">All parameters considered for the constructor.</param>
		public DependencyMismatchException(Type expectedType, string expectedName, int index, IEnumerable<ParameterInfo> allParams) :
			base(
			String.Format(
				"Failed to find an expected dependency. Expected to find a dependency of type {0} with name {1}. Error occurred for parameter {2} in constructor with signature: {3}. Do you have dependencies sharing the same type?",
					expectedType, 
					expectedName, 
					index, 
					String.Join(", ", allParams.Select(pi => String.Format("{0} ({1})", pi.Name, pi.ParameterType)).ToArray())  )) 
		{
		}
	}
}
