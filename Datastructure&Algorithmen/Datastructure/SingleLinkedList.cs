using Common;

namespace Datastructure
{
    public class SingleLinkedList<T>
    {
        private Node<T>? _Head;
        private Node<T> _Last = null!;
        public void AddFirst(T data)
        {
            Node<T> toAdd = new(data);
            toAdd.Next = _Head;
            _Head = toAdd;
            if (_Last == null)
                _Last = _Head;
        }
        public void AddLast(T data)
        {
            if (_Head == null)
            {
                _Head = new(data);
                _Last = _Head;
            }
            else
            {
                Node<T> toAdd = new(data);
                _Last.Next = toAdd;
                _Last = toAdd;
            }
        }
        public void InsertAfter(T elementBefore, T elementToInsert)
        {
            Node<T>? nodeBefore = GetNode(elementBefore);
            if (nodeBefore != null) InsertAfter(nodeBefore, elementToInsert);
            else AddLast(elementToInsert);
        }
        private void InsertAfter(Node<T> nodeBefore, T elementToInsert)
        {
            Node<T> nodeToInsert = new(elementToInsert);
            nodeToInsert.Next = nodeBefore.Next;
            nodeBefore.Next = nodeToInsert;
        }
        public void InsertBefore(T elementAfter, T elementToInsert)
        {
            if (_Head != null && _Head.Data != null && _Head.Data.Equals(elementAfter))
                AddFirst(elementToInsert);
            else
            {
                Node<T>? nodeBefore = GetNodeBefore(elementAfter);
                if (nodeBefore != null) InsertAfter(nodeBefore, elementToInsert);
                else AddFirst(elementToInsert);
            }
        }
        public List<T> GetAllNodesData()
        {
            List<T> result = new();
            Node<T>? current = _Head;
            while (current != null)
            {
                result.Add(current.Data);
                current = current.Next;
            }
            return result;
        }
        public Node<T>? GetNode(T toFind)
        {
            Node<T>? current = _Head;
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
            Node<T>? current = _Head;
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
            Node<T>? current = _Head;
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
            Node<T>? current = _Head;
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