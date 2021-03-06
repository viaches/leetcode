﻿namespace HeapSort
{
    public static class Heap
    {
        public static void Sort(int[] array)
        {
            var length = array.Length;

            for (int k = (length / 2) - 1; k >= 0; k--) // we don't need to ho through the whole array to build a binary heap
            {
                Sink(array, k, length);
            }

            while (length >= 1)
            {
                Exchange(array, 0, length - 1); // move the biggest element to the end
                Sink(array, 0, --length); // now we consider that the last element is sorted so exclude it from sink routine
            }
        }

        private static void Sink(int[] array, int k, int length)
        {
            while (k < length - 1) //length is the end of array
            {
                var bigIndex = k;
                var childl = 2 * k + 1;
                var childr = childl + 1;
                if (childl < length && array[childl] > array[bigIndex])
                    bigIndex = childl;

                if (childr < length && array[childr] > array[bigIndex])
                    bigIndex = childr;

                if (bigIndex == k) return;
                Exchange(array, k, bigIndex);
                k = bigIndex;
            }
        }

        private static void Exchange(int[] array, int firstIndex, int secondIndex)
        {
            var temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }

    }
}
