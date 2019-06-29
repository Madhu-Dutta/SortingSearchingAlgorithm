using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SearchingSorting;
using System.Diagnostics;

namespace SearchingSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            //TEST ON CSV UNSORTED DATA
            //Reading the csv file
            StreamReader sr = new StreamReader("../../unsorted_numbers.csv");
            string data = sr.ReadToEnd();//.ReadLine();

            string[] str = data.Split(new char[1] { '\n' });
            int[] numArr = str.Select(c => Convert.ToInt32(c.ToString())).ToArray();

            //TEST ON SMALL ARRAY
            int[] testArrSmall = { 1, 22, 3, 56, 7, 23, 8, 24, 9, 25, 10, 26, 11, 27, 12, 28, 13, 837493, 89, 321 };
            //Console.WriteLine("Original Array: " + string.Join(",", testArrSmall));
            //Console.WriteLine("##############################################");
            //Console.WriteLine();

            //TEST ON LARGE ARRAY
            int[] testArrLg = new int[100000000];
            for (int i = 0; i < 100000000; i++)
            {
                testArrLg[i] = i;
            }

            //SORTING IMPLEMENTATIONS
            SortingAlgorithms sort = new SortingAlgorithms();
            //INSERTION SORT IMPLEMENTATION
            int[] insertionsortedcsvdata;
            Stopwatch stopwatch = Stopwatch.StartNew();
            insertionsortedcsvdata = sort.DoInsertionSort(numArr);
            stopwatch.Stop();

            Console.WriteLine("*******************************************");

            //Console.WriteLine("Insertion Sorted Array: " + string.Join(",", insertionsortedcsvdata));
            Console.WriteLine("Insertion Sort took {0} ms" , stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Insertion Sort took {0} ticks", stopwatch.ElapsedTicks);

            Console.WriteLine("*********************************************");
           
            //SHELL SORT IMPLEMENTATION
            int[] shellsortedcsvdata;
            stopwatch = Stopwatch.StartNew();
            shellsortedcsvdata = sort.DoShellSort(numArr);
            stopwatch.Stop();

            //Console.WriteLine("Shell Sorted Array: " + string.Join(",", shellsortedcsvdata));
            Console.WriteLine("Shell Sort took {0} ms", stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Shell Sort took {0} ticks", stopwatch.ElapsedTicks);
            Console.WriteLine("*********************************************** ");


            //MERGE SORT IMPLEMENTATION            

            int[] mergesortedcsvdata;
            stopwatch = Stopwatch.StartNew();
            mergesortedcsvdata = sort.DoMergeSort(numArr, 0, numArr.Length-1);
            //mergesortedcsvdata = sort.DoMergeSort(testArrSmall, 0, testArrSmall.Length - 1);            
            stopwatch.Stop();

            //Console.WriteLine("Merge Sorted Array: " + string.Join(",", mergesortedcsvdata));
            Console.WriteLine("Merge Sort took {0} ms", stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Merge Sort took {0} ticks", stopwatch.ElapsedTicks);
            Console.WriteLine("##############################################");

            //SEARCHING IMPLEMENTATIONS
            SearchingAlgorithms search = new SearchingAlgorithms(); 
            
            //Find the largest number in the sorted csv file using binary and linear search
            int largestNum = shellsortedcsvdata[shellsortedcsvdata.Length - 1];

            bool found = false;
            stopwatch = Stopwatch.StartNew();
            found = search.DoBinarySearch(shellsortedcsvdata, largestNum);
            stopwatch.Stop();

            //Console.WriteLine("The Item exits: " + found);
            Console.WriteLine("Binary Search for the largest number: {0} took {1} ms", largestNum, stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Binary Search for the largest number: {0} took {1} ticks", largestNum, stopwatch.ElapsedTicks);

            stopwatch = Stopwatch.StartNew();
            found = search.DoLinearSearch(shellsortedcsvdata, largestNum);
            stopwatch.Stop();

            //Console.WriteLine("The Item exits: " + found);
            Console.WriteLine("Linear Search for the largest number: {0} took {1} ms", largestNum, stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Linear Search for the largest number: {0} took {1} ticks", largestNum, stopwatch.ElapsedTicks);
            Console.WriteLine("**************************************************************");

            //Find the largest number in the testArrLg using binary and linear search
           
            largestNum = testArrLg[testArrLg.Length - 1];
            
            stopwatch = Stopwatch.StartNew();
            found = search.DoBinarySearch(testArrLg, largestNum);
            stopwatch.Stop();            
            Console.WriteLine("Binary Search for the largest number: {0} took {1} ms", largestNum, stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Binary Search for the largest number: {0} took {1} ticks", largestNum, stopwatch.ElapsedTicks);

            stopwatch = Stopwatch.StartNew();
            found = search.DoLinearSearch(testArrLg, largestNum);
            stopwatch.Stop();
            Console.WriteLine("Linear Search for the largest number: {0} took {1} ms", largestNum, stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Linear Search for the largest number: {0} took {1} ticks", largestNum, stopwatch.ElapsedTicks);

            //Find every 1500 element using Binary and Linear Search
            for (int i = 0; i < shellsortedcsvdata.Length; i=i+1500)
            {
                stopwatch = Stopwatch.StartNew();
                found = search.DoBinarySearch(shellsortedcsvdata, shellsortedcsvdata[i]);
                stopwatch.Stop();
                Console.WriteLine("Binary Search of {0} took {1} ms", i + "th number: " + shellsortedcsvdata[i], stopwatch.ElapsedMilliseconds);
                Console.WriteLine("Binary Search of {0} took {1} ticks", i + "th number: " + shellsortedcsvdata[i], stopwatch.ElapsedTicks);

                stopwatch = Stopwatch.StartNew();
                found = search.DoLinearSearch(shellsortedcsvdata, shellsortedcsvdata[i]);
                stopwatch.Stop();
                Console.WriteLine("Linear Search of {0} took {1} ms", i + "th number: " + shellsortedcsvdata[i], stopwatch.ElapsedMilliseconds);
                Console.WriteLine("Linear Search of {0} took {1} ticks", i + "th number: " + shellsortedcsvdata[i], stopwatch.ElapsedTicks);
            }

            Console.Read();
        }
        
    }
}
