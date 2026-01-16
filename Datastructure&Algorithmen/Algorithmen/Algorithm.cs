using Common;

namespace Algorithmen
{
    public abstract class Algorithm<T> where T : IComparable<T>
    {
        public abstract void Sort(ISortableDatastructure<T> d);
    }
}