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
using LeapingGorilla.Testing.NUnit.Attributes;
using NUnit.Framework;

namespace LeapingGorilla.Testing.NUnit.Tests
{
	public class WhenTestingSetupWithTooManyWhenFields : WhenTestingTheBehaviourOf
	{
		private Exception _setupException;

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

		[When]
		public void WhenOne()
		{
			
		}

		[When]
		public void WhenTwo()
		{
			
		}

		[Then]
		public void SetupShouldThrowAnException()
		{
			Assert.That(_setupException, Is.Not.Null);
		}

		[Then]
		public void SetupExceptionShouldBeAWhenMethodMayOnlyAppearOnceException()
		{
			Assert.That(_setupException, Is.TypeOf<WhenMethodMayOnlyAppearOnceException>());
		}
	}
}
