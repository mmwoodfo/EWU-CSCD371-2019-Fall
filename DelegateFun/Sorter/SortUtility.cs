using System;

namespace Sorter
{
    public delegate bool Compare(int first, int second);

    public class SortUtility
    {
        private int QuickSortPartition(int[] intArray, Compare comparer, int low, int high)
        {
            int pivot = intArray[high],
                        smaller = low - 1;

            for(int larger = low; larger < high; larger++)
            {
                if(comparer(intArray[larger], pivot))
                {
                    smaller++;

                    int temp1 = intArray[smaller];
                    intArray[smaller] = intArray[larger];
                    intArray[larger] = temp1;
                }
            }

            int temp2 = intArray[smaller + 1];
            intArray[smaller + 1] = intArray[high];
            intArray[high] = temp2;

            return smaller + 1;
        }

        public void QuickSort(int[] intArray, Compare comparer, int low, int high)
        {
            if(intArray is null)
            {
                throw new ArgumentNullException(nameof(intArray));
            }

            if(low < high)
            {
                int partitionIndex = QuickSortPartition(intArray, comparer, low, high);

                QuickSort(intArray, comparer, low, partitionIndex-1);
                QuickSort(intArray, comparer, partitionIndex+1, high);
            }
        }

    }
}
