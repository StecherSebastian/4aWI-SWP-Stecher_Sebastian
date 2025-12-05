namespace Datastructure
{
    public class Stack<T> where T : IComparable<T>
    {
        private DoubleLinkedList<T> _List;
        public Stack() 
        {
            _List = new DoubleLinkedList<T>();
        }
        public void Push(T data) =>
            _List.AddLast(data);
        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cannot pop from empty stack");
            T removed = _List.Get(Size() - 1);
            _List.RemoveLast();
            return removed;
        }
        public int Size() =>
            _List.Count();
        public bool IsEmpty() =>
            _List.Count() == 0;
        public T Top()
        {
            return _List.Get(Size() - 1);
        }
    }
}