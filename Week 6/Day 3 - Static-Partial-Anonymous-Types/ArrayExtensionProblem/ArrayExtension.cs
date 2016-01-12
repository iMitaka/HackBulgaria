using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExtensionProblem
{
    public static class ArrayExtension<T>
    {
        private static readonly char ReplacingValue;

        static ArrayExtension()
        {
            ReplacingValue = Configuration.ReplacingValue;
        }

        public static List<T> Intersect(List<T> firstList, List<T> secondList)
        {
            var newList = new List<T>();
            foreach (var item in firstList)
            {
                newList.Add(item);
            }
            newList.Intersect(secondList);

            return newList;
        }

        public static List<T> UnionAll(List<T> firstList, List<T> secondList)
        {
            var newList = new List<T>();
            foreach (var item in firstList)
            {
                newList.Add(item);
                if (secondList.Contains(item))
                {
                    var items = secondList.Where(x => x.Equals(item));
                    foreach (var secondItem in items)
                    {
                        newList.Add(secondItem);
                    }
                    for (int i = 0; i < secondList.Count; i++)
                    {
                        if (secondList[i].Equals(item))
                        {
                            secondList.Remove(item);
                            i--;
                        }
                    }
                }
            }
            foreach (var item in secondList)
            {
                newList.Add(item);
            }

            return newList;
        }

        public static List<T> Union(List<T> firstList, List<T> secondList)
        {
            var newList = new List<T>();
            foreach (var item in firstList)
            {
                newList.Add(item);
            }
            newList.Union(secondList);

            return newList;
        }

        public static string Join(List<string> list)
        {
            string result = string.Join(ReplacingValue.ToString(),list);
            return result;
        }

        public static char GetReplacingValue()
        {
            var currentDate = DateTime.Now.ToString();
            var dateNumbers = currentDate.Split(new char[] { '.', ':', 'г', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int sum = 0;
            foreach (var digit in dateNumbers)
            {
                if (digit.Length > 1)
                {
                    for (int i = 0; i < digit.Length; i++)
                    {
                        sum += int.Parse(digit[i].ToString());
                    }
                }
                else
                {
                    sum += int.Parse(digit);
                }
            }

            var stepTwo = sum % 25;
            var stepThree = stepTwo + 65;
            return (char)stepThree;
        }


    }
}
