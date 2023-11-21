using System.Diagnostics.Metrics;
using System;
using System.Reflection;

namespace SortingAgain
{
    internal class Program
    {
        

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

        public class Node
        {
            public int data;
            public Node prev;
            public Node next;

            public Node(int d)
            {
                data = d;
                prev = null;
                next = null;
            }
        }

        public class DoublyLinkedList
        {
            public Node head;

            public DoublyLinkedList()
            {
                head = null;
            }

            public Node MergeSort(Node node)
            {
                if (node == null || node.next == null)
                {
                    return node;
                }

                Node middle = GetMiddle(node);
                Node nextOfMiddle = middle.next;

                middle.next = null;

                Node left = MergeSort(node);
                Node right = MergeSort(nextOfMiddle);

                Node sortedList = Merge(left, right);

                return sortedList;
            }

            private Node Merge(Node left, Node right)
            {
                if (left == null)
                {
                    return right;
                }

                if (right == null)
                {
                    return left;
                }

                Node result = null;

                if (left.data <= right.data)
                {
                    result = left;
                    result.next = Merge(left.next, right);
                    result.next.prev = result;
                }
                else
                {
                    result = right;
                    result.next = Merge(left, right.next);
                    result.next.prev = result;
                }

                return result;
            }

            private Node GetMiddle(Node node)
            {
                if (node == null)
                {
                    return node;
                }

                Node slow = node;
                Node fast = node;

                while (fast.next != null && fast.next.next != null)
                {
                    slow = slow.next;
                    fast = fast.next.next;
                }

                return slow;
            }

            public void PrintList(Node node)
            {
                Node last = null;
                while (node != null)
                {
                    Console.Write(node.data + " ");
                    last = node;
                    node = node.next;
                }
                Console.WriteLine();
            }

            public void AddNode(int data)
            {
                Node newNode = new Node(data);

                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    Node current = head;
                    while (current.next != null)
                    {
                        current = current.next;
                    }
                    current.next = newNode;
                    newNode.prev = current;
                }
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


            DoublyLinkedList dll = new DoublyLinkedList();
            dll.AddNode(5);
            dll.AddNode(2);
            dll.AddNode(8);
            dll.AddNode(1);
            dll.AddNode(9);

            Console.WriteLine("До сортировки:");
            dll.PrintList(dll.head);

            dll.head = dll.MergeSort(dll.head);

            Console.WriteLine("Сортировка слиянием:");
            dll.PrintList(dll.head);


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
    }
}