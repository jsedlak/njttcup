using System;

namespace TestTimeSpan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var data = new[]
            {
                "0:0:46:06.8"
            };

            foreach (var d in data)
            {
                try
                {
                    var ts = TimeSpan.Parse(d);
                    Console.WriteLine($"{d} WAS PARSED");
                    Console.WriteLine($"\t{ts.Days} days, {ts.Hours} hours, {ts.Minutes} minutes, {ts.Seconds}.{ts.Milliseconds} seconds");
                }
                catch(Exception)
                {
                    Console.WriteLine($"Couldn't parse {d}");
                }
            }
        }
    }
}
