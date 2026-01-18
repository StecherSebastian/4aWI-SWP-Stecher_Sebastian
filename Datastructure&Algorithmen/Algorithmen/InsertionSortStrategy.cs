using Common;

namespace Algorithmen
{
    public class InsertionSortStrategy<T> : ISortStrategy<T> where T : IComparable<T>
    {
        public void Sort(ISortableDatastructure<T> d)
        {
            int count = d.Count();
            if (count < 0) return;
            for (int i = 1; i < count; i++)
            {
                T? toSort = d.Get(i);
                int j = i - 1;
                while (j >= 0 && (toSort == null ? d.Get(j) != null : d.Get(j) != null && toSort.CompareTo(d.Get(j)) < 0))
                {
                    d.Set(j + 1, d.Get(j));
                    j--;
                }
                d.Set(j + 1, toSort);
            }
        }
        public void Sort(IList<T> d)
        {
            int count = d.Count();
            if (count < 0) return;
            for (int i = 1; i < count; i++)
            {
                T? toSort = d[i];
                int j = i - 1;
                while (j >= 0 && (toSort == null ? d[j] != null : d[j] != null && toSort.CompareTo(d[j]) < 0))
                {
                    d[j + 1] = d[j];
                    j--;
                }
                d[j + 1] = toSort;
            }
        }
    }
}