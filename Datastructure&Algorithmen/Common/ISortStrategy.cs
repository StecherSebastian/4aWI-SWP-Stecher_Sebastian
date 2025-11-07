namespace Common
{
    public interface ISortStrategy<T>
    {
        public void Sort(Node<T> head);
    }
}