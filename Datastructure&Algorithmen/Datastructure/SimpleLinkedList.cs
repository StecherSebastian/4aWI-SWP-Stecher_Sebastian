using Common;

namespace Datastructure
{
    public class SimpleLinkedList<T>
    {
        public Node<T> Head { get; set; } = null!;
        public void AddLast(T data)
        {
            if (Head == null)
            {
                Head = new Node<T>(data);
            }
            else
            {
                Node<T> toAdd = new Node<T>(data);
                Node<T> current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = toAdd;
            }
        }
        public List<T> GetAllNodes()
        {
            List<T> result = new List<T>();
            Node<T>? current = Head;
            while (current != null)
            {
                result.Add(current.Data);
                current = current.Next;
            }
            return result;
        }
        public bool Contains(T objectToFind)
        {
            Node<T>? current = Head;
            while (current != null)
            {
                if (current.Data != null && current.Data.Equals(objectToFind))
                    return true;
                current = current.Next;
            }
            return false;
        }
    }
}