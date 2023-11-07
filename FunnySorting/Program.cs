using System.Diagnostics.Metrics;
using System;
using System.Reflection;

namespace SortingAgain
{
    internal class Program
    {
        public static void Main()
        {

            int[] arr = new int[50];
            Random random = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(1, 50);
            }

            Console.WriteLine("Массив:");
            Console.WriteLine(string.Join(" ", arr));

            Console.WriteLine("SelectionSort:");
            Console.WriteLine(string.Join(" ", SelectionSort(arr)));

            Console.WriteLine();


            // вывод результата всех сортировок
            /* 

            // вывод для пирамидальной сортировки
            int n = arr.Length;

            // HeapSort ob = new HeapSort();
            // ob.Sort(arr);
            // ob.PrintArray(arr);

            //вывод для сортировки слиянием
            Console.WriteLine("Сортировка слиянием");
            Console.WriteLine(string.Join(" ", MergeSort.Sort(arr)));



            //вывод для сортировки вставками
            Console.WriteLine("Сортировка вставками");
            Console.WriteLine(string.Join(" ", InsertionSort(arr)));

            //вывод для сортировки Методол Шелла
            Console.WriteLine("Сортировка Методом Шелла");
            Console.WriteLine(string.Join(" ", ShellSort(arr)));

            //вывод для пузырьковой сортировки 
            Console.WriteLine("Пузырькова сортировка");
            Console.WriteLine(string.Join(" ", BubbleSort(arr)));

            */




        }

        public static int[] SelectionSort(int[] arr)
        {
            int length = arr.Length;

            for (int i = 0; i < length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    Swap(ref arr[i], ref arr[minIndex]);
                }
            }

            return arr;
        }

        public static int[] InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int currentValue = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > currentValue)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = currentValue;
            }

            return arr;
        }

        public static int[] ShellSort(int[] arr)
        {
            int n = arr.Length;
            int gap = 1;

            while (gap < n / 3)
            {
                gap = 3 * gap + 1;
            }

            while (gap >= 1)
            {
                for (int i = gap; i < n; i++)
                {
                    int currentValue = arr[i];
                    int j = i;

                    while (j >= gap && arr[j - gap] > currentValue)
                    {
                        arr[j] = arr[j - gap];
                        j -= gap;
                    }

                    arr[j] = currentValue;
                }
                gap /= 3;
            }

            return arr;
        }
        public static int[] BubbleSort(int[] arr)
        {
            bool swapped;
            int n = arr.Length;

            do
            {
                swapped = false;
                for (int i = 0; i < n - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        swapped = true;
                    }
                }
                n--;
            } while (swapped);

            return arr;
        }


        public static void QuickSort(int[] arr, int start, int end)
        {
            if (start >= end)
                return;

            int pivot = Partition(arr, start, end);
            QuickSort(arr, start, pivot - 1);
            QuickSort(arr, pivot + 1, end);
        }

        private static int Partition(int[] arr, int start, int end)
        {
            int marker = start;
            int pivotValue = arr[end];

            for (int i = start; i < end; i++)
            {
                if (arr[i] < pivotValue)
                {
                    int temp = arr[marker];
                    arr[marker] = arr[i];
                    arr[i] = temp;
                    marker += 1;
                }
            }

            arr[end] = arr[marker];
            arr[marker] = pivotValue;

            return marker;
        }

        public class MergeSort
        {
            public static int[] Sort(int[] arr)
            {
                if (arr.Length <= 1)
                    return arr;

                int midPoint = arr.Length / 2;

                int[] leftArr = arr.Take(midPoint).ToArray();
                int[] rightArr = arr.Skip(midPoint).ToArray();

                return Merge(Sort(leftArr), Sort(rightArr));
            }

            public static int[] Merge(int[] arr1, int[] arr2)
            {
                int[] merged = new int[arr1.Length + arr2.Length];
                int i = 0, j = 0, k = 0;

                while (i < arr1.Length && j < arr2.Length)
                {
                    if (arr1[i] <= arr2[j])
                        merged[k++] = arr1[i++];
                    else
                        merged[k++] = arr2[j++];
                }

                while (i < arr1.Length)
                    merged[k++] = arr1[i++];

                while (j < arr2.Length)
                    merged[k++] = arr2[j++];

                return merged;
            }
        }

        public class HeapSort
        {
            public void Sort(int[] arr)
            {
                int n = arr.Length;

                BuildMaxHeap(arr, n);

                for (int i = n - 1; i > 0; i--)
                {
                    Swap(arr, 0, i);
                    Heapify(arr, i, 0);
                }
            }

            private void BuildMaxHeap(int[] arr, int n)
            {
                for (int i = n / 2 - 1; i >= 0; i--)
                    Heapify(arr, n, i);
            }

            private void Heapify(int[] arr, int n, int i)
            {
                int largest = i;
                int left = 2 * i + 1;
                int right = 2 * i + 2;

                if (left < n && arr[left] > arr[largest])
                    largest = left;

                if (right < n && arr[right] > arr[largest])
                    largest = right;

                if (largest != i)
                {
                    Swap(arr, i, largest);
                    Heapify(arr, n, largest);
                }
            }

            private void Swap(int[] arr, int i, int j)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }

            public void PrintArray(int[] arr)
            {
                int n = arr.Length;
                for (int i = 0; i < n; ++i)
                {
                    Console.Write(arr[i] + " ");
                }
                Console.WriteLine();
            }

        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

    }
}