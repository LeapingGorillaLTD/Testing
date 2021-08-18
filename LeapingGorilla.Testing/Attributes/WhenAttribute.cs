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
	/// Marks a method as being the entry point for a test. This class cannot be inherited.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    [IgnoreXunitAnalyzersRule1013]
	public sealed class WhenAttribute : Attribute
	{
        /// <summary>Should exceptions be rethrown if they are experienced whilst calling the When method?</summary>
        public bool DoNotRethrowExceptions { get; }

        public WhenAttribute() {}

        /// <summary>
        /// Mark a method as the entry point for a test. Also dictate if exceptions from the
        /// When method will be thrown or silently swallowed and written into the <see cref="WhenTestingTheBehaviourOf.ThrownException"/> property
        /// </summary>
        /// <param name="DoNotRethrowExceptions">
        /// If true then execution of the When method will swallow any exceptions that are encountered.
        /// The exception will be written into the <see cref="WhenTestingTheBehaviourOf.ThrownException"/> property
        /// which will be available for you to Assert against. TO override this behaviour either set
        /// <see cref="DoNotRethrowExceptions"/> to false or include a try/catch statement in your When method.
        /// </param>
        public WhenAttribute(bool DoNotRethrowExceptions)
        {
	        this.DoNotRethrowExceptions = DoNotRethrowExceptions;
        }
	}
}
