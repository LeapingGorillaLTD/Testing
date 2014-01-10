using System;
using System.Collections.Generic;
using System.Linq;

namespace LeapingGorilla.Testing.Exceptions
{
	public class NoMatchingConstructorFoundException : ApplicationException
	{
		public NoMatchingConstructorFoundException(IReadOnlyCollection<Dependency> expectedDependencies) : 
			base(
				String.Format("No constructor could be found with the correct number of parameters which have types matching the [Dependency] attributes in the test class.{0}{0}Expected Constructor For {1} Dependencies:{0}------------{0}{2}", 
					/* 0 */		Environment.NewLine,
					/* 1 */		expectedDependencies.Count,
					/* 2 */		String.Join(", ", expectedDependencies.Select(d => String.Format("{0} ({1})", d.Name, d.Type)))  ))
		{

		}
	}
}
