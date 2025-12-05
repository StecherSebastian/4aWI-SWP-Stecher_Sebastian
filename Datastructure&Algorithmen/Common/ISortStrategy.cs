namespace Common
{
    public interface ISortStrategy<T>
    {
        public void Sort(ISortableDatastructure<T> datastructure);
    }
}