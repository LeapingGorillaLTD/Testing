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

namespace LeapingGorilla.Testing.Attributes
{
	/// <summary>
	/// Marks a method as a Given clause which should be executed in sequence based on Order prior to executing the <see cref="WhenAttribute"/> method. This class cannot be inherited.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public sealed class GivenAttribute : Attribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GivenAttribute"/> class.
		/// </summary>
		public GivenAttribute() {  }

		/// <summary>
		/// Initializes a new instance of the <see cref="GivenAttribute"/> class.
		/// </summary>
		/// <param name="order">The order that this Given task should be executed in.</param>
		public GivenAttribute(int order)
		{
			Order = order;
		}

		/// <summary>
		/// Gets or sets the order in which this task should be executed. Lower numbers are executed first.
		/// </summary>
		/// <value>The order. in which this task should be executed. Lower numbers are executed first.</value>
		public int Order { get; set; }
	}
}
