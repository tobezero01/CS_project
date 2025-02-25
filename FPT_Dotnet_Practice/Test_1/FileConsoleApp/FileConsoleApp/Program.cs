using System;
using System.IO;
using System.Text;

internal class Program
{
	public static void Main(string[] args)
	{
		Console.OutputEncoding = Encoding.UTF8;
		string directory = @"D:\A_practice";
		if (!Directory.Exists(directory))
		{
			Directory.CreateDirectory(directory);
			Console.WriteLine("Created directory: " + directory);
		}
		// part 1 : class File
		//FileClassDemo(directory);

		// part 2 : FileInfo class
		//FileInfoClassDemo(directory);

		// part 3 : Directory/DirectoryInfo class
		//string directoryPath = @"D:\A_practice\DemoFolder";
		//DirectoryOperationsDemo(directoryPath);

		// part 4 :FileStream class
		//string filePath = @"D:\A_practice\fileStreamDemo.txt";
		//FileStreamDemo(filePath);

		// part 5 : StreamReader & StreamWriter - Đọc/Ghi tệp văn bản
		//string filePath = @"D:\A_practice\StreamDemo.txt";
		//WriteToFile(filePath);
		//ReadFromFile(filePath);

		// part 6 : BinaryReader & BinaryWriter
		//string filePath = @"D:\A_practice\BinaryDemo.dat";
		//WriteToBinaryFile(filePath);
		//ReadFromBinaryFile(filePath);

		// part 7 : custom transpose matrix
		string inputFilePath = @"D:\A_practice\matrix\input.txt";
		string outputFilePath = @"D:\A_practice\matrix\output.txt";

		try
		{
			int[,] matrix = ReadMatrixFromFile(inputFilePath);

			int[,] reversedMatrix = TransposeMatrix(matrix);

			WriteMatrixToFile(reversedMatrix, outputFilePath);

			Console.WriteLine("Ma trận đã được đảo và ghi vào tệp mới.");
		}
		catch (FileNotFoundException ex)
		{
			Console.WriteLine($"Lỗi: Tệp không tồn tại - {ex.Message}");
		}
		catch (FormatException ex)
		{
			Console.WriteLine($"Lỗi: Dữ liệu trong tệp không hợp lệ - {ex.Message}");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Lỗi không xác định: {ex.Message}");
		}
	}

