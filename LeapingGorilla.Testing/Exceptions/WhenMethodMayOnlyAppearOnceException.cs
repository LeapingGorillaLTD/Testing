using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapingGorilla.Testing.Exceptions
{
	public class WhenMethodMayOnlyAppearOnceException : ApplicationException
	{
		public WhenMethodMayOnlyAppearOnceException(IEnumerable<string> methodNames) :
			base(
			String.Format("Only a single method may be marked with the [When] attribute. You have marked the methods: {0}",
				String.Join(", ", methodNames)))
		{
			
		}
	}
}
