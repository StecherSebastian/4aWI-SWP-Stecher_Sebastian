namespace Datastructure
{
    public class Stack<T> where T : IComparable<T>
    {
        private SingleLinkedList<T> _List;
        public Stack() 
        {
            _List = new SingleLinkedList<T>();
        }
        public void Push(T data) =>
            _List.AddFirst(data);
        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cannot pop from empty stack");
            T removed = Top();
            _List.RemoveFirst();
            return removed;
        }
        public int Size() =>
            _List.Count();
        public bool IsEmpty() =>
            _List.Count() == 0;
        public T Top()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cannot get top from empty stack");
            return _List.Get(0);
        }
    }
}