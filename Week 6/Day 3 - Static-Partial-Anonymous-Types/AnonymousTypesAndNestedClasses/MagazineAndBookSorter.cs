using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousTypesAndNestedClasses
{
    public static class MagazineAndBookSorter
    {
        private class Edition
        {
            public string EditionName { get; set; }
            public int Order { get; set; }
        }

        public static List<string> Sort(List<Book> books, List<Magazine> magazines)
        {
            List<Edition> edition = new List<Edition>();
            foreach (var book in books)
            {
                var editionItem = new Edition() { EditionName = book.Name, Order = book.Id };
                edition.Add(editionItem);
            }
            foreach (var magazine in magazines)
            {
                var editionItem = new Edition() { EditionName = magazine.Title, Order = magazine.ISBN };
                edition.Add(editionItem);
            }
            List<string> stringsList = new List<string>();
            var orderedEditions = edition.OrderBy(x => x.EditionName).ToList();

            while (true)
            {
                if (orderedEditions.Count < 1)
                {
                    break;
                }
                var tempEditionList = new List<Edition>();
                var currentItem = orderedEditions.FirstOrDefault();
                for (int i = 0; i < orderedEditions.Count; i++)
                {
                    if (orderedEditions[i].EditionName == currentItem.EditionName)
                    {
                        tempEditionList.Add(orderedEditions[i]);
                        orderedEditions.Remove(orderedEditions[i]);
                        i--;
                    }
                }
                var orderedTemp = tempEditionList.OrderBy(x => x.Order).ToList();
                foreach (var item in orderedTemp)
                {
                    stringsList.Add(string.Format("{0} - {1}", item.EditionName, item.Order));
                }
                orderedTemp.Clear();
            }

            return stringsList;
        }
    }
}
