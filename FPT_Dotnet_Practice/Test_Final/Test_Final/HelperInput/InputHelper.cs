using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Test_Final.HelperInput
{
	public class InputHelper
	{
		public static int ReadInt(string prompt, bool allowZero = false)
		{
			int value;
			while (true)
			{
				Console.Write(prompt);
				string? input = Console.ReadLine();
				if (int.TryParse(input, out value))
				{
					if (!allowZero && value <= 0)
					{
						Console.WriteLine("Please enter a positive integer.");
					}
					else if (value < 0)
					{
						Console.WriteLine("Value cannot be negative.");
					}
					else
					{
						return value;
					}
				}
				else
				{
					Console.WriteLine("Invalid input. Please enter a valid integer.");
				}
			}
		}

		public static decimal ReadDecimal(string prompt)
		{
			decimal value;
			while (true)
			{
				Console.Write(prompt);
				string? input = Console.ReadLine();
				if (decimal.TryParse(input, out value))
				{
					if (value < 0)
					{
						Console.WriteLine("Value cannot be negative.");
					}
					else
					{
						return value;
					}
				}
				else
				{
					Console.WriteLine("Invalid input. Please enter a valid decimal number.");
				}
			}
		}

		/// <summary>
		/// Reads the string.
		/// </summary>
		/// <param name="prompt">The prompt.</param>
		/// <param name="required">if set to <c>true</c> [required].</param>
		/// <returns></returns>
		public static string ReadString(string prompt, bool required)
		{
			while (true)
			{
				Console.Write(prompt);
				string? input = Console.ReadLine();
				if (required && string.IsNullOrWhiteSpace(input))
				{
					Console.WriteLine("This field is required. Please enter a valid value.");
				}
				else if (input != null && input.Length > 100)
				{
					Console.WriteLine("Input is too long. Please limit your input to 100 characters.");
				}
				else
				{
					return input ?? string.Empty;
				}
			}
		}

		/// <summary>
		/// Reads a valid date from the console.
		/// </summary>
		/// <param name="prompt">The prompt message.</param>
		/// <returns>A valid DateTime value.</returns>
		public static DateTime ReadDate(string prompt)
		{
			DateTime value;
			while (true)
			{
				Console.Write(prompt);
				string? input = Console.ReadLine();
				if (DateTime.TryParse(input, out value))
				{
					return value;
				}
				else
				{
					Console.WriteLine("Invalid date. Please enter a valid date (e.g., MM/dd/yyyy).");
				}
			}
		}

		/// <summary>
		/// Reads a valid email address from the console.
		/// </summary>
		/// <param name="prompt">The prompt message.</param>
		/// <param name="required">If true, the field is required.</param>
		/// <returns>A valid email string.</returns>
		public static string ReadEmail(string prompt, bool required)
		{
			while (true)
			{
				Console.Write(prompt);
				string? input = Console.ReadLine();

				if (required && string.IsNullOrWhiteSpace(input))
				{
					Console.WriteLine("This field is required. Please enter a valid email.");
					continue;
				}

				// Nếu không bắt buộc và người dùng không nhập gì, trả về chuỗi rỗng.
				if (string.IsNullOrWhiteSpace(input))
				{
					return string.Empty;
				}

				// Kiểm tra định dạng email bằng cách sử dụng MailAddress.
				try
				{
					MailAddress mail = new MailAddress(input);
					return input;
				}
				catch
				{
					Console.WriteLine("Invalid email format. Please try again.");
				}
			}
		}

		/// <summary>
		/// Reads a valid phone number from the console.
		/// </summary>
		/// <param name="prompt">The prompt message.</param>
		/// <param name="required">If true, the field is required.</param>
		/// <returns>A valid phone number string.</returns>
		public static string ReadPhoneNumber(string prompt, bool required)
		{
			// Ví dụ sử dụng regex cho các số điện thoại với định dạng cho phép dấu cộng, số, khoảng trắng và dấu gạch ngang.
			string pattern = @"^\+?[0-9\s\-]+$";

			while (true)
			{
				Console.Write(prompt);
				string? input = Console.ReadLine();

				if (required && string.IsNullOrWhiteSpace(input))
				{
					Console.WriteLine("This field is required. Please enter a valid phone number.");
					continue;
				}

				// Nếu không bắt buộc và không có dữ liệu, trả về chuỗi rỗng.
				if (string.IsNullOrWhiteSpace(input))
				{
					return string.Empty;
				}

				if (Regex.IsMatch(input, pattern))
				{
					return input;
				}
				else
				{
					Console.WriteLine("Invalid phone number format. Please try again.");
				}
			}
		}
	}
}