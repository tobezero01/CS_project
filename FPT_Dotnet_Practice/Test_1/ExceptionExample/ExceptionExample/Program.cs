using ExceptionExample.Exceptions;
using System.Text;

// NGuyen tien dat

// Lại Văn Hùng
internal class Program
{
	private static void Main(string[] args)
	{
		Console.OutputEncoding = Encoding.UTF8;
		//  Don't use them to communicate events that are expected, such as reaching
		//the end of a file.
		// wrong
		//try
		//{
		//	StreamReader reader = new StreamReader(@"D:\A_practice\file.txt");
		//	while (true)
		//	{
		//		int c = reader.Read(); // Đọc ký tự từ tệp
		//		if (c == -1)
		//			throw new EndOfStreamException("Đã đến cuối tệp"); // Ném ngoại lệ khi đến cuối tệp
		//		Console.Write((char)c); // Hiển thị ký tự đọc được
		//	}
		//}
		//catch (EndOfStreamException ex)
		//{
		//	Console.WriteLine(ex.Message); // Xử lý ngoại lệ khi đến cuối tệp
		//}
		//catch (IOException ex)
		//{
		//	Console.WriteLine("Lỗi I/O: " + ex.Message); // Xử lý lỗi khác liên quan đến tệp
		//}

		// true
		//StreamReader reader = new StreamReader(@"D:\A_practice\file.txt");
		//while (reader.Peek() >= 0)  // Kiểm tra nếu còn dữ liệu trong tệp
		//{
		//	char c = (char)reader.Read();
		//	// Xử lý ký tự
		//}
		//reader.Close();

		//  If there's a good predefined exception in the System namespace that
		//describes the exception condition (one that will make sense to the users of
		//the class) use that one rather than defining a new exception class, and put
		//specific information in the message.

		//try
		//{
		//	int[] array = new int[2];
		//	int value = array[5];  // Cố gắng truy cập chỉ số không hợp lệ
		//}
		//catch (IndexOutOfRangeException ex)
		//{
		//	Console.WriteLine($"Lỗi: {ex.Message}. Kích thước mảng: 2, Chỉ số đã thử: 5");
		//}

		// do not catch exceptions that you cannot handle
		// wrong
		//try
		//{
		//	int intNumber = int.Parse("abc");
		//}
		//catch (Exception ex)
		//{
		//	Console.WriteLine("Cannot convert the string to " + "a number: " + ex.Message);
		//}

		// true
		//try
		//{
		//	int intNumber = int.Parse("abc");
		//}
		//catch (ArgumentException ex)
		//{
		//	System.Console.WriteLine(@"input is null");
		//}
		//catch (FormatException ex)
		//{
		//	System.Console.WriteLine(@"Incorrect format");
		//}

		// use validation code to avoid unnecessary exceptions
		// first

		// double result = 0;
		// try
		// {
		//     result = 10 / int.Parse("0");
		// }
		// catch (System.Exception ex)
		// {
		//     result = System.Double.NaN;
		// }
		// System.Console.WriteLine(result);

		//  more efficient
		//double result = 0, divisor = 0;
		//if (divisor != 0)
		//{
		//	result = 10 / divisor;
		//}
		//else
		//{
		//	result = System.Double.NaN;
		//}
		//System.Console.WriteLine(result);

		// do not use exceptions to control application flow
		// sai
		// int x = -1;
		// try
		// {
		//     if (x < 0)
		//         throw new InvalidOperationException("Giá trị không hợp lệ.");
		//     // Tiếp tục thực thi
		// }
		// catch (InvalidOperationException ex)
		// {
		//     // Dùng ngoại lệ như một cách điều khiển luồng
		//     Console.WriteLine("Xử lý ngoại lệ thay vì kiểm tra điều kiện.");
		// }

		// //đúng
		// int x =-1;
		// if (x < 0)
		// {
		//     Console.WriteLine("Giá trị không hợp lệ.");
		// }
		// else
		// {
		//     // Tiến hành xử lý bình thường
		// }

		// the following code ensures that the connection is closed
		FileStream fs = null;

		//try
		//{
		//	fs = new FileStream(@"D:\A_practice\file.txt", FileMode.Open);
		//	// Đọc hoặc ghi vào tệp
		//	throw new IOException("Lỗi giả lập trong try"); // Cố ý gây lỗi
		//}
		//catch (IOException ex)
		//{
		//	Console.WriteLine($"Lỗi khi làm việc với tệp: {ex.Message}");
		//}
		//finally
		//{
		//	// Đảm bảo tệp luôn được đóng
		//	if (fs != null)
		//	{
		//		fs.Close();
		//		System.Console.WriteLine("File is closed");
		//	}
		//}
		// the  cost of using throw to rethrow an existing exception is approximately
		//the same as throwing a new exception. In the following code, there is no
		//savings from rethrowing the existing exception.

		//try
		//{
		//	throw new InvalidOperationException("Có lỗi xảy ra.");
		//}
		//catch (Exception ex)
		//{
		//	// Cách 1: Rethrow ngoại lệ hiện có
		//	throw;  // Không lưu lại stack trace gốc

		//	// Cách 2: Tạo ngoại lệ mới
		//	//throw new Exception("Lỗi mới xảy ra.", ex);  // Giữ lại ngoại lệ gốc nhưng tạo mới một ngoại lệ
		//}

		// Do not catch exceptions that you do not know how to handle and then fail
		//to propagate the exception

		// không xử lý hoặc không truyền lại exception
		try
		{
			// Một số mã có thể gây ra ngoại lệ
			int result = 10 / int.Parse("0");
		}
		catch (DivideByZeroException ex)
		{
			// Chỉ bắt và không xử lý gì, không truyền ngoại lệ
			Console.WriteLine("Đã bắt ngoại lệ .");
		}

		// xử lý hoặc truyền lại exception
		try
		{
			// Một số mã có thể gây ra ngoại lệ
			int result = 10 / int.Parse("0");
		}
		catch (DivideByZeroException ex)
		{
			// Ghi lại log hoặc xử lý lỗi
			Console.WriteLine("Đã bắt ngoại lệ DivideByZeroException: " + ex.Message);
			// Truyền ngoại lệ đi
			throw;
		}
	}
}