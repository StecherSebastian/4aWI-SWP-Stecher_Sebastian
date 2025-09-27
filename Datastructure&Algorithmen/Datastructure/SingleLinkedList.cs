using Common;

namespace Datastructure
{
    public class SingleLinkedList<T>
    {
        public Node<T>? Head;
        public Node<T> Last = null!;
        public void AddFirst(T data)
        {
            Node<T> toAdd = new(data);
            toAdd.Next = Head;
            Head = toAdd;
        }
        public void AddLast(T data)
        {
            if (Head == null)
            {
                Head = new(data);
                Last = Head;
            }
            else
            {
                Node<T> toAdd = new(data);
                Last.Next = toAdd;
                Last = toAdd;
            }
        }
        public void InsertAfter(T elementBefore, T elementToInsert)
        {
            Node<T>? nodeBefore = GetNode(elementBefore);
            if (nodeBefore != null) InsertNode(nodeBefore, elementToInsert);
        }
        public void InsertBefore(T elementAfter, T elementToInsert)
        {
            if (Head != null && Head.Data != null && Head.Data.Equals(elementAfter))
                AddFirst(elementToInsert);
            else
            {
                Node<T>? nodeBefore = GetNodeBefore(elementAfter);
                if (nodeBefore != null) InsertNode(nodeBefore, elementToInsert);
            }
        }
        private void InsertNode(Node<T> nodeBefore, T elementToInsert)
        {
            Node<T> nodeToInsert = new(elementToInsert);
            nodeToInsert.Next = nodeBefore.Next;
            nodeBefore.Next = nodeToInsert;
        }
        public List<T> GetAllNodesData()
        {
            List<T> result = new();
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
        public int? PosOfElement(T toFind)
        {
            int? count = 0;
            Node<T>? current = Head;
            while (current != null)
            {
                if (current.Data != null && current.Data.Equals(toFind))
                    return count;
                current = current.Next;
                count++;
            }
            return null;
        }
    }
}