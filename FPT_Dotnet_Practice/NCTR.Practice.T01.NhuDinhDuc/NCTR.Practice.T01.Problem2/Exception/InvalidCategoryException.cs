using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCTR.Practice.T01.Problem2.Exception
{
	internal class InvalidCategoryException : IOException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidCategoryException"/> class.
		/// </summary>
		/// <param name="message">A <see cref="T:System.String" /> that describes the error. The content of <paramref name="message" /> is intended to be understood by humans. The caller of this constructor is required to ensure that this string has been localized for the current system culture.</param>
		public InvalidCategoryException(string message)
		{
			Console.WriteLine(message);
		}
	}
}