namespace Common
{
    public interface ISortableDatastructure<T>
    {
        public int Count();
        public T Get(int pos);
        public void Swap(int indexA, int indexB);
    }
}