namespace BookManagement
{
    class Book {
        private string idB { get; set; }
        private string nameB { get; set; }
        private string author { get; set; }
        private int cnt { get; set; }

        public Book() { }
        public Book(string idB, string nameB, string author,int cnt) {
            this.idB = idB;
            this.nameB = nameB;
            this.author = author;
            this.cnt = cnt;
        }
        public void Nhap()
        {
            Console.Write("Nhap ma sach : ");
            idB = Console.ReadLine();           
            Console.Write("Nhap ten sach : ");
            nameB = Console.ReadLine();   
            Console.Write("Nhap tac gia sach : ");
            author =Console.ReadLine();   
            Console.Write("Nhap so luong : ");
            cnt = Convert.ToInt16(Console.ReadLine());   
        }
    }
    class referenceB : Book
    {
        private string qrCodeB { get; set; }
        public referenceB () {               
        }
        public referenceB(string idB, string nameB, string author,int cnt, string qrCodeB) : base(idB,nameB,author,cnt){
            this.qrCodeB = qrCodeB;
        }

        public void Nhap() {
           
        }

        // public int timKiem(string qrCode) {

        // }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt16(Console.); 
        }
    }
}