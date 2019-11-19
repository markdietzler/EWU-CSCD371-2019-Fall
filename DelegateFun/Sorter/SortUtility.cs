using System;

namespace Sorter
{
    public class SortUtility
    {
        public delegate bool AnalyzeInts(int thisOne, int thatOne);

        /// <summary>
        /// Standard insertion sort for int arrays
        /// </summary>
        /// <param name="rawArrayToSort">Array to sort</param>
        /// <param name="analyze">Delegate taking the place of compareTo</param>
        /// <returns>Sorted array</returns>
        public int[] SelectionSortUtil(int[] rawArrayToSort, AnalyzeInts analyze)
        {
            if(rawArrayToSort is null || analyze is null)
            {
                throw new ArgumentNullException(nameof(rawArrayToSort));
            }

            for (int start = 0; start < rawArrayToSort.Length -1 ; start ++)
            {
                int low = start;
                for(int search = start + 1; search < rawArrayToSort.Length; search++)
                {
                    if(analyze(rawArrayToSort[search], rawArrayToSort[low]))
                    {
                        low = search;
                    }

                } //end of inner for

                //do the swapping-pokey, and move them all around
                int swap = rawArrayToSort[low];
                rawArrayToSort[low] = rawArrayToSort[start];
                rawArrayToSort[start] = swap;

            } //end of outer for

            return rawArrayToSort;
        }

    }
}
