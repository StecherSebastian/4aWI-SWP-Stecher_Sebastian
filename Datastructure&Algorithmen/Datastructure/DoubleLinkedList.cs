using Common;

namespace Datastructure
{
    public class DoubleLinkedList<T>
    {
        private Node<T>? _Head;
        private Node<T> _Last = null!;
        public void AddFirst(T data)
        {
            Node<T> toAdd = new(data);
            toAdd.Next = _Head;
            if (_Head != null)
                _Head.Previous = toAdd;
            _Head = toAdd;
            if (_Last == null)
                _Last = _Head;
        }
        public void AddLast(T data)
        {
            Node<T> toAdd = new(data);
            if (_Head == null)
            {
                _Head = toAdd;
                _Last = _Head;
            }
            else
            {
                _Last.Next = toAdd;
                toAdd.Previous = _Last;
                _Last = toAdd;
            }
        }
        public List<T> GetAllNodesData()
        {
            List<T> values = new();
            Node<T>? current = _Head;
            while (current != null)
            {
                values.Add(current.Data);
                current = current.Next;
            }
            return values;
        }
    }
}
