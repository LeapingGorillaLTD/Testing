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
using LeapingGorilla.Testing.Core.Attributes;
using Xunit;
using Xunit.Sdk;

namespace LeapingGorilla.Testing.XUnit.Attributes
{
	/// <summary>
	/// Marks a method as being an assertion about the outcome of a test. This class cannot be inherited.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    [IgnoreXunitAnalyzersRule1013]
	[XunitTestCaseDiscoverer(typeName:"LeapingGorilla.Testing.XUnit.ThenTestCaseDiscoverer", assemblyName: "LeapingGorilla.Testing.XUnit")]
	public sealed class ThenAttribute : FactAttribute
	{
	}
}
