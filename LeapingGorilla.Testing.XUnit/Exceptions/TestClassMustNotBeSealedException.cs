/*    
   Copyright 2014-2024 Leaping Gorilla LTD

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

namespace LeapingGorilla.Testing.XUnit.Exceptions
{
    /// <summary>
    /// Exception raised when a test class using the xUnit version of Leaping Gorilla Testing is
    /// marked as sealed.
    /// Leaping Gorilla testing uses Castle dynamic proxies to support a single test class instance
    /// for the whole scenario. Dynamic proxies cannot be created on sealed classes.
    /// </summary>
    public class TestClassMustNotBeSealedException : Exception
    {
        public TestClassMustNotBeSealedException(string className)
            : base($"The Leaping Gorilla test class {className} cannot be sealed. Sealed test classes can only be used with the NUnit version of the library")
        {
        }
    }
}