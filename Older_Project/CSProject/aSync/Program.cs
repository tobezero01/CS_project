namespace aSync
{
    internal class Program
    {
        // asyschronous (multi thread)
        static void doST(int seconds, string mes, ConsoleColor color)
        {
            Console.WriteLine($" {mes} +  Start -  - ----------");
            Console.ResetColor();

            string a = "abc";
            lock (Console.Out)
            {

            }
            for (int i = 0; i <= seconds; i++) {
                
                lock(Console.Out)
                {

                }
                Console.ForegroundColor = color;
                Console.WriteLine($"{mes}, {i}");
                Console.ResetColor();
                Thread.Sleep( 1000);
            }
            Console.WriteLine("end---------- ");
            lock (Console.Out)
                {

            }
        }
        static async Task Task2()
        {
            Task t2 = new Task(
                () =>
                {
                    doST(11, "T2", ConsoleColor.Green);
                }
                );
            t2.Start();
            //t2.Wait();
            await t2;
            Console.WriteLine("t2 completed");
            
        }
        static async Task Task3()
        {
            Task t3 = new Task(
                (object ob) =>
                {
                    string tentacvu = (string)ob;
                    doST(3, tentacvu, ConsoleColor.Red);
                }, "T3"
                );
            t3.Start();
            await t3;
            Console.WriteLine("t3 completed");
            
        }

        static async Task<string> Task4()
        {
            Task<string> t4 = new Task<string>(
                () =>
                {
                    doST(10, "T4", ConsoleColor.Green);
                    return "return from t4";
                }
                );
            t4.Start();
            var kq = await t4;
            Console.WriteLine();
            return kq;
        }
        static async Task<string> Task5()
        {
            Task<string> t5 = new Task<string>(
                (object ob) =>
                {
                    string t = (string)ob;
                    doST(10, t, ConsoleColor.Yellow);
                    return $"return from {t}";
                }, "T5"
                );
            t5.Start();

            var kq = await t5;
            return kq;
        }
        // asysnhronos 
        static async void Main(string[] args)
        {
            // syschronous 

            // task
            Task t2 = Task2();
            Task t3 = Task3();


            Console.WriteLine("----------------------------");
            Task<string> t4 = Task4();
            Task<string> t5 = Task5();

            var kq4 = await t4;
            var kq5 = await t5;

            Console.WriteLine();


            Console.WriteLine("end all");
            Console.ReadKey();
        }
    }
}