	/// <summary>
	///	Example for File class
	/// </summary>
	/// <param name="directory"></param>
	private static void FileClassDemo(string directory)
	{
		try
		{
			//=============================Case 1 : tạo 1 file , ghi dữ liệu và in nó ra =======================================
			string fileName = "inputFile.txt";
			// 1. File.Create
			string filePath = Path.Combine(directory, fileName);
			File.Create(filePath).Close();
			Console.WriteLine("\nFile được tạo: " + fileName);

			// 2. File.Exists
			if (File.Exists(filePath))
				Console.WriteLine("File tồn tại : " + fileName);

			// 3. File.WriteAllText (ghi đè)
			string textContent = "This is an example file!!!";
			File.WriteAllText(filePath, textContent, Encoding.UTF8);
			//File.WriteAllText(filePath, textContent);
			Console.WriteLine("\nGhi vào file : " + fileName);

			// 4. File.ReadAllText: Đọc toàn bộ nội dung
			string readText = File.ReadAllText(filePath, Encoding.UTF8);
			Console.WriteLine("\nNội dung file " + fileName + " : ");
			Console.WriteLine(readText);
			Console.WriteLine("=====================================================================");

			//=============================Case 2 : tạo 1 file , ghi dữ liệu nhiều dòng và in nó ra =======================================
			// 5. File.WriteAllLines: Ghi nhiều dòng
			string fileLinesPath = Path.Combine(directory, "lines.txt");
			string[] linesToWrite = { "Line 1: Hello", "Line 2: World", "Line 3: File operations in C#" };
			File.WriteAllLines(fileLinesPath, linesToWrite, Encoding.UTF8);
			Console.WriteLine("\nFile được ghi qua các dòng : " + fileLinesPath);

			// 6. File.ReadAllLines: Đọc tất cả dòng
			string[] readLines = File.ReadAllLines(fileLinesPath, Encoding.UTF8);
			Console.WriteLine("\nNội dung file lines.txt:");
			foreach (string line in readLines)
			{
				Console.WriteLine(line);
			}
			Console.WriteLine("=====================================================================");

			//==================Case 3 : thêm nội dung vào cuối file inputFile.txt, copy ra file mới , đổi tên file và xóa nó =======================
			// 7. File.AppendAllText: Thêm nội dung vào cuối file
			string appendContent = "\nThêm nội dung vào cuối file dùng File.AppendAllText.";
			File.AppendAllText(filePath, appendContent, Encoding.UTF8);
			Console.WriteLine("\nNội dung file inputFile.txt sau khi thêm :");
			Console.WriteLine(File.ReadAllText(filePath, Encoding.UTF8));

			// 8. File.Copy: Sao chép file (overwrite nếu file đích đã tồn tại)
			string copyFilePath = Path.Combine(directory, "example_copy.txt");
			if (File.Exists(copyFilePath))
			{
				Console.WriteLine($"\nFile '{copyFilePath}' đã tồn tại! Đang ghi đè...");
			}
			File.Copy(filePath, copyFilePath, true);
			Console.WriteLine("\nFile được copy ra: " + copyFilePath);

			// 9. File.Move: Di chuyển (hoặc đổi tên) file
			string movedFilePath = Path.Combine(directory, "example_moved.txt");
			if (File.Exists(movedFilePath))
			{
				Console.WriteLine($"\nFile '{movedFilePath}' đã tồn tại! Đang ghi đè...");
				File.Delete(movedFilePath);
			}
			File.Move(copyFilePath, movedFilePath);
			Console.WriteLine("File đổi thành: " + movedFilePath);

			// 10. File.Delete: Xóa file
			//if (File.Exists(movedFilePath))
			//{
			//	File.Delete(movedFilePath);
			//	Console.WriteLine("\nDeleted file: " + movedFilePath);
			//}

			//=============================================================================================================
			Console.WriteLine("=====================================================================");
			// 11. File.GetAttributes: Lấy thông tin thuộc tính của file

			FileAttributes attributes = File.GetAttributes(filePath);
			Console.WriteLine("\nTrạng thái file gốc: " + attributes.ToString());

			// 12. File.Open: Mở file với chế độ chỉ định (ở đây chỉ mở và đóng ngay)
			var fs = File.Open(filePath, FileMode.Open);
			Console.WriteLine("\nFile được mở dử dụng File.Open: " + filePath);
			fs.Close();
		}
		catch (Exception ex)
		{
			Console.WriteLine("\nLỗi : " + ex.Message);
		}
		finally
		{
			Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
			Console.ReadKey();
		}
	}

	/// <summary>
	/// Example for FileInfo class
	/// </summary>
	/// <param name="directory"></param>
	private static void FileInfoClassDemo(string directory)
	{
		try
		{
			string filePath = Path.Combine(directory, "fileInfo.txt");

			FileInfo fileInfo = new FileInfo(filePath);

			// 1. Nếu file đã tồn tại, xóa file đó để tạo mới
			if (fileInfo.Exists)
			{
				Console.WriteLine("File đã tồn tại, sẽ xóa file cũ.");
				fileInfo.Delete();
			}

			// 2. Tạo file mới và ghi nội dung vào file (đảm bảo UTF-8)
			File.WriteAllText(filePath, "Đây là nội dung của fileinfo_example.txt.", Encoding.UTF8);
			Console.WriteLine("\nFile được tạo: " + fileInfo.FullName);

			// 3. Cập nhật lại thông tin file
			fileInfo.Refresh();

			// 4. Hiển thị các thuộc tính của file
			Console.WriteLine("\n--- Thông tin file ---");
			Console.WriteLine("Tồn tại: " + fileInfo.Exists);
			Console.WriteLine("Kích thước: " + fileInfo.Length + " bytes");
			Console.WriteLine("Phần mở rộng: " + fileInfo.Extension);
			Console.WriteLine("Thư mục chứa file: " + fileInfo.DirectoryName);
			Console.WriteLine("Lần truy cập cuối cùng: " + fileInfo.LastAccessTime);
			Console.WriteLine("=====================================================================");

			// 5. Sao chép file tới vị trí mới
			string copyPath = Path.Combine(directory, "fileinfo_example_copy.txt");

			if (File.Exists(copyPath))
			{
				Console.WriteLine($"\nFile đích '{copyPath}' đã tồn tại! Không thực hiện sao chép.");
			}
			else
			{
				FileInfo copiedFile = fileInfo.CopyTo(copyPath, true);
				Console.WriteLine("\nFile đã được sao chép tới: " + copiedFile.FullName);

				// 6. Di chuyển file sao chép đến vị trí mới
				string movedPath = Path.Combine(directory, "fileinfo_example_moved.txt");

				if (File.Exists(movedPath))
				{
					Console.WriteLine($"\nFile '{movedPath}' đã tồn tại! Không thực hiện di chuyển.");
				}
				else
				{
					copiedFile.MoveTo(movedPath);
					Console.WriteLine("File sao chép đã được di chuyển tới: " + movedPath);
				}
			}
		}
		catch (IOException ioEx)
		{
			Console.WriteLine("Lỗi I/O: " + ioEx.Message);
		}
		catch (UnauthorizedAccessException unAuthEx)
		{
			Console.WriteLine("Truy cập bị từ chối: " + unAuthEx.Message);
		}
		catch (Exception ex)
		{
			Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
		}
		finally
		{
			Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
			Console.ReadKey();
		}
	}

