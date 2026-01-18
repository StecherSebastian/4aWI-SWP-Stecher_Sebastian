namespace Common
{
    public interface ISortStrategy<T>
    {
        public void Sort(ISortableDatastructure<T> datastructure);
        public void Sort(IList<T> datastructure);
    }
}