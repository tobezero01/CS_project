using System.Collections.Generic;

class NguoiGui
{
    private int MaKH;
    private string TenKH;
    private string DiaChi;
    private int SoTienGui;
    private string NgayGui;
    private string ThoiGianGui;
    private double Tien;

    public NguoiGui(int maKH)
    {
        MaKH = maKH;
    }

    public NguoiGui(int maKH, string tenKH, string diaChi, int soTienGui, string ngayGui, string thoiGianGui, double tien)
    {
        MaKH = maKH;
        TenKH = tenKH;
        DiaChi = diaChi;
        SoTienGui = soTienGui;
        NgayGui = ngayGui;
        ThoiGianGui = thoiGianGui;
        Tien = tien;
    }

    public int MaKH1 { get => MaKH; set => MaKH = value; }
    public string TenKH1 { get => TenKH; set => TenKH = value; }
    public double Tien1 { get => Tien; set => Tien = value; }
}

