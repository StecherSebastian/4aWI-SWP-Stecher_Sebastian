using Common;

namespace Datastructure
{
    public class DoubleLinkedList<T>
    {
        private Node<T>? _Head;
        private Node<T>? _Last;
        public enum Direction
        {
            fromFirst,
            fromLast
        }
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
            else if (_Last != null)
            {
                _Last.Next = toAdd;
                toAdd.Previous = _Last;
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
            if (nodeBefore.Next != null)
                nodeBefore.Next.Previous = nodeToInsert;
            nodeBefore.Next = nodeToInsert;
            nodeToInsert.Previous = nodeBefore;
        }
        public void InsertBefore(T elementAfter, T elementToInsert)
        {
            if (_Head != null && _Head.Data != null && _Head.Data.Equals(elementAfter))
                AddFirst(elementToInsert);
            else
            {
                Node<T>? nodeAfter = GetNode(elementAfter);
                if (nodeAfter != null && nodeAfter.Previous != null)
                    InsertAfter(nodeAfter.Previous, elementToInsert);
                else AddFirst(elementToInsert);
            }
        }
        public void RemoveFirst()
        {
            if (_Head != null)
            {
                _Head = _Head.Next;
                _Head.Previous = null;
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
                else if (_Last.Previous != null)
                {
                    _Last.Previous.Next = null;
                    _Last = _Last.Previous;
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
                else if (nodeToRemove.Previous != null && nodeToRemove.Next != null )
                {
                    nodeToRemove.Next.Previous = nodeToRemove.Previous;
                    nodeToRemove.Previous.Next = nodeToRemove.Next;
                }
            }
        }
        public List<T> GetAllNodesData(Direction d)
        {
            List<T> values = new();
            Node<T>? current = d == Direction.fromFirst ? _Head : _Last;
            while (current != null)
            {
                values.Add(current.Data);
                current = d == Direction.fromFirst ? current.Next : current.Previous;
            }
            return values;
        }
        public Node<T>? GetNode(T element)
        {
            Node<T>? current = _Head;
            while (current != null)
            {
                if (current.Data != null && current.Data.Equals(element))
                    return current;
                else if (current.Data == null && element == null)
                    return current;
                current = current.Next;
            }
            return null;
        }
        public int? PosOfElement(T element, Direction d)
        {
            int pos;
            Node<T>? current;
            if (d == Direction.fromFirst)
            {
                pos = 0;
                current = _Head;
            }
            else
            {
                pos = -1;
                current = _Last;
            }
            while (current != null)
            {
                if (current.Data != null && current.Data.Equals(element))
                    return pos;
                else if (current.Data == null && element == null)
                    return pos;
                if (d == Direction.fromFirst)
                {
                    current = current.Next;
                    pos++;
                }
                else
                {
                    current = current.Previous;
                    pos--;
                }
            }
            return null;
        }
    }
}