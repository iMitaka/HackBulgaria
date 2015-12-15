using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionsSolution
{
    public static class SortAndSearchExtensions
    {
        public static IList<T> BubbleSort<T>(this IList<T> list)
        {
            var comparer = Comparer<T>.Default;
            int i = list.Count - 1;
            while (i > 0)
            {
                int swap = 0;
                for (int j = 0; j < i; j++)
                {

                    if (comparer.Compare(list[j], list[j + 1]) > 0)
                    {
                        var temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                        swap = j;
                    }
                }
                i = swap;
            }
            
            var newList = new List<T>();
            for (int index = 0; index < list.Count; index++)
            {
                newList.Add(list[index]);
            }
            return newList;
        }
        public static IList<T> BubbleSort<T>(this IList<T> list, IComparer<T> comparer)
        {
            int i = list.Count - 1;
            while (i > 0)
            {
                int swap = 0;
                for (int j = 0; j < i; j++)
                {

                    if (comparer.Compare(list[j], list[j + 1]) > 0)
                    {
                        var temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                        swap = j;
                    }
                }
                i = swap;
            }

            var newList = new List<T>();
            for (int index = 0; index < list.Count; index++)
            {
                newList.Add(list[index]);
            }
            return newList;
        }

        public static IList<T> SelectionSort<T>(this IList<T> list) 
        {
            int min;
            T temp;
            var comparer = Comparer<T>.Default;

            for (int i = 0; i < list.Count - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < list.Count; j++)
                    if (comparer.Compare(list[j], list[min]) < 0)
                        min = j;

                // swap the values
                temp = list[i];
                list[i] = list[min];
                list[min] = temp;
            }

            var newList = new List<T>();
            for (int index = 0; index < list.Count; index++)
            {
                newList.Add(list[index]);
            }
            return newList;
        }

        public static IList<T> SelectionSort<T>(this IList<T> list, IComparer<T> comparer)
        {
            int min;
            T temp;

            for (int i = 0; i < list.Count - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < list.Count; j++)
                    if (comparer.Compare(list[j], list[min]) < 0)
                        min = j;

                // swap the values
                temp = list[i];
                list[i] = list[min];
                list[min] = temp;
            }

            var newList = new List<T>();
            for (int index = 0; index < list.Count; index++)
            {
                newList.Add(list[index]);
            }
            return newList;
        }

        public static IEnumerable<T> Quicksort<T>(this IEnumerable<T> list) 
        {
            var comparer = Comparer<T>.Default;
            if (list.Count() < 2)
                return list;

            T pivot = list.First();

            // partition
            Stack<T> lowers = new Stack<T>(), greaters = new Stack<T>();

            foreach (T item in list.Skip(1)) // skip the pivot
                (comparer.Compare(item, pivot) < 0 ? lowers : greaters).Push(item);

            return Quicksort(lowers)
                .Concat(new T[] { pivot })
                .Concat(Quicksort(greaters));
        }

        public static IEnumerable<T> Quicksort<T>(this IEnumerable<T> list, IComparer<T> comparer)
        {
            if (list.Count() < 2)
                return list;

            T pivot = list.First();

            // partition
            Stack<T> lowers = new Stack<T>(), greaters = new Stack<T>();

            foreach (T item in list.Skip(1)) // skip the pivot
                (comparer.Compare(item, pivot) < 0 ? lowers : greaters).Push(item);

            return Quicksort(lowers, comparer)
                .Concat(new T[] { pivot })
                .Concat(Quicksort(greaters, comparer));
        }
    }
}
