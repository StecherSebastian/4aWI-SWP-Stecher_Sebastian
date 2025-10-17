using Common;

namespace Datastructure
{
    public class DoubleLinkedList<T>
    {
        private Node<T>? _Head;
        private Node<T> _Last = null!;
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
            else
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
        public void BubbleSort()
        {
            bool swapped;
            T temp;
            Node<T>? current;
            do
            {
                swapped = false;
                current = _Head;
                while (current != null)
                {
                    if (current.Next != null && current.CompareTo(current.Next) > 0)
                    {
                        temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;
                        swapped = true;
                    }
                    current = current.Next;
                }
            }
            while (swapped);
        }
    }
}
