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
using LeapingGorilla.Testing.Core.Exceptions;
using LeapingGorilla.Testing.XUnit.Attributes;
using Xunit;

namespace LeapingGorilla.Testing.XUnit.Tests
{
	public class ClassWithNoPublicConstructor
	{
		private ClassWithNoPublicConstructor() {  }

		protected ClassWithNoPublicConstructor(string dummy) { }
	}

	public class WhenItemUnderTestHasNoPublicConstructor : WhenTestingTheBehaviourOf
	{
		[ItemUnderTest]
		public ClassWithNoPublicConstructor BadItem;

		private Exception _setupException;

        public WhenItemUnderTestHasNoPublicConstructor() : base(false)
        {
			Setup();
        }

        public override void Setup()
		{
			try
			{
				base.Setup();
			}
			catch (Exception ex)
			{
				_setupException = ex;
			}
		}

		[Then]
		public void SetupShouldThrowAnException()
		{
			Assert.NotNull(_setupException);
		}

		[Then]
		public void SetupExceptionShouldBeAnItemUnderTestCannotBeInterfaceStaticOrAbstract()
		{
			Assert.IsType<ItemUnderTestMustHavePublicConstructor>(_setupException);
		}
	}
}
