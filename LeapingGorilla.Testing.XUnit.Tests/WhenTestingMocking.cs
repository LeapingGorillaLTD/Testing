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
using System.Threading.Tasks;
using LeapingGorilla.Testing.Core.Attributes;
using LeapingGorilla.Testing.XUnit.Attributes;
using LeapingGorilla.Testing.XUnit.Tests.Mocks;
using Xunit;

namespace LeapingGorilla.Testing.XUnit.Tests
{
	public class WhenTestingMocking : WhenTestingTheBehaviourOf
	{
		private Exception _setupException;

		[Mock]
#pragma warning disable 649
		private IMockLogger privateFieldMock;
#pragma warning restore 649
		
		[Mock]
		private IMockLogger PrivatePropertyMock { get; set; }

		[Mock]
		public IMockLogger publicFieldMock;

		[Mock]
		public IMockLogger PublicPropertyMock { get; set; }

		[Mock]
		protected IMockLogger protectedFieldMock;

		[Mock]
		protected IMockLogger ProtectedPropertyMock { get; set; }

		public override async Task SetupAsync()
		{
			try
			{
				await base.SetupAsync();
			}
			catch (Exception ex)
			{
				_setupException = ex;
			}
		}

		
		[Then]
		public void PublicFieldMockShouldBeCreated()
		{
			Assert.NotNull(publicFieldMock);
		}

		[Then]
		public void PublicPropertyMockShouldBeCreated()
		{
			Assert.NotNull(PublicPropertyMock);
		}

		[Then]
		public void ProtectedFieldMockShouldBeCreated()
		{
			Assert.NotNull(protectedFieldMock);
		}

		[Then]
		public void ProtectedPropertyMockShouldBeCreated()
		{
			Assert.NotNull(ProtectedPropertyMock);
		}

		[Then]
		public void PrivatePropertyMockShouldBeCreated()
		{
			Assert.NotNull(PrivatePropertyMock);
		}

		[Then]
		public void PrivateFieldMockShouldBeCreated()
		{
			Assert.NotNull(privateFieldMock);
		}

		[Then]
		public void ExceptionShouldNotBeRaised()
		{
			Assert.Null(_setupException);
		}
	}
}
