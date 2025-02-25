using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionExample.Exceptions
{
	internal class ArrayHandler
	{
		private int[] data;

		public ArrayHandler(int size)
		{
			data = new int[size];
		}

		public void SetElement(int index, int value)
		{
			if (index < 0)
				throw new NegativeIndexException(index);
			if (index >= data.Length)
				throw new IndexOutOfBoundsException(index, data.Length - 1);

			data[index] = value;
			// Console.WriteLine($"{value} assigned to {index}");
		}
	}
}