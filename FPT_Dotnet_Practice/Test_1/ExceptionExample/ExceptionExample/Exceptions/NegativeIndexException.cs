using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionExample.Exceptions
{
	// Exception when the index is a negative number
	internal class NegativeIndexException : Exception
	{
		public int Index { get; }

		public NegativeIndexException(int index)
			: base($"Index ({index}) can not be smaller than 0")
		{
			Index = index;
		}
	}
}