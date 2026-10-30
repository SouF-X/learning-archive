using System;
class LinearSearchExample
{
    // Method for Performing Linear Search
    static int LinearSearch(int[] arr, int x)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            // Return the index of the element if found

            if (arr[i] == x)
                return i;
        }

        // Return -1 if the element is not found

        return -1;
    }

    static void Main(string[] args)
    {
        int[] arr = {64, 34, 25, 12, 22, 11, 90};
        int x = 200;

        Console.WriteLine("Original Array:");
        foreach(var item in arr)
            Console.Write(item + " ");

        int result = LinearSearch(arr, x);

        if(result == -1)
            Console.WriteLine($"\n\nElement {x} not found in the array.");
        else
            Console.WriteLine($"\n\nElement {x} found at index {result}.");
    }
}