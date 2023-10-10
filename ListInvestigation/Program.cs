using System.Collections;


Console.WriteLine("List Investigation");


string[] list = { "Alice", "Bob", "Carol", "Dan" };


foreach(string name  in list) 
{
    Console.WriteLine(name);
}

Console.WriteLine($"The list has { list.Length } members");

for (int i = 0; i < list.Length; i++)
{
    Console.WriteLine(list[i]);
}

// index starts at 0
// out of bounds will thrown an exception
// Console.WriteLine(list[4]);



// arrays are immutable

// Collection classes
Console.WriteLine("=================================");
ArrayList al = new ArrayList();

al.Add("alice");
al.Add("bob");
al.Add("carol");
al.Add("dan");
// al.Add(999);  ArrayList is not type safe

foreach (string item in al)
{
    Console.WriteLine($"{ item }");
}

// all data types are derived from object
object o;
int xxx;

// there are no built-in data types in c#

Console.WriteLine("============================");
// generic collection class

List<string> names = new List<string>();

names.Add("alice");
names.Add("bob");
names.Add("carol");
names.Add("dan");
// names.Add(9999);


foreach (string name in names)
{
    Console.WriteLine(name);
}


Console.WriteLine("==============================");
names.ForEach((name) =>
{
    Console.WriteLine(name);
});















