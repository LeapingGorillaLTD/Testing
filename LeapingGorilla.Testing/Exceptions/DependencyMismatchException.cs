using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LeapingGorilla.Testing.Exceptions
{
	public class DependencyMismatchException : ApplicationException
	{
		public DependencyMismatchException(Type expectedType, string expectedName, int index, IEnumerable<ParameterInfo> allParams) :
			base(
			String.Format(
				"Failed to find an expected dependency. Expected to find a dependency of type {0} with name {1}. Error occurred for parameter {2} in constructor with signature: {3}. Do you have dependencies sharing the same type?",
					expectedType, 
					expectedName, 
					index, 
					String.Join(", ", allParams.Select(pi => String.Format("{0} ({1})", pi.Name, pi.ParameterType)))  )) 
		{
		}
	}
}