	/// <summary>
	///	Example for Directory class
	/// </summary>
	/// <param name="directoryPath"></param>
	private static void DirectoryOperationsDemo(string directory)
	{
		try
		{
			// 1. Tạo thư mục nếu chưa tồn tại
			if (!Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
				Console.WriteLine($"Thư mục '{directory}' đã được tạo.");
			}
			else
			{
				Console.WriteLine($"Thư mục '{directory}' đã tồn tại.");
			}

			// 2. Lấy danh sách tệp trong thư mục
			string[] files = Directory.GetFiles(directory);
			Console.WriteLine("\nDanh sách tệp trong thư mục:");
			foreach (string file in files)
			{
				Console.WriteLine($"   - {Path.GetFileName(file)}");
			}

			Console.WriteLine("=====================================================================");
			// 3. Lấy danh sách thư mục con
			string[] subDirectories = Directory.GetDirectories(directory);
			Console.WriteLine("\nDanh sách thư mục con:");
			foreach (string subDir in subDirectories)
			{
				Console.WriteLine($"   - {Path.GetFileName(subDir)}");
			}

			// 4. Lấy thư mục cha của thư mục hiện tại
			DirectoryInfo parentDir = Directory.GetParent(directory);
			if (parentDir != null)
			{
				Console.WriteLine($"\nThư mục cha của '{directory}' là : {parentDir.FullName}");
			}
			else
			{
				Console.WriteLine("\nĐây là thư mục gốc, không có thư mục cha.");
			}

			// 5. Di chuyển thư mục (nếu cần)
			string newDirectoryPath = directory + "_Moved";
			if (!Directory.Exists(newDirectoryPath))
			{
				Directory.Move(directory, newDirectoryPath);
				Console.WriteLine($"\nThư mục đã được di chuyển tới: {newDirectoryPath}");
			}
			else
			{
				Console.WriteLine($"\nThư mục đích '{newDirectoryPath}' đã tồn tại, không thể di chuyển.");
			}

			Console.WriteLine("=====================================================================");
			// 6. Xóa thư mục (nếu cần)
			Console.Write("\nBạn có muốn xóa thư mục? (y/n): ");
			if (Console.ReadLine().ToLower() == "y")
			{
				Directory.Delete(newDirectoryPath, true);
				Console.WriteLine($"Thư mục '{newDirectoryPath}' đã bị xóa.");
			}
			else
			{
				Console.WriteLine("Không xóa thư mục.");
			}
		}
		catch (IOException ioEx)
		{
			Console.WriteLine($"Lỗi I/O: {ioEx.Message}");
		}
		catch (UnauthorizedAccessException unAuthEx)
		{
			Console.WriteLine($"Truy cập bị từ chối: {unAuthEx.Message}");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Có lỗi xảy ra: {ex.Message}");
		}
	}

