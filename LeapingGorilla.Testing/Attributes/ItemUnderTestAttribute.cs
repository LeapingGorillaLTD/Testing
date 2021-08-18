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

namespace LeapingGorilla.Testing.Core.Attributes
{
	/// <summary>
	/// Marks the item that is being tested. The property or field decorated with this attribute will be instantiated 
	/// with the best fit constructor that includes as many provided Dependencies as possible using <see cref="DependencyAttribute"/>.
	/// This class cannot be inherited.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    [IgnoreXunitAnalyzersRule1013]
	public sealed class ItemUnderTestAttribute : Attribute
	{
	}
}
