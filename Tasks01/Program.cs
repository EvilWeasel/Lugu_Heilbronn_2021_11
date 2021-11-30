using System.Net;

namespace Tasks01
{
    class Program
    {

        static async void Test05()
        {
            //Task.Run(() => { });
            //Task<string>.Run(async () => {
                
            //    await Task.Delay(1000);
            //    return "BOOOOOOOOOM!!!";
            //});
            Task<string> x = Task.Run(() => 
            {
                Task.Delay(1000);
                return "BOOOOOOM!!!";
            });
            //var aw = x.GetAwaiter();

            Console.WriteLine("Result: " + x.Result);
        }


        static async Task<string> Test04()
        {
            WebClient c = new WebClient();
            return await c.DownloadStringTaskAsync("http://www.google.de");
        }

        static async Task<int> Sum(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += i;
                await Task.Delay(10);
            }
            return sum;
        }

        static async Task Test03()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("TASK");
                await Task.Delay(10);
            }
        }

        static async void Test02()
        {
            Task<int> t4 = Sum(1000);
            // Only possible in async methode
            Console.WriteLine("RESULT SUM(1000):" + t4.GetAwaiter().GetResult());
            int result = await Sum(2000);
            Console.WriteLine(result);
            Task.WaitAll(t4);
        }


        public static void Main(string[] args)
        {
            //Task<string> googletask = Test04();
            //Console.WriteLine("GOOGLETASK");
            //Console.WriteLine(googletask);
            //Console.WriteLine("GOOGLETASK.RESULT");
            //Console.WriteLine(googletask.Result);
            //Console.WriteLine("ENDE");

            //Test05();

            Test05();

        }
    }
}