using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Duc_211202522.Models
{
    public partial class HangHoa
    {
        public int MaHang { get; set; }
        public int MaLoai { get; set; }
        [Required(ErrorMessage = "Tên Hàng không được để trống !!!")]
        public string TenHang { get; set; } = null!;
        [Required(ErrorMessage ="ko bo trong !!!")]
        [DataType(DataType.Currency)]
        [Range(100,5000,ErrorMessage ="Gia tien ngoai khoang")]
        public decimal? Gia { get; set; }
        [Required]
        [RegularExpression(@"^.+\.(jpg|jpeg|png|gif|tiff)$", ErrorMessage = "Tên file ảnh phải có đuôi: .jpg, .jpeg, .png, .gif, hoặc .tiff")]
        public string? Anh { get; set; }
        [ValidateNever]
        public virtual LoaiHang MaLoaiNavigation { get; set; } = null!;
    }
}
