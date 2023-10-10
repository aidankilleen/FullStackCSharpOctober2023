string message = "this is a\n \"message\"";

Console.WriteLine(message);
Console.WriteLine("one\ttwo\tthree");
string filename = "c:\\program files\\some file.exe";

Console.WriteLine(filename);

string name = "Aidan";
message = "Welcome " + name;
Console.WriteLine(message);

message = string.Format("Welcome {0}", name);
Console.WriteLine(message);

// raw string - indicated using @
string rawstring = @"c:\program files\somefile.txt";

Console.WriteLine(rawstring);

message = @"this 
            is 
            a multiline
            string";

Console.WriteLine(message);


// interpolated strings 
message = $"Welcome { name }";

Console.WriteLine(message);

int a = 10;
int b = 20;

Console.WriteLine($" { a } + { b } = { a + b }");

// Math class contains static math functions
// Math.


Random rg = new Random();
int r = rg.Next(100);

// interpolate an expression using a ternary operator
Console.WriteLine($"{ r } is { (r > 50 ? "big" : "small") }");


// you can combine raw and interpolated strings

a = rg.Next(100);
b = rg.Next(100);
message = $@"

{ a }
+{ b }
_________
{a + b}

";


Console.WriteLine(  message);






