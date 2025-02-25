using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace NCTR.M.A06
{
	/// <summary>
	/// Lớp tiện ích hỗ trợ import/export dữ liệu dưới định dạng JSON và Excel.
	/// </summary>
	public static class FileHelper
	{
		#region JSON Methods

		/// <summary>
		/// Xuất danh sách dữ liệu ra file JSON.
		/// </summary>
		/// <typeparam name="T">Kiểu dữ liệu của danh sách.</typeparam>
		/// <param name="data">Danh sách dữ liệu cần xuất.</param>
		/// <param name="filePath">Đường dẫn file JSON.</param>
		public static void ExportToJson<T>(List<T> data, string filePath)
		{
			try
			{
				// Sử dụng Formatting.Indented của Newtonsoft.Json để in đẹp
				string json = JsonConvert.SerializeObject(data, Formatting.Indented);
				File.WriteAllText(filePath, json);
				Console.WriteLine("Data exported to JSON successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error exporting data to JSON: " + ex.Message);
			}
		}

		/// <summary>
		/// Nhập danh sách dữ liệu từ file JSON.
		/// </summary>
		/// <typeparam name="T">Kiểu dữ liệu của danh sách.</typeparam>
		/// <param name="filePath">Đường dẫn file JSON.</param>
		/// <returns>Danh sách dữ liệu đã được import.</returns>
		public static List<T> ImportFromJson<T>(string filePath)
		{
			try
			{
				if (!File.Exists(filePath))
					throw new FileNotFoundException("File not found.", filePath);

				string json = File.ReadAllText(filePath);
				List<T> data = JsonConvert.DeserializeObject<List<T>>(json);
				Console.WriteLine("Data imported from JSON successfully.");
				return data;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error importing data from JSON: " + ex.Message);
				return new List<T>();
			}
		}

		#endregion JSON Methods

		#region Excel Methods

		/// <summary>
		/// Xuất danh sách dữ liệu ra file Excel sử dụng EPPlus.
		/// </summary>
		/// <typeparam name="T">Kiểu dữ liệu của danh sách.</typeparam>
		/// <param name="data">Danh sách dữ liệu cần xuất.</param>
		/// <param name="filePath">Đường dẫn file Excel.</param>
		public static void ExportToExcel<T>(List<T> data, string filePath)
		{
			try
			{
				// Thiết lập LicenseContext cho EPPlus (NonCommercial cho mục đích phi thương mại).
				ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

				using (var package = new ExcelPackage())
				{
					// Tạo worksheet và load dữ liệu kèm tiêu đề cột.
					var worksheet = package.Workbook.Worksheets.Add("Sheet1");
					worksheet.Cells["A1"].LoadFromCollection(data, true);
					package.SaveAs(new FileInfo(filePath));
				}
				Console.WriteLine("Data exported to Excel successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error exporting data to Excel: " + ex.Message);
			}
		}

		/// <summary>
		/// Nhập danh sách dữ liệu từ file Excel sử dụng EPPlus.
		/// Giả định dòng đầu tiên chứa tiêu đề cột trùng với tên thuộc tính của đối tượng T.
		/// </summary>
		/// <typeparam name="T">Kiểu dữ liệu của danh sách, cần có constructor không tham số.</typeparam>
		/// <param name="filePath">Đường dẫn file Excel.</param>
		/// <returns>Danh sách dữ liệu đã được import.</returns>
		public static List<T> ImportFromExcel<T>(string filePath) where T : new()
		{
			var list = new List<T>();
			try
			{
				// Thiết lập LicenseContext cho EPPlus.
				ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

				FileInfo fileInfo = new FileInfo(filePath);
				if (!fileInfo.Exists)
					throw new FileNotFoundException("File not found.", filePath);

				using (var package = new ExcelPackage(fileInfo))
				{
					var worksheet = package.Workbook.Worksheets.FirstOrDefault();
					if (worksheet == null)
						throw new Exception("No worksheet found in Excel file.");

					int rowCount = worksheet.Dimension.Rows;
					int colCount = worksheet.Dimension.Columns;

					// Lấy tiêu đề từ dòng đầu tiên.
					var headers = new List<string>();
					for (int col = 1; col <= colCount; col++)
					{
						headers.Add(worksheet.Cells[1, col].Value?.ToString());
					}

					// Lấy danh sách các thuộc tính của T.
					var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

					// Duyệt các dòng dữ liệu bắt đầu từ dòng thứ 2.
					for (int row = 2; row <= rowCount; row++)
					{
						T obj = new T();
						for (int col = 1; col <= colCount; col++)
						{
							string header = headers[col - 1];
							if (string.IsNullOrWhiteSpace(header))
								continue;

							var property = properties.FirstOrDefault(p => p.Name.Equals(header, StringComparison.OrdinalIgnoreCase));
							if (property != null)
							{
								object cellValue = worksheet.Cells[row, col].Value;
								if (cellValue != null)
								{
									try
									{
										// Chuyển đổi giá trị của cell về kiểu thuộc tính của T.
										object convertedValue = Convert.ChangeType(cellValue, property.PropertyType);
										property.SetValue(obj, convertedValue);
									}
									catch
									{
										// Nếu chuyển đổi thất bại, có thể ghi log hoặc bỏ qua.
									}
								}
							}
						}
						list.Add(obj);
					}
				}
				Console.WriteLine("Data imported from Excel successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error importing data from Excel: " + ex.Message);
			}
			return list;
		}

		#endregion Excel Methods
	}
}