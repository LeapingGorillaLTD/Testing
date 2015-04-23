﻿/*    
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
using System.Linq;
using System.Reflection;
using LeapingGorilla.Testing.Exceptions;
using NSubstitute;

namespace LeapingGorilla.Testing
{
	/// <summary>
	/// Models an injectable dependency in a test class
	/// </summary>
	public class Dependency
	{
		/// <summary>Gets the item for this dependency.</summary>
		/// <value>The passed default value or a generated mock for this dependency.</value>
		public object Value { get; private set; }

		/// <summary>Gets the name of the field that the dependency relates to.</summary>
		/// <value>The name of the field that the dependency relates to.</value>
		public string Name { get; private set; }

		/// <summary>The Type of the dependency.</summary>
		/// <value>The Type of the dependency.</value>
		public Type Type { get; private set; }


		/// <summary>The mocking method we will use for generating fakes and mocks</summary>
		private static readonly MethodInfo MockingMethod = typeof(Substitute)
															.GetMethods()
															.First(m => m.Name == "For" && m.IsGenericMethod && m.GetGenericArguments().Count() == 1);

		/// <summary>
		/// Initializes a new instance of the <see cref="Dependency" /> class.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="dependencyType">Type of the dependency.</param>
		/// <param name="alwaysNull">if set to <c>true</c> the value of this dependency will always be null.</param>
		/// <param name="defaultValue">The default value of the dependency. If null a substitute will be created.</param>
		public Dependency(string name, Type dependencyType, bool alwaysNull = false, object defaultValue = null)
		{
			Name = name;
			Type = dependencyType;

			if (alwaysNull)
			{
				if (dependencyType.IsValueType && (Nullable.GetUnderlyingType(dependencyType)) == null)
				{
					throw new CannotMarkNonNullableTypeAsNullDependencyException(name);
				}

				Value = null;
			}
			else
			{
				Value = defaultValue ?? CreateMock(dependencyType);
			}
		}

		/// <summary>
		/// Creates a mock.
		/// </summary>
		/// <param name="dependencyType">Type of the dependency.</param>
		/// <returns>
		/// Mock of type dependencyType
		/// </returns>
		/// <exception cref="OnlyInterfacesMayBeAutoGeneratedAsDependenciesException">Thrown if dependencyType is not an interface</exception>
		private static object CreateMock(Type dependencyType)
		{
			if (!dependencyType.IsInterface)
			{
				throw new OnlyInterfacesMayBeAutoGeneratedAsDependenciesException(dependencyType);
			}

			var generic = MockingMethod.MakeGenericMethod(dependencyType);
			return generic.Invoke(null, new object[] { null });
		}
	}
}
