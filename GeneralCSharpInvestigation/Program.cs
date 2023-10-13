using GeneralCSharpInvestigation;

internal class Program
{
    // function that returns a tuple
    private static (int Length,int Sum, double Average) ProcessList(int[] list)
    {
        int sum = 0;
        foreach (int item in list)
        {
            sum += item;
        }
        double avg = (double)sum / list.Length;
        return (list.Length, sum, avg);
    }

    
    private static void Main(string[] args)
    {
        Console.WriteLine("General C# Features");

        // Nullable 
        Member m = new Member { Id = 1, Name = "Alice" };

        Console.WriteLine(m.Name.ToUpper());

        if (m.Email != null)
        {
            Console.WriteLine(m.Email.ToUpper());
        }

        Console.WriteLine(m.Email?.ToUpper());
        Console.WriteLine("=================================");

        // null coalescing operator 
        Console.WriteLine(m.Email == null ? "something@gmail.com" : m.Email);
        Console.WriteLine(m.Email ?? "something@gmail.com");


        int[] numbers = { 1, 5, 4, 3, 7, 6, 9, 10, 2 };
        var answer = ProcessList(numbers);

        Console.WriteLine(answer.Sum);
        Console.WriteLine(answer.Length);
        Console.WriteLine(answer.Average);

        int a = 10;
        int b = 20;

        Console.WriteLine($" a = { a }  b = { b }");

        (a, b) = (b, a);

        Console.WriteLine($" a = { a }  b = { b }");








    }
}