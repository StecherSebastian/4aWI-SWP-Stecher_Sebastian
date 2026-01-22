using Common;
using System.Numerics;

namespace Algorithmen
{
    public class BucketSortStrategy<T> : ISortStrategy<T> where T : INumber<T>
    {
        private readonly InsertionSortStrategy<T> _InsertionSort;

        public BucketSortStrategy() => _InsertionSort = new();

        public void Sort(ISortableDatastructure<T> d)
        {
            if (d == null)
                throw new ArgumentNullException(nameof(d));
            int n = d.Count();
            if (n <= 1)
                return;
            T? first = d.Get(0);
            if (first is null)
                throw new InvalidOperationException("Null values are not supported for numeric sorting.");
            T min = first;
            T max = first;
            for (int i = 1; i < n; i++)
            {
                T value = d.Get(i)!;
                if (value is null)
                    throw new InvalidOperationException("Null values are not supported for numeric sorting.");
                if (value < min) min = value;
                if (value > max) max = value;
            }
            if (min == max)
                return;
            List<List<T>> buckets = new();
            for (int i = 0; i < n; i++)
            {
                buckets.Add(new List<T>());
            }
            for (int i = 0; i < n; i++)
            {
                T value = d.Get(i)!;
                if (value is null)
                    throw new InvalidOperationException("Null values are not supported for numeric sorting.");
                double normalized = double.CreateTruncating(value - min) / double.CreateTruncating(max - min + T.One);
                int bi = (int)(normalized * n);
                if (bi == n) bi = n - 1;
                buckets[bi].Add(value);
            }
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                _InsertionSort.Sort(buckets[i]);
                for (int j = 0; j < buckets[i].Count(); j++)
                {
                    d.Set(index++, buckets[i][j]);
                }
            }
        }
        public void Sort(IList<T> d)
        {
            if (d == null)
                throw new ArgumentNullException(nameof(d));
            int n = d.Count();
            if (n <= 1)
                return;
            T min = d[0];
            T max = d[0];
            for (int i = 1; i < n; i++)
            {
                T value = d[i];
                if (value is null)
                    throw new InvalidOperationException("Null values are not supported for numeric sorting.");
                if (value < min) min = value;
                if (value > max) max = value;
            }
            if (min == max)
                return;
            List<List<T>> buckets = new();
            for (int i = 0; i < n; i++)
            {
                buckets.Add(new List<T>());
            }
            for (int i = 0; i < n; i++)
            {
                T value = d[i];
                if (value is null)
                    throw new InvalidOperationException("Null values are not supported for numeric sorting.");
                double normalized = double.CreateTruncating(value - min) / double.CreateTruncating(max - min + T.One);
                int bi = (int)(normalized * n);
                if (bi == n) bi = n - 1;
                buckets[bi].Add(value);
            }
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                _InsertionSort.Sort(buckets[i]);
                for (int j = 0; j < buckets[i].Count(); j++)
                {
                    d[index++] = buckets[i][j];
                }
            }
        }
    }
}