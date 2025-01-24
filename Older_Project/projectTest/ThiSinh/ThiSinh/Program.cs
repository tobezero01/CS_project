using ThiSinh;

internal class program
{
    static void Main(string[] args)
    {
        List<tuyenSinh> tuyenSinhs = new List<tuyenSinh>();
        int n = 3;
        int dc = 24;
        List<tuyenSinh> tuyenSinhs1 = new List<tuyenSinh>();
        for (int i = 0; i < n; i++)
        {
            tuyenSinh t = new tuyenSinh();
            t.input();
            tuyenSinhs.Add(t);
            if (t.tinhTong() >= dc)
            {
                tuyenSinhs1.Add(t);
            }

        }       
        foreach (var i  in tuyenSinhs1) { 
            i.output();
        }
    }
}
