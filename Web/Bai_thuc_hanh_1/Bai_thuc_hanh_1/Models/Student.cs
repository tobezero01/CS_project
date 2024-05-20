using System.ComponentModel.DataAnnotations;

namespace Bai_thuc_hanh_1.Models
{
    public class Student
    {
        public int Id { get; set; }//Mã sinh viên
        [Required(ErrorMessage = "Tên bắt buộc phải được nhập")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Name tối thiểu 4 ký tự, tối đa 100 ký tự")]
        public string? Name { get; set; }//Họ tên
        [Required(ErrorMessage ="Email bắt buộc phải được nhập")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@gmail.com")]
        public string? Email { get; set; }//Email
        //[StringLength(100, MinimumLength = 8 ,ErrorMessage = "Mật khẩu tối thiểu 8 ký tự, tối đa 100 ký tự")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@#$%^&+=!]).{8,}$",ErrorMessage = "Mật khẩu từ 8 ký tự trở lên, có ký tự viết hoa, viết thường, chữ số và ký tự đặc biệt")]

        [Required(ErrorMessage = "Mật khẩu bắt buộc phải được nhập")]
        public string? Password { get; set; }//Mật khẩu
        [Required]
        public Branch? Branch { get; set; }//Ngành học
        [Required(ErrorMessage = "Chọn 1 trong 2 giới tính")]
        public Gender? Gender { get; set; }//giới tính
        public bool IsRegular { get; set; }//Hệ: true-chính qui, false-phi cq
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Địa chỉ bắt buộc phải được nhập")]
        public string? Address { get; set; }//Địa chỉ
        [Required(ErrorMessage = "Giá trị không hợp lệ")]
        [Range(typeof(DateTime), "1/1/1963", "12/31/2005")]
        [DataType(DataType.Date)]
       
        public DateTime DateOfBorth { get; set; }//Ngày sinh
       
        [Range(typeof(Double), "0.0", "10.0", ErrorMessage = "Miền giá trị từ 0.0 đến 10.0")]
        [Required(ErrorMessage = "Điểm bắt buộc phải nhập")]
        public double Score { get; set; }

    }
}
