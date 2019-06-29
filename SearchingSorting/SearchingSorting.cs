using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingSorting
{
  
    public class SortingAlgorithms
    {        
        public int[] DoInsertionSort(int[] nums)
        {
            int[] arr = new int[nums.Length];
            nums.CopyTo(arr,0);        
            for (var i = 0; i < arr.Length - 1; i++)
            {
                var indexMin = i;

                for(var j = i + 1; j < arr.Length; j++)
                {
                    if(arr[indexMin] > arr[j])
                    {
                        indexMin = j;
                    }
                }
                var temp = arr[indexMin];
                arr[indexMin] = arr[i];
                arr[i] = temp;
            }
            return arr;
        }
        public int[] DoShellSort(int[] nums)
        {
            int[] arr = new int[nums.Length];
            nums.CopyTo(arr, 0);

            int gap = arr.Length / 2;

            while(gap > 0)
            {
                int j = 0;
                for(int i = gap; i < arr.Length; i++)
                {
                    int temp = arr[i]; 
                    for(j = i; j >= gap && arr[j -gap] > temp; j -= gap)
                    {
                        arr[j] = arr[j - gap];
                    }
                    arr[j] = temp;
                }
                gap = gap / 2;
            }
            return arr;
        }
        public int[] DoMergeSort(int[] nums, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                DoMergeSort(nums, left, middle);
                DoMergeSort(nums, middle + 1, right);

                //Main Merge
                int[] leftArray = new int[middle - left + 1];
                int[] rightArray = new int[right - middle];

                Array.Copy(nums, left, leftArray, 0, middle - left + 1);
                Array.Copy(nums, middle + 1, rightArray, 0, right - middle);

                int i = 0;
                int j = 0;
                for (int k = left; k < right + 1; k++)
                {
                    if (i == leftArray.Length)
                    {
                        nums[k] = rightArray[j];
                        j++;
                    }
                    else if (j == rightArray.Length)
                    {
                        nums[k] = leftArray[i];
                        i++;
                    }
                    else if (leftArray[i] <= rightArray[j])
                    {
                        nums[k] = leftArray[i];
                        i++;
                    }
                    else
                    {
                        nums[k] = rightArray[j];
                        j++;
                    }
                }
            }
            return nums;
        }
        
    }

    public class SearchingAlgorithms
    {        
        
        public bool DoLinearSearch(int[] nums, int item)
        {           
            for(int i = 0; i < nums.Length; i++)
            {
                if(nums[i] == item)
                {
                    return true;
                }
            }

            return false;
        }
        public bool DoBinarySearch(int[] nums, int item)
        {
            int startpt = 0;
            int endpt = nums.Length - 1;
            int midpt = (startpt + endpt) / 2;
            
            while (midpt >= 0) {

                midpt = (startpt + endpt) / 2;
                
                if (nums[midpt] < item)
                {
                    startpt = midpt + 1;

                }
                else if (nums[midpt] > item)
                {
                    endpt = midpt - 1;

                }
                else
                {
                    Console.WriteLine(nums[midpt]);
                    return true;
                }
            }      
            
            return false;
        }
    }
}
