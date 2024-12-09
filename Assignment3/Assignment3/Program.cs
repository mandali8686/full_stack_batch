// See https://aka.ms/new-console-template for more information

// 1. Reverse number array

using Assignment3;

static int[] GenerateNumbers(int length = 10)
{
    int[] numbers = new int[length];
    for (int i = 0; i < length; i++)
    {
        numbers[i] = i + 1;
    }

    return numbers;
}

static void ReverseNumbers(int[] numbers)
{
    for (int i = 0; i < numbers.Length / 2; i++)
    {
        int temp = numbers[i];
        numbers[i] = numbers[numbers.Length - 1 - i];
        numbers[numbers.Length - 1 - i] = temp;
    }
    // return numbers;
}

static void PrintNumbers(int[] numbers)
{
    Console.WriteLine(string.Join(", ", numbers));
}

static void Main(string[] args)
{
    int[] numbers = GenerateNumbers(10);
    ReverseNumbers(numbers);
    PrintNumbers(numbers);
}


// int[] numbers = GenerateNumbers(10);
// ReverseNumbers(numbers);
// PrintNumbers(numbers);

// 2. Fibonacci sequence
static int Fibonacci(int n)
{
    int a = 1, b = 1;
    if (n <= 2)
        return a;
    for (int i = 3; i <= n; i++)
    {
        int temp = b;
        b = a + b;
        a = temp;
    }

    return b;
}

// Console.WriteLine(Fibonacci(7));

//Ball and Color
Color red = new Color(255, 0, 0);
Ball myBall = new Ball(red, 5);

myBall.Throw();
myBall.Throw();
myBall.Pop();
myBall.Throw();

Console.WriteLine($"Ball thrown {myBall.GetThrowCount()} times");