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

namespace LeapingGorilla.Testing.Core.Exceptions
{
	///<summary>Exception raised when a Given method exists which takes a parameter</summary>
	public class GivenMethodMayNotHaveParametersException : ApplicationException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GivenMethodMayNotHaveParametersException"/> class.
		/// </summary>
		/// <param name="methodName">Name of the method.</param>
		public GivenMethodMayNotHaveParametersException(string methodName) :
			base(String.Format("The method {0} may not be marked as [Given] - All [Given] methods must not take any parameters", methodName))
		{
			
		}
	}
}
