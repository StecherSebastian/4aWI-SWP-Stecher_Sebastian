using Common;

namespace Algorithmen
{
    public class BubbleSortStrategy<T> : ISortStrategy<T>
    {
        private void SwapNodes(Node<T> nodeA, Node<T> nodeB)
        {
            if (nodeA == null || nodeB == null) return;
            T temp = nodeA.Data;
            nodeA.Data = nodeB.Data;
            nodeB.Data = temp;
        }
        public void Sort(Node<T>? head)
        {
            if (head == null) return;
            bool swapped;
            Node<T>? current;
            do
            {
                swapped = false;
                current = head;
                while (current != null)
                {
                    if (current.Next != null && current.CompareTo(current.Next) > 0)
                    {
                        SwapNodes(current, current.Next);
                        swapped = true;
                    }
                    current = current.Next;
                }
            }
            while (swapped);
        }
    }
}
