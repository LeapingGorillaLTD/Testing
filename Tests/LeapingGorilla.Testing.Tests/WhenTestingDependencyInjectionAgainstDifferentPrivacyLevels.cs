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
using LeapingGorilla.Testing.Attributes;
using LeapingGorilla.Testing.Tests.Mocks;
using NUnit.Framework;

namespace LeapingGorilla.Testing.Tests
{
	public class WhenTestingDependencyInjectionAgainstDifferentPrivacyLevels : WhenTestingTheBehaviourOf
	{
		[Mock]
		public IMockLogger PublicProp { get; set; }

		[Mock]
		protected IMockLogger ProtectedProp { get; set; }

		[Mock]
		private IMockLogger PrivateProp { get; set; }

		[Mock]
		public IMockLogger PublicField;

		[Mock]
		protected IMockLogger ProtectedField;

		[Mock]
		private IMockLogger _privateField;
		
		[Then]
		public void PublicPropertyShouldBeMocked()
		{
			Assert.That(PublicProp, Is.Not.Null);
		}

		[Then]
		public void ProtectedPropertyShouldBeMocked()
		{
			Assert.That(ProtectedProp, Is.Not.Null);
		}

		[Then]
		public void PrivatePropertyShouldBeMocked()
		{
			Assert.That(PrivateProp, Is.Not.Null);
		}

		[Then]
		public void PublicFieldShouldBeMocked()
		{
			Assert.That(PublicField, Is.Not.Null);
		}

		[Then]
		public void ProtectedFieldShouldBeMocked()
		{
			Assert.That(ProtectedField, Is.Not.Null);
		}

		[Then]
		public void PrivateFieldShouldBeMocked()
		{
			Assert.That(_privateField, Is.Not.Null);
		}
	}
}
