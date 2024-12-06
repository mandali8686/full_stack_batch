// 1. What type would you choose for the following “numbers”?
// A person’s telephone number: string
// A person’s height: float or double
// A person’s age: int
// A person’s gender: enum or string
// A person’s salary: decimal
// A book’s ISBN: string
// A book’s price: decimal
// A book’s shipping weight: float or double
// A country’s population: ulong
// The number of stars in the universe: double
// The number of employees in SMBs in the UK: int or uint
//
//2. What are the difference between value type and reference type variables? What is boxing and unboxing?
// Value Type: Stores data directly
// Reference Type: Stores references to the data
//
// Boxing: Converting a value type to a reference type.
// Unboxing: Converting a reference type back to a value type.
// 
//3. What is meant by the terms managed resource and unmanaged resource in .NET?
// Managed Resource: Handled by .NET runtime (e.g., memory allocation).
// Unmanaged Resource: External to .NET runtime (e.g., file handles).
//
// 4. Whats the purpose of Garbage Collector in .NET?
// Automatically manages memory by reclaiming unused objects.

Console.WriteLine("Enter your favorite color:");
string color = Console.ReadLine();

Console.WriteLine("Enter your astrology sign:");
string sign = Console.ReadLine();

Console.WriteLine("Enter your street number:");
string street = Console.ReadLine();

Console.WriteLine($"Your hacker name is {color}{sign}{street}");
