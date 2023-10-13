
internal class Program
{

    private static void Main(string[] args)
    {
        Console.WriteLine("Async Await Example");

        Task.Run(async () => {

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Working {i}");
                await Task.Delay(100);
            }
        });

        Console.WriteLine("Main Thread...");
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine($"Main Thread Working {i}");
            Thread.Sleep(100);
        }
        Console.WriteLine("finished");

    }
}