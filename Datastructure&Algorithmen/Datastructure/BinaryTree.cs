using Common;

namespace Datastructure
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        private Node<T>? _Root;
        public BinaryTree() { }
        public Node<T> Insert(T data)
        {
            Node<T> nodeToInsert = new(data);
            if (_Root == null)
            {
                _Root = nodeToInsert;
                return _Root;
            }
            Queue<Node<T>> q = new();
            q.Enqueue(_Root);
            while (!q.IsEmpty())
            {
                Node<T>? curr = q.Dequeue();
                if (curr == null) 
                    continue;
                if (curr.Left != null)
                    q.Enqueue(curr.Left);
                else
                {
                    curr.Left = new Node<T>(data);
                    return _Root;
                }
                if (curr.Right != null)
                    q.Enqueue(curr.Right);
                else
                {
                    curr.Right = new Node<T>(data);
                    return _Root;
                }
            }
            return _Root;
        }
        public List<T?> Traversal()
        {
            List<T?> treeData = new();
            TraversalHelper(_Root, treeData);
            return treeData;
        }
        private void TraversalHelper(Node<T>? node, List<T?> result)
        {
            if (node == null) return;
            result.Add(node.Data);
            TraversalHelper(node.Left, result);
            TraversalHelper(node.Right, result);
        }
    }
}
