using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TH3_B2
{
    public class BaiTapDienTu
    {
        private string debai;
        private string dapan;
        private List<string> dapAnTungCau;

        public BaiTapDienTu() { }

        public BaiTapDienTu(string debai, string dapan)
        {
            this.debai = debai;
            this.dapan = dapan;
        }
        public BaiTapDienTu(string debai, string dapan, List<string> dapAnTungCau)
        {
            this.debai = debai;
            this.dapan = dapan;
            this.dapAnTungCau = dapAnTungCau;
        }

        public string Debai { get => Debai1; set => Debai1 = value; }
        public string Dapan { get => Dapan1; set => Dapan1 = value; }
        public string Debai1 { get => debai; set => debai = value; }
        public string Dapan1 { get => dapan; set => dapan = value; }
        public List<string> Dapantungcau { get => dapAnTungCau; set => dapAnTungCau = value; }
    }
}
