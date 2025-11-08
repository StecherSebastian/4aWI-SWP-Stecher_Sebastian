using Common;

namespace Algorithmen
{
    public class BubbleSortStrategy<T> : ISortStrategy<T> where T : IComparable<T>
    {
        public void Sort(ISortableDatastructure<T> d)
        {
            int n = d.Count();
            if (n < 0) return;
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < n - 1; i ++)
                {
                    if (d.Get(i).CompareTo(d.Get(i + 1)) > 0)
                    {
                        d.Swap(i, i + 1);
                        swapped = true;
                    }
                }
            }
            while (swapped);
        }
    }
}
