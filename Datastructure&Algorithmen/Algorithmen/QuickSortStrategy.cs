using Common;

namespace Algorithmen
{
    public class QuickSortStrategy<T> : ISortStrategy<T> where T : IComparable<T>
    {
        public void Sort(ISortableDatastructure<T> d)
        {
            QuickSort(d, 0, d.Count() - 1);
        }
        public void QuickSort(ISortableDatastructure<T> d, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(d, low, high);
                QuickSort(d, low, pi - 1);
                QuickSort(d, pi + 1, high);
            }
        }
        private int Partition(ISortableDatastructure<T> d, int low, int high)
        {
            T? pivot = d.Get(high);
            int i = low - 1;
            for (int j = low; j <= high - 1; j++)
            {
                T? a = d.Get(j);
                if (a != null && a.CompareTo(pivot) <= 0)
                {
                    i++;
                    d.Swap(i, j);
                }
            }
            d.Swap(i + 1, high);
            return (i + 1);
        }
    }
}
