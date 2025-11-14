using Common;

namespace Algorithmen
{
    public class BubbleSortStrategy<T> : ISortStrategy<T> where T : IComparable<T>
    {
        public void Sort(ISortableDatastructure<T> d)
        {
            int n = d.Count();
            if (n <= 0) return;
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < n - 1; i ++)
                {
                    T? a = d.Get(i);
                    T? b = d.Get(i + 1);
                    if (a == null && b != null)
                        continue;
                    else if (a != null && b == null)
                    {
                        d.Swap(i, i + 1);
                        swapped = true;
                        continue;
                    }
                    else if (a != null && b != null && a.CompareTo(b) > 0)
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
