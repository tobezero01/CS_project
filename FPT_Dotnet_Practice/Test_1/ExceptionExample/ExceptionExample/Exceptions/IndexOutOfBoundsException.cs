using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionExample.Exceptions
{
	internal class IndexOutOfBoundsException : Exception
	{
		public int Index { get; }
		public int MaxIndex { get; }

		public IndexOutOfBoundsException(int index, int maxIndex)
			: base($"Index ({index}) exceeds bounds of array (0 to {maxIndex})")
		{
			Index = index;
			MaxIndex = maxIndex;
		}
	}
}