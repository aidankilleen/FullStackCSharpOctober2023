namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Message m = new Message("Test Message", 
                "Some message");

            //m.text = "changed message";

            try
            {
                m.Title = "Test Message";
                m.Text = "";

            } catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            } catch (Exception ex)
            {
                Console.WriteLine("Some other problem occurred");
            }

            m.ShowMessage();
        }
    }
}