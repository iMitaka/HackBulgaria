using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionsSolution
{
    public class ReverseComparer<T> : IComparer<T>
    {
        private IComparer<T> m_comparer;

        internal ReverseComparer(IComparer<T> comparer)
        {
            m_comparer = comparer;
        }

        public int Compare(T x, T y)
        {
            return -m_comparer.Compare(x, y);
        }
    }
}
