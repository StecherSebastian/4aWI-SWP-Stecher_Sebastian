using Common;

namespace AlgorithmenTests
{
    public class MockSortable<T> : ISortableDatastructure<T> where T : IComparable<T>
    {
        private readonly List<T> _Data;
        public MockSortable(IEnumerable<T> items) => _Data = new List<T>(items);
        public int Count() => _Data.Count;
        public T Get(int pos) => _Data[pos];
        public void Set(int pos, T element) => _Data[pos] = element;
        public void Swap(int indexA, int indexB)
        {
            var temp = _Data[indexA];
            _Data[indexA] = _Data[indexB];
            _Data[indexB] = temp;
        }
        public List<T> ToList() => new List<T>(_Data);
    }
}