	/// <summary>
	/// FileStream Demo
	/// </summary>
	/// <param name="path"></param>
	private static void FileStreamDemo(string path)
	{
		try
		{
			// 1️ Ghi dữ liệu vào file bằng FileStream
			using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
			{
				string text = "Xin chào, đây là dữ liệu được ghi bằng FileStream!";
				byte[] bytes = Encoding.UTF8.GetBytes(text);
				//foreach (byte b in bytes) { Console.Write(b); }
				// Ghi vào file
				fs.Write(bytes, 0, bytes.Length);
				Console.WriteLine($"Đã ghi vào file: {path}");
			}

			// 2️ Đọc dữ liệu từ file bằng FileStream
			using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				byte[] bytes = new byte[fs.Length];
				fs.Read(bytes, 0, bytes.Length);

				string readText = Encoding.UTF8.GetString(bytes);
				Console.WriteLine($"Nội dung đọc từ file: {readText}");
				Console.WriteLine($"\nKích thước tệp: {fs.Length} bytes");
			}

			// 3 Di chuyển con trỏ đọc file
			using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				fs.Seek(10, SeekOrigin.Begin); // Di chuyển con trỏ đến vị trí 10
				byte[] buffer = new byte[10];
				fs.Read(buffer, 0, buffer.Length);

				string partialText = Encoding.UTF8.GetString(buffer);
				Console.WriteLine($"\nNội dung từ vị trí 10: {partialText}");
			}

