// See https://aka.ms/new-console-template for more information
//
// 1. When to use String vs. StringBuilder in C#?
// Use String when the string value is immutable.
// Use StringBuilder when you expect frequent changes to the string.
// 2. What is the base class for all arrays in C#?
// System.Array.
// 3. How do you sort an array in C#?
// Use the Array.Sort() 
// 4. What property of an array object can be used to get the total number of elements in an array?
//   Length
// 5. Can you store multiple data types in System.Array?
// No 
// 6. What’s the difference between the System.Array.CopyTo() and System.Array.Clone()?
// CopyTo() copies the elements to an existing array, starting at a specific index.
// Clone() creates a shallow copy of the entire array and returns a new array.

//Copy Array

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Select Question and Solution:");
            Console.WriteLine("1. Copy an Array");
            Console.WriteLine("2. Manage a List");
            Console.WriteLine("3. Find Primes in Range");
            Console.WriteLine("4. Rotate Array and Sum");
            Console.WriteLine("5. Find Longest Sequence");
            Console.WriteLine("6. Find Most Frequent Number");
            Console.WriteLine("7. Reverse a String");
            Console.WriteLine("8. Reverse Words in Sentence");
            Console.WriteLine("9. Extract Palindromes");
            Console.WriteLine("10. Parse URL");
            Console.WriteLine("11. Exit");
            Console.Write("Your choice: ");
            
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CopyArray();
                    break;
                case "2":
                    ManageList();
                    break;
                case "3":
                    FindPrimes();
                    break;
                case "4":
                    RotateArrayAndSum();
                    break;
                case "5":
                    FindLongestSequence();
                    break;
                case "6":
                    FindMostFrequentNumber();
                    break;
                case "7":
                    ReverseString();
                    break;
                case "8":
                    ReverseWordsInSentence();
                    break;
                case "9":
                    ExtractPalindromes();
                    break;
                case "10":
                    ParseURL();
                    break;
                case "11":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void CopyArray()
    {
        int[] originalArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] copiedArray = new int[originalArray.Length];

        for (int i = 0; i < originalArray.Length; i++)
        {
            copiedArray[i] = originalArray[i];
        }

        Console.WriteLine("Original Array: " + string.Join(", ", originalArray));
        Console.WriteLine("Copied Array: " + string.Join(", ", copiedArray));
    }

    static void ManageList()
    {
        List<string> list = new List<string>();
        while (true)
        {
            Console.WriteLine("Enter command (+ item, - item, or -- to clear):");
            string input = Console.ReadLine();
            if (input.StartsWith("+"))
            {
                list.Add(input.Substring(2));
            }
            else if (input.StartsWith("-"))
            {
                list.Remove(input.Substring(2));
            }
            else if (input == "--")
            {
                list.Clear();
            }
            Console.WriteLine("Current List: " + string.Join(", ", list));
        }
    }

    static void FindPrimes()
    {
        Console.WriteLine("Enter start number:");
        int start = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter end number:");
        int end = int.Parse(Console.ReadLine());

        var primes = FindPrimesInRange(start, end);
        Console.WriteLine("Primes: " + string.Join(", ", primes));
    }

    static int[] FindPrimesInRange(int startNum, int endNum)
    {
        List<int> primes = new List<int>();
        for (int i = startNum; i <= endNum; i++)
        {
            if (IsPrime(i))
            {
                primes.Add(i);
            }
        }
        return primes.ToArray();
    }

    static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    static void RotateArrayAndSum()
    {
        Console.WriteLine("Enter array elements (space-separated):");
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        Console.WriteLine("Enter number of rotations:");
        int k = int.Parse(Console.ReadLine());

        int[] sum = new int[arr.Length];
        for (int r = 0; r < k; r++)
        {
            RotateArrayRight(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                sum[i] += arr[i];
            }
        }

        Console.WriteLine("Rotated Sum: " + string.Join(", ", sum));
    }

    static void RotateArrayRight(int[] arr)
    {
        int last = arr[arr.Length - 1];
        for (int i = arr.Length - 1; i > 0; i--)
        {
            arr[i] = arr[i - 1];
        }
        arr[0] = last;
    }

    static void FindLongestSequence()
    {
        Console.WriteLine("Enter array elements (space-separated):");
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int maxCount = 0, currentCount = 1, bestElement = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1])
            {
                currentCount++;
            }
            else
            {
                currentCount = 1;
            }

            if (currentCount > maxCount)
            {
                maxCount = currentCount;
                bestElement = arr[i];
            }
        }

        Console.WriteLine($"Longest Sequence: {string.Join(" ", Enumerable.Repeat(bestElement, maxCount))}");
    }

    static void FindMostFrequentNumber()
    {
        Console.WriteLine("Enter array elements (space-separated):");
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        var frequency = arr.GroupBy(x => x).OrderByDescending(g => g.Count()).ThenBy(g => Array.IndexOf(arr, g.Key)).First();
        Console.WriteLine($"Most Frequent: {frequency.Key} (occurs {frequency.Count()} times)");
    }

    static void ReverseString()
    {
        Console.WriteLine("Enter a string:");
        string input = Console.ReadLine();

        // Method 1: Using char array
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        Console.WriteLine("Reversed (Method 1): " + new string(charArray));

        // Method 2: Using for-loop
        string reversed = "";
        for (int i = input.Length - 1; i >= 0; i--)
        {
            reversed += input[i];
        }
        Console.WriteLine("Reversed (Method 2): " + reversed);
    }

    static void ReverseWordsInSentence()
    {
        Console.WriteLine("Enter a sentence:");
        string sentence = Console.ReadLine();

        char[] delimiters = { '.', ',', ':', ';', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' };
        string[] words = sentence.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        Array.Reverse(words);

        Console.WriteLine("Reversed Sentence: " + string.Join(" ", words));
    }

    static void ExtractPalindromes()
    {
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();

        char[] delimiters = { ' ', '.', ',', '!', '?' };
        var words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        var palindromes = words.Where(w => w.SequenceEqual(w.Reverse())).Distinct().OrderBy(w => w);

        Console.WriteLine("Palindromes: " + string.Join(", ", palindromes));
    }

    static void ParseURL()
    {
        Console.WriteLine("Enter URL:");
        string url = Console.ReadLine();

        var uri = new Uri(url.Contains("://") ? url : "http://" + url);
        Console.WriteLine($"Protocol: {uri.Scheme}");
        Console.WriteLine($"Server: {uri.Host}");
        Console.WriteLine($"Resource: {uri.PathAndQuery.TrimStart('/')}");
    }
}

