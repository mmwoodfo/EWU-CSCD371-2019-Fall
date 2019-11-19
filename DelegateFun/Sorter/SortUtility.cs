using System;

namespace Sorter
{
    public delegate bool Compare(int first, int second);

    public class SortUtility
    {
        private static int QuickSortPartition(int[] intArray, Compare comparer, int low, int high)
        {
            int pivot = intArray[high],
                        smaller = low - 1;

            for (int larger = low; larger < high; larger++)
            {
                if (comparer(intArray[larger], pivot))
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

        private void QuickSortRecursion(int[] intArray, Compare comparer, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = QuickSortPartition(intArray, comparer, low, high);

                QuickSortRecursion(intArray, comparer, low, partitionIndex - 1);
                QuickSortRecursion(intArray, comparer, partitionIndex + 1, high);
            }
        }

        public void QuickSort(int[] intArray, Compare comparer)
        {
            if (intArray is null)
                throw new ArgumentNullException(nameof(intArray));
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            QuickSortRecursion(intArray, comparer, 0, intArray.Length - 1);
        }

    }
}
