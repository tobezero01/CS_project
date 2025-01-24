using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public static class Utils
    {
        public static bool FormIsOpen(string name)
        {
            var OpenForms = Application.OpenForms.Cast<Form>();
            var isOpen = OpenForms.Any(q => q.Name == name);
            return isOpen;
        }

        public static string HashPassword(string password)
        {
            SHA256 sha = SHA256.Create();

            byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        public static string DefaultHashedPassword()
        {
            // Khởi tạo đối tượng SHA256 để thực hiện mã hóa chuỗi
            SHA256 sha = SHA256.Create();

            // Chuyển đổi chuỗi đầu vào thành mảng byte và tính toán mã băm
            byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes("duc123"));

            // Khởi tạo một StringBuilder mới để thu thập các byte và tạo một chuỗi
            StringBuilder sBuilder = new StringBuilder();

            // Lặp qua từng byte của dữ liệu đã băm
            for (int i = 0; i < data.Length; i++)
            {
                // Định dạng từng byte thành chuỗi thập lục phân và thêm vào StringBuilder
                sBuilder.Append(data[i].ToString("x2"));
            }
           
            // Đây là giá trị mã băm cuối cùng mà bạn có thể lưu trữ hoặc sử dụng cho mục đích xác thực mật khẩu
            return sBuilder.ToString();
        }
    }
}
