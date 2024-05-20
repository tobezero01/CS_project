
using System;
using System.Linq;
namespace LinQ
{
    public class Product
    {
        public int ID { set; get; }
        public string Name { set; get; }         // tên
        public double Price { set; get; }        // giá
        public string[] Colors { set; get; }     // các màu sắc
        public int Brand { set; get; }           // ID Nhãn hiệu, hãng
        public Product(int id, string name, double price, string[] colors, int brand)
        {
            ID = id; Name = name; Price = price; Colors = colors; Brand = brand;
        }
        // Lấy chuỗi thông tin sản phẳm gồm ID, Name, Price
        override public string ToString()
           => $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";

    }
    public class Brand
    {
        public string Name { set; get; }
        public int ID { set; get; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var brands = new List<Brand>() {
                new Brand{ID = 1, Name = "Công ty AAA"},
                new Brand{ID = 2, Name = "Công ty BBB"},
                new Brand{ID = 4, Name = "Công ty CCC"},
            };

            var products = new List<Product>()
            {
                new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
                new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
                new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
                new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
                new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
                new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
                new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
            };

            var query = from p in products where p.Price == 400 select p;

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----------------------------");
            var kq = products.Select(
                (p) => {
                    return p.Name;
                });
            foreach (var item in kq)
            {
                Console.WriteLine(item);
            }
                
            Console.WriteLine("-----------------------------");
            var kq1 = products.Where(
                (p) =>
                {
                    return p.Price > 200;
                }
                );
            Console.WriteLine("-----------------------------");

            //select many
            var kq2 = products.Join(brands, p => p.Brand, b => b.ID, (p,b) =>
            {
                return new
                {
                    Ten = p.Name,
                    Thuonghieu = b.Name
                };
            });
            Console.WriteLine("-----------------------------");
            // take,skip

            products.Take(2).ToList().ForEach( p => Console.WriteLine(p));

            // orderby, orderbyDes
            Console.WriteLine("-----------------------------");
            products.OrderBy(p => p.Price).ToList().ForEach(p => Console.WriteLine(p));
            Console.WriteLine("-----------------------------");
            // reverse
            //group by

            var kq3 = products.GroupBy(p => p.Price);
            foreach (var item in kq3)
            {
                Console.WriteLine(item.Key);
                foreach (var item2 in item)
                {
                    Console.WriteLine(item2);
                }
            }
            Console.WriteLine("-----------------------------");

            // distinct
            products.SelectMany(p => p.Colors).Distinct().ToList().ForEach(
                mau => Console.WriteLine(mau)
                );

            // all, any
            //count


            // de bai, in ra ten, thuong hieu, gia 300-400 // gia giam dan

            products.Where(p => p.Price >= 300 && p.Price <= 400)
                    .OrderByDescending(p => p.Price)
                    .Join(brands, p => p.Brand, b => b.ID, (sp, th) =>
                    {
                        return new
                        {
                            Ten = sp.Name,
                            tenTH = th.Name,
                            gia = sp.Price
                        };
                    })
                    .ToList()
                    .ForEach(info =>
                    {
                        Console.WriteLine($"{info.Ten,15}{info.tenTH,15},{info.gia,15}");
                    });

            Console.WriteLine("--------------------------------");
            // truy van LINQ
            /*
             * 1, xac dinh nguon : from temp in IEnum
             * 2, lay du lieu : select, groug by...
             */

            var pr = from a in products select $"{a.Name} : {a.Price}";
            pr.ToList().ForEach(name  => Console.WriteLine(name));
            
        }
    }
}