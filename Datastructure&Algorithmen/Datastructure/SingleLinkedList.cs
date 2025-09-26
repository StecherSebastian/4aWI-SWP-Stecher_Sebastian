using Common;

namespace Datastructure
{
    public class SingleLinkedList<T>
    {
        public Node<T>? Head;
        public Node<T> Last = null!;
        public void AddLast(T data)
        {
            if (Head == null)
            {
                Head = new Node<T>(data);
                Last = Head;
            }
            else
            {
                Node<T> toAdd = new Node<T>(data);
                Last.Next = toAdd;
                Last = toAdd;
            }
        }
        public List<T> GetAllNodesData()
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
        public Node<T>? GetNode(T toFind)
        {
            Node<T>? current = Head;
            while (current != null)
            {
                if (current.Data != null && current.Data.Equals(toFind))
                    return current;
                current = current.Next;
            }
            return null;
        }
        public Node<T>? GetNodeBefore(T toFind)
        {
            Node<T>? current = Head;
            while (current != null)
            {
                if (current.Next != null && current.Next.Data != null && current.Next.Data.Equals(toFind))
                    return current;
                current = current.Next;
            }
            return null;
        }
        public bool Contains(T toFind)
        {
            Node<T>? current = Head;
            while (current != null)
            {
                if (current.Data != null && current.Data.Equals(toFind))
                    return true;
                current = current.Next;
            }
            return false;
        }
    }
}