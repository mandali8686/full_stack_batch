namespace ConsoleApp2;

public static class ExtensionMethodDemo
{
    public static string EvenOdd(this int num)
    {
        if (num % 2 == 0)
        {
            return "even";
        }
        else
        {
            return "odd";
        }
    }
}