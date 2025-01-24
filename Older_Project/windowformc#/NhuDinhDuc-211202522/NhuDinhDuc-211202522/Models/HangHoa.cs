using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NhuDinhDuc_211202522.Models
{
    public partial class HangHoa
    {
        public int MaHang { get; set; }
        public int MaLoai { get; set; }
        [Required(ErrorMessage = "Tên Hàng không được để trống !!!")]
        public string TenHang { get; set; } = null!;
        [Required(ErrorMessage = "Bạn cần nhập Giá")]
        [DataType(DataType.Currency)]
        [Range(100, 5000, ErrorMessage = "Giá phải nằm trong khoảng từ 100 đến 5000")]
        public decimal? Gia { get; set; }
        [Required(ErrorMessage = "Ảnh không được để trống !!!")]
        [RegularExpression(@"^.+\.(jpg|jpeg|png|gif|tiff)$", ErrorMessage = "Tên file ảnh phải có đuôi: .jpg, .jpeg, .png, .gif, hoặc .tiff")]
        // ^: điểm bắt đầu chuỗi; .+ đại diện cho bất kì kí tự nào trừ kí tự xuống dòng; \. viết dấu '.'; các đuôi, $ điểm kết thúc chuỗi
        public string? Anh { get; set; }

        public virtual LoaiHang? MaLoaiNavigation { get; set; } = null!;
    }
}
