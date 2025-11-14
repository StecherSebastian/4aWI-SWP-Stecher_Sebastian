using Algorithmen;
using Common;

namespace Datastructure
{
    public class DoubleLinkedList<T> : ISortableDatastructure<T> where T : IComparable<T>
    {
        private Node<T>? _Head;
        private Node<T> _Last = null!;
        private int _Count;
        public enum Direction
        {
            fromFirst,
            fromLast
        }
        private ISortStrategy<T> _SortStrategy;
        public DoubleLinkedList(ISortStrategy<T>? sortStrategy = null)
        {
            _SortStrategy = sortStrategy ?? new BubbleSortStrategy<T>();
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
            _Count++;
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
            _Count++;
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
            _Count++;
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
        public void Set(int pos, T? element)
        {
            Node<T> node = GetNode(pos);
            node.Data = element;
        }
        public int Count()
        {
            return _Count;
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
        public Node<T> GetNode(int pos)
        {
            if (pos > _Count || pos < 0)
                throw new ArgumentOutOfRangeException(nameof(pos), "Position is out of range.");
            Node<T>? current = _Head;
            for (int i = 0; i < pos; i++)
            {
                if (current == null)
                    throw new InvalidOperationException("List structure is corrupted.");
                current = current.Next;
            }
            if (current == null)
                throw new InvalidOperationException("List structure is corrupted.");
            return current;
        }
        public T Get(int pos)
        {
            if (pos > _Count || pos < _Count * -1)
                throw new ArgumentOutOfRangeException(nameof(pos), "Position is out of range.");
            Node<T>? current;
            int steps = pos < 0 ? pos + _Count : pos;
            current = pos < 0 ? _Last : _Head;
            for (int i = 0; i < pos; i++)
            {
                if (current == null)
                    throw new InvalidOperationException("List structure is corrupted.");
                if (pos < 0)
                    current = current.Previous;
                else
                    current = current.Next;
            }
            if (current == null)
                throw new InvalidOperationException("List structure is corrupted.");
            return current.Data;
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
        public void Swap(int indexA, int indexB)
        {
            Node<T> nodeA = GetNode(indexA);
            Node<T> nodeB = GetNode(indexB);
            T temp = nodeA.Data;
            nodeA.Data = nodeB.Data;
            nodeB.Data = temp;
        }
        public void ChangeSortStrategy(ISortStrategy<T> sortStrategy)
        {
            _SortStrategy = sortStrategy;
        }
        public void Sort()
        {
            if (_Head != null)
                _SortStrategy.Sort(this);
        }
    }
}