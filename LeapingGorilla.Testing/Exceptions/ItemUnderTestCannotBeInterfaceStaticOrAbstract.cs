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
	///<summary>
	/// Exception raised if the item marked as [ItemUnderTest] cannot be instantiated. This may be due to the class being abstract or static
	/// or because an Interface was decorated with [ItemUnderTest].
	/// </summary>
	public class ItemUnderTestCannotBeInterfaceStaticOrAbstract : ApplicationException
	{
		/// <summary>
		/// Gets the type under test.
		/// </summary>
		/// <value>The type under test.</value>
		public Type TypeUnderTest { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ItemUnderTestCannotBeInterfaceStaticOrAbstract" /> class.
		/// </summary>
		/// <param name="type">The type.</param>
		public ItemUnderTestCannotBeInterfaceStaticOrAbstract(Type type)
			: base(String.Format("The type {0} which is marked as your [ItemUnderTest] cannot be instantiated. Is it a static or abstract class or possibly an interface?", type))
		{
			TypeUnderTest = type;
		}
	}
}
