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
        public void Pop() =>
            _List.RemoveLast();
        public int Size() =>
            _List.Count();
        public bool IsEmpty() =>
            _List.Count() == 0;
    }
}