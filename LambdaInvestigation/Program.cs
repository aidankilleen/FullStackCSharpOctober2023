
internal class Program
{

    static bool CheckIfOdd(int i)
    {
        return i % 2 == 1;
    }
    static bool CheckIfEven(int i) 
    {  
        return i % 2 == 0; 
    }
    static bool CheckString(string s)
    {
        return s.Length > 0;
    }
    static void CheckList(int[] items, CheckFunction checkFn)
    {
        foreach(int item in items)
        {
            if (checkFn(item))
            {
                Console.WriteLine(item);
            }
        }
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("Lambda Investigation");
        
        List<string> names = new List<string>();

        names.Add("alice");
        names.Add("bob");
        names.Add("carol");
        names.Add("dan");


        names.ForEach(name => Console.WriteLine(name));


        




        Console.WriteLine("==============================");
        

        int[] list = { 1, 4, 2, 3, 6, 7, 5, 9 };

        CheckList(list, CheckIfEven);
        //CheckList(list, CheckString);


        // you can use a lambda expression
        // in the place of a delegate
        // as long as it has the same signature
        CheckList(list, (i) => {

            if (i % 2 == 0)
            {
                return true;
            } else
            {
                return false;
            }
        });

        Console.WriteLine("=========================");
        CheckList(list, i => i % 2 == 1);



        








        /*
        names.ForEach((name) =>
        {
            Console.WriteLine(name);
        });
        */
    }
}

delegate bool CheckFunction(int i);
