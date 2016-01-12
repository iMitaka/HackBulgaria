using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousTypesAndNestedClasses
{
    public class Magazine : ISortable
    {
        public string Title { get; set; }

        public int ISBN { get; set; }
    }
}