			// 4 Đóng file (Tự động đóng khi dùng `using`)
			Console.WriteLine("\nFileStream đã tự động đóng sau khi thoát khỏi using.");
		}
		catch (IOException ioEx)
		{
			Console.WriteLine($"Lỗi I/O: {ioEx.Message}");
		}
		catch (UnauthorizedAccessException unAuthEx)
		{
			Console.WriteLine($"Truy cập bị từ chối: {unAuthEx.Message}");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Có lỗi xảy ra: {ex.Message}");
		}
	}

	/// <summary>
	/// Stream Writer
	/// </summary>
	/// <param name="path"></param>
	private static void WriteToFile(string path)
	{
		try
		{
			// Tạo đối tượng StreamWriter để ghi dữ liệu vào tệp
			using (StreamWriter streamWriter = new StreamWriter(path))
			{
				streamWriter.WriteLine("Dòng đầu tiên trong tệp.");
				streamWriter.WriteLine("Dòng thứ hai trong tệp.");
				streamWriter.Write("Dòng thứ ba, không có xuống dòng.");
			}
			Console.WriteLine("Dữ liệu đã được ghi vào tệp.");
			Console.WriteLine("=====================================================================");
		}
		catch (UnauthorizedAccessException ex)
		{
			Console.WriteLine("Lỗi quyền truy cập: " + ex.Message);
		}
		catch (IOException ex)
		{
			Console.WriteLine("Lỗi input/output: " + ex.Message);
		}
		catch (Exception ex)
		{
			Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
		}
	}

	/// <summary>
	/// Stream Reader
	/// </summary>
	/// <param name="path"></param>
	private static void ReadFromFile(string path)
	{
		try
		{
			// Tạo đối tượng StreamReader để đọc dữ liệu từ tệp
			using (StreamReader streamReader = new StreamReader(path))
			{
				string line;

				// Đọc từng dòng từ tệp và in ra màn hình
				while ((line = streamReader.ReadLine()) != null)
				{
					Console.WriteLine(line);
				}

				Console.WriteLine("=====================================================================");
				streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
				string s = streamReader.ReadToEnd();
				Console.WriteLine("\nToàn bộ nội dung tệp:");
				Console.WriteLine(s);
			}
		}
		catch (FileNotFoundException ex)
		{
			Console.WriteLine("Tệp không tìm thấy: " + ex.Message);
		}
		catch (UnauthorizedAccessException ex)
		{
			Console.WriteLine("Lỗi quyền truy cập: " + ex.Message);
		}
		catch (IOException ex)
		{
			Console.WriteLine("Lỗi input/output: " + ex.Message);
		}
		catch (Exception ex)
		{
			Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
		}
	}

	/// <summary>
	/// Ghi dữ liệu nhị phân vào tệp
	/// </summary>
	/// <param name="path"></param>
	private static void WriteToBinaryFile(string path)
	{
		try
		{
			// Mở tệp để ghi dữ liệu nhị phân
			using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
			{
				// Ghi các kiểu dữ liệu nhị phân
				writer.Write(12345);
				writer.Write(3.14159);
				writer.Write("Hello, World!");
				writer.Write(true);
				writer.Write(new byte[] { 1, 2, 3, 4 });
			}
			Console.WriteLine("Dữ liệu nhị phân đã được ghi vào tệp.");
			Console.WriteLine("=====================================================================");
		}
		catch (IOException ex)
		{
			Console.WriteLine("Lỗi ghi tệp: " + ex.Message);
		}
	}

	/// <summary>
	/// Đọc dữ liệu nhị phân từ tệp
	/// </summary>
	/// <param name="path"></param>
	private static void ReadFromBinaryFile(string path)
	{
		try
		{
			// Mở tệp để đọc dữ liệu nhị phân
			using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
			{
				// Đọc các kiểu dữ liệu nhị phân
				int intValue = reader.ReadInt32();
				double doubleValue = reader.ReadDouble();
				string stringValue = reader.ReadString();
				bool boolValue = reader.ReadBoolean();
				byte[] byteArray = reader.ReadBytes(4);

				// Hiển thị dữ liệu đọc được
				Console.WriteLine($"Số nguyên: {intValue}");
				Console.WriteLine($"Số thực: {doubleValue}");
				Console.WriteLine($"Chuỗi: {stringValue}");
				Console.WriteLine($"Giá trị Boolean: {boolValue}");
				Console.WriteLine("Mảng byte:");
				foreach (byte b in byteArray)
				{
					Console.Write(b + " ");
				}
				Console.WriteLine();
				Console.WriteLine("=====================================================================");

				// Kiểm tra ký tự tiếp theo mà không di chuyển con trỏ
				reader.BaseStream.Seek(0, SeekOrigin.Begin);
				char nextChar = (char)reader.PeekChar();
				Console.WriteLine($"Ký tự tiếp theo: {nextChar}");
			}
		}
		catch (FileNotFoundException ex)
		{
			Console.WriteLine("Tệp không tìm thấy: " + ex.Message);
		}
		catch (IOException ex)
		{
			Console.WriteLine("Lỗi đọc tệp: " + ex.Message);
		}
	}

	/// <summary>
	/// Đọc ma trận từ file
	/// </summary>
	/// <param name="filePath"></param>
	/// <returns>matrix</returns>
	/// <exception cref="Exception"></exception>
	private static int[,] ReadMatrixFromFile(string filePath)
	{
		try
		{
			string[] lines = File.ReadAllLines(filePath);
			int rows = lines.Length;
			int cols = lines[0].Split(' ').Length;
			int[,] matrix = new int[rows, cols];

			for (int i = 0; i < rows; i++)
			{
				string[] numbers = lines[i].Split(' ');
				if (numbers.Length != cols)
				{
					throw new FormatException("Số lượng cột không đồng đều trong các dòng.");
				}

				for (int j = 0; j < cols; j++)
				{
					matrix[i, j] = int.Parse(numbers[j]);
				}
			}

			return matrix;
		}
		catch (Exception ex)
		{
			throw new Exception("Lỗi khi đọc ma trận từ tệp: " + ex.Message);
		}
	}

	/// <summary>
	/// chuyển vị ma trận
	/// </summary>
	/// <param name="matrix"></param>
	/// <returns>reversedMatrix</returns>
	private static int[,] TransposeMatrix(int[,] matrix)
	{
		int rows = matrix.GetLength(0);
		int cols = matrix.GetLength(1);
		int[,] transposedMatrix = new int[cols, rows];

		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < cols; j++)
			{
				transposedMatrix[j, i] = matrix[i, j];
			}
		}

		return transposedMatrix;
	}

	/// <summary>
	/// ghi ma trận lại vào file output
	/// </summary>
	/// <param name="matrix"></param>
	/// <param name="filePath"></param>
	/// <exception cref="Exception"></exception>
	private static void WriteMatrixToFile(int[,] matrix, string filePath)
	{
		try
		{
			using (StreamWriter writer = new StreamWriter(filePath))
			{
				int rows = matrix.GetLength(0);
				int cols = matrix.GetLength(1);

				for (int i = 0; i < rows; i++)
				{
					for (int j = 0; j < cols; j++)
					{
						writer.Write(matrix[i, j]);
						if (j < cols - 1)
							writer.Write(" ");
					}
					writer.WriteLine();
				}
			}
		}
		catch (Exception ex)
		{
			throw new Exception("Lỗi khi ghi ma trận vào tệp: " + ex.Message);
		}
	}
}