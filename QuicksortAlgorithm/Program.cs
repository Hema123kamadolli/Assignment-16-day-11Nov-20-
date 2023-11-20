using System;
using System.Diagnostics;


namespace QuicksortAlgorithm
{
    internal class Program
    {
        static void Main()
        {

            //int[] array = { 12, 4, 5, 6, 7, 3, 1, 15 };

            // Get user input for array elements
            Console.Write("Enter the array elements separated by space: ");
            string input = Console.ReadLine();

            // Split the input string into an array of strings
            string[] stringArray = input.Split(' ');

            // Convert the array of strings to an array of integers
            int[] array = new int[stringArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (!int.TryParse(stringArray[i], out array[i]))
                {
                    Console.WriteLine($"Invalid input. Element at index {i} is not a valid integer.");
                    return;
                }
            }
            Console.WriteLine("Original array: " + string.Join(", ", array));
            QuickSort(array, 0, array.Length - 1);

            Console.WriteLine("Sorted array: " + string.Join(", ", array));
            Console.WriteLine("Is array sorted correctly? " + IsSorted(array));


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            stopwatch.Stop();
            Console.WriteLine("Time complexity analysis: " + stopwatch.Elapsed.TotalMilliseconds + " milliseconds");


            Stopwatch mergeSortStopwatch = new Stopwatch();
            mergeSortStopwatch.Start();
            mergeSortStopwatch.Stop();
            Console.WriteLine("Merge Sort time: " + mergeSortStopwatch.Elapsed.TotalMilliseconds + " milliseconds");

            Console.ReadKey();
        }

        static void QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(array, low, high);

                QuickSort(array, low, partitionIndex - 1);
                QuickSort(array, partitionIndex + 1, high);
            }
        }

        static int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(ref array[i], ref array[j]);
                }
            }

            Swap(ref array[i + 1], ref array[high]);
            return i + 1;
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static bool IsSorted(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[i - 1])
                    return false;
            }
            return true;
        }

        static int[] GenerateRandomArray(int size)
        {
            Random random = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next();
            }

            return array;
        }

        static void MergeSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;

                MergeSort(array, low, mid);
                MergeSort(array, mid + 1, high);

                Merge(array, low, mid, high);
            }
        }

        static void Merge(int[] array, int low, int mid, int high)
        {
            int n1 = mid - low + 1;
            int n2 = high - mid;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            Array.Copy(array, low, leftArray, 0, n1);
            Array.Copy(array, mid + 1, rightArray, 0, n2);

            int i = 0, j = 0, k = low;

            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else
                {
                    array[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                array[k] = leftArray[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                array[k] = rightArray[j];
                j++;
                k++;
            }
        }
    }
}
