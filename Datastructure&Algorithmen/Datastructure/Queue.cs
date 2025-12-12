namespace Datastructure
{
    public class Queue<T> where T : IComparable<T>
    {
        private SingleLinkedList<T> _List;
        public Queue() =>
            _List = new SingleLinkedList<T>();
        public void Enqueue(T item) =>
            _List.AddLast(item);
        public T? Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cannot dequeue from empty queue");
            T? removed = Peek();
            _List.RemoveFirst();
            return removed;
        }
        public T? Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cannot peek empty queue");
            return _List.Get(0);
        }
        public int Size() =>
            _List.Count();
        public bool IsEmpty() =>
            Size() == 0;
    }
}
