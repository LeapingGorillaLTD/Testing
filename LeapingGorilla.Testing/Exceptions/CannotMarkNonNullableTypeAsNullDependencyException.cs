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

namespace LeapingGorilla.Testing.Exceptions
{
	/// <summary>
	/// Exception raised if a non-nullable type is marked with a [NullDependency] attribute
	/// </summary>
	public class CannotMarkNonNullableTypeAsNullDependencyException : ApplicationException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CannotMarkNonNullableTypeAsNullDependencyException"/> class.
		/// </summary>
		/// <param name="fieldName">Name of the field.</param>
		public CannotMarkNonNullableTypeAsNullDependencyException(string fieldName)
			: base(String.Format("You may not mark a non-nullable type as a [NullDependency] (Field {0} is incorrectly attributed)", fieldName))
		{
			
		}
	}
}
