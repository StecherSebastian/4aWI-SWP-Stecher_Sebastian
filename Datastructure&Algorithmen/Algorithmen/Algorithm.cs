using Common;

namespace Algorithmen
{
    public class Algorithm<T> where T : IComparable<T>
    {
        public Algorithm() { }
        public virtual void Sort(ISortableDatastructure<T> d) { }
    }
}