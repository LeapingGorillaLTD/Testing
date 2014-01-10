using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapingGorilla.Testing.Exceptions
{
	public class CannotMockPrivateFieldsException : ApplicationException
	{
		public CannotMockPrivateFieldsException(string fieldName)
			: base(String.Format("You may not mark private Fields or Properties as [Mock] or [Dependency] (Field {0} is incorrectly attributed)", fieldName))
		{
			
		}
	}
}
