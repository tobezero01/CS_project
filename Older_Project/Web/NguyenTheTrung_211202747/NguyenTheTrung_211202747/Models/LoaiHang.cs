using System;
using System.Collections.Generic;

namespace NguyenTheTrung_211202747.Models
{
    public partial class LoaiHang
    {
        public LoaiHang()
        {
            HangHoas = new HashSet<HangHoa>();
        }

        public int MaLoai { get; set; }
        public string TenLoai { get; set; } = null!;

        public virtual ICollection<HangHoa> HangHoas { get; set; }
    }
}
