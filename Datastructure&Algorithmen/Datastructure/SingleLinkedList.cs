using Common;

namespace Datastructure
{
    public class SingleLinkedList<T>
    {
        private Node<T>? _Head;
        private Node<T>? _Last;
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
                if (_Last != null)
                {
                    _Last.Next = toAdd;
                    _Last = toAdd;
                }
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
        public void RemoveFirst()
        {
            if (_Head != null)
            {
                _Head = _Head.Next;
                if (_Head == null)
                    _Last = null;
            }
        }
        public void RemoveLast()
        {
            if (_Last != null)
            {
                if (_Head == _Last)
                {
                    _Head = null;
                    _Last = null;
                }
                else
                {
                    Node<T>? nodeBefore = GetNodeBefore(_Last.Data);
                    if (nodeBefore != null)
                    {
                        nodeBefore.Next = null;
                        _Last = nodeBefore;
                    }
                }
            }
        }
        public void Remove(T element)
        {
            Node<T>? nodeToRemove = GetNode(element);
            if (nodeToRemove != null)
            {
                if (nodeToRemove.Equals(_Head))
                    RemoveFirst();
                else if (nodeToRemove.Equals(_Last))
                    RemoveLast();
                else
                {
                    Node<T>? nodeBefore = GetNodeBefore(element);
                    if (nodeBefore != null)
                        nodeBefore.Next = nodeToRemove.Next;
                }
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
                else if (current.Data == null && toFind == null)
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
                else if (current.Next != null && current.Next.Data == null && toFind == null)
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
                else if (current.Data == null && toFind == null)
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
                else if (current.Data == null && toFind == null)
                    return count;
                current = current.Next;
                count++;
            }
            return null;
        }
    }
}