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
using NUnit.Framework;

namespace LeapingGorilla.Testing.NUnit.Attributes
{
	/// <summary>
	/// Marks a method as being an assertion about the outcome of a test. This class cannot be inherited.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public sealed class ThenAttribute : TestAttribute
	{
	}
}
