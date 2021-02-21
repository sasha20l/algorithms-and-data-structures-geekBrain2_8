using System;
using System.Collections.Generic;


namespace geekBrain2_8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[15];
            Random rnd = new Random();

            for (int i = 0; i < arr.Length; ++i)
                arr[i] = rnd.Next(-99, 100);

            Console.WriteLine(String.Join(" ", arr));
            BucketSort(arr);
            Console.WriteLine(String.Join(" ", arr));
            Console.ReadLine();
        }
        static void BucketSort(int[] a)
        {
            List<int>[] aux = new List<int>[a.Length];
            for (int i = 0; i < aux.Length; ++i)
                aux[i] = new List<int>();
            int minValue = a[0];
            int maxValue = a[0];
            for (int i = 1; i < a.Length; ++i)
            {
                if (a[i] < minValue)
                    minValue = a[i];
                else if (a[i] > maxValue)
                    maxValue = a[i];
            }
            double numRange = maxValue - minValue;
            for (int i = 0; i < a.Length; ++i)
            {
                int bcktIdx = (int)Math.Floor((a[i] - minValue) / numRange * (aux.Length - 1));
                aux[bcktIdx].Add(a[i]);
            }
            for (int i = 0; i < aux.Length; ++i)
                aux[i].Sort();
            int idx = 0;
            for (int i = 0; i < aux.Length; ++i)
            {
                for (int j = 0; j < aux[i].Count; ++j)
                    a[idx++] = aux[i][j];
            }
        }
    }
}

