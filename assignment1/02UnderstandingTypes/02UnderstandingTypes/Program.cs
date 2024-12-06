// See https://aka.ms/new-console-template for more information

Console.WriteLine($"sbyte: Size = {sizeof(sbyte)} bytes, Min = {sbyte.MinValue}, Max = {sbyte.MaxValue}");
Console.WriteLine($"byte: Size = {sizeof(byte)} bytes, Min = {byte.MinValue}, Max = {byte.MaxValue}");
Console.WriteLine($"short: Size = {sizeof(short)} bytes, Min = {short.MinValue}, Max = {short.MaxValue}");
Console.WriteLine($"ushort: Size = {sizeof(ushort)} bytes, Min = {ushort.MinValue}, Max = {ushort.MaxValue}");
Console.WriteLine($"int: Size = {sizeof(int)} bytes, Min = {int.MinValue}, Max = {int.MaxValue}");
Console.WriteLine($"uint: Size = {sizeof(uint)} bytes, Min = {uint.MinValue}, Max = {uint.MaxValue}");
Console.WriteLine($"long: Size = {sizeof(long)} bytes, Min = {long.MinValue}, Max = {long.MaxValue}");
Console.WriteLine($"ulong: Size = {sizeof(ulong)} bytes, Min = {ulong.MinValue}, Max = {ulong.MaxValue}");
Console.WriteLine($"float: Size = {sizeof(float)} bytes, Min = {float.MinValue}, Max = {float.MaxValue}");
Console.WriteLine($"double: Size = {sizeof(double)} bytes, Min = {double.MinValue}, Max = {double.MaxValue}");
Console.WriteLine($"decimal: Size = {sizeof(decimal)} bytes, Min = {decimal.MinValue}, Max = {decimal.MaxValue}");

Console.WriteLine("Enter centuries:");
int centuries = int.Parse(Console.ReadLine());

long years = centuries * 100;
long days = years * 36524 / 100;
long hours = days * 24;
long minutes = hours * 60;
long seconds = minutes * 60;
long milliseconds = seconds * 1000;
long microseconds = milliseconds * 1000;
long nanoseconds = microseconds * 1000;

Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");

//
// 1. Divide int by 0: Throws DivideByZeroException.
// 2. Divide double by 0: Results in Infinity.
// 3. Overflow int: Wraps around
// 4. x = y++; vs. x = ++y;:
// y++: assign y, then increment
// ++y: increment y, then assign
// 5. break, continue, return:
// break: Exits loop.
// continue: Skips to next iteration.
// return: Exits method.
// 6. for statement parts: Initialization, condition, increment.
// 7. = vs. ==:
//  =: Assignment.
//  ==: Equality check.
// 8. for (; true;) ;: Compiles, infinite loop.
// 9. Underscore _ in switch: Default case.
// 10. foreach requirement: Implements IEnumerable.

//Fizzbuzz
for (int i = 1; i <= 100; i++) {
    if (i % 15 == 0) Console.WriteLine("FizzBuzz");
    else if (i % 3 == 0) Console.WriteLine("Fizz");
    else if (i % 5 == 0) Console.WriteLine("Buzz");
    else Console.WriteLine(i);
}


//Guess Number
int correctNumber = new Random().Next(1, 4);
Console.WriteLine("Guess a number between 1 and 3:");
int guessedNumber = int.Parse(Console.ReadLine());

if (guessedNumber < 1 || guessedNumber > 3) Console.WriteLine("Out of range!");
else if (guessedNumber < correctNumber) Console.WriteLine("Too low!");
else if (guessedNumber > correctNumber) Console.WriteLine("Too high!");
else Console.WriteLine("Correct!");

//Pyramaid

for (int i = 1; i <= 5; i++) {
    Console.Write(new string(' ', 5 - i));
    Console.WriteLine(new string('*', 2 * i - 1));
}

//Birthdate

DateTime birthDate = new DateTime(2000, 1, 1); // Example birth date
int daysOld = (DateTime.Now - birthDate).Days;
int daysToNextAnniversary = 10000 - (daysOld % 10000);
Console.WriteLine($"Days old: {daysOld}, Next 10,000-day anniversary in {daysToNextAnniversary} days.");


//Time Greeting

int hour = DateTime.Now.Hour;

if (hour >= 5 && hour < 12) Console.WriteLine("Good Morning");
if (hour >= 12 && hour < 17) Console.WriteLine("Good Afternoon");
if (hour >= 17 && hour < 21) Console.WriteLine("Good Evening");
if (hour >= 21 || hour < 5) Console.WriteLine("Good Night");

//Counting Increment
for (int outer = 1; outer <= 4; outer++) {
    for (int inner = 0; inner <= 24; inner += outer) {
        Console.Write(inner + " ");
    }
    Console.WriteLine();
}


