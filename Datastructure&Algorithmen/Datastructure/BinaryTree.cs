using Common;
using System.Xml.Linq;

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
        public void Delete(T toDelete)
        {
            if (_Root == null)
                throw new InvalidOperationException("Can not delete from empty tree.");
            if (_Root.Left == null && _Root.Right == null)
            {
                if ((_Root.Data == null && toDelete == null) ||
                    (_Root.Data != null && _Root.Data.Equals(toDelete)))
                {
                    _Root = null;
                    return;
                }
            }
            Queue<Node<T>> queue = new();
            queue.Enqueue(_Root);
            Node<T>? current = null;
            Node<T>? nodeToDelete = null;
            while (!queue.IsEmpty())
            {
                current = queue.Dequeue();
                if (current == null)
                    continue;
                if ((current.Data == null && toDelete == null) ||
                    (current.Data != null && current.Data.Equals(toDelete)))
                {
                    nodeToDelete = current;
                }
                if (current.Right != null)
                    queue.Enqueue(current.Right);
                if (current.Left != null)
                    queue.Enqueue(current.Left);
            }
            if (nodeToDelete != null && current != null)
            {
                nodeToDelete.Data = current.Data;
                DeleteDeepest(current);
            }
        }
        private void DeleteDeepest(Node<T>? deepestNode)
        {
            if (_Root == null)
                return;
            if (_Root.Equals(deepestNode))
            {
                _Root = null;
                return;
            }
            Queue<Node<T>> queue = new();
            queue.Enqueue(_Root);
            Node<T>? current = null;
            while (!queue.IsEmpty())
            {
                current = queue.Dequeue();
                if (current == null)
                    continue;
                if (current.Right != null)
                {
                    if (current.Right.Equals(deepestNode))
                    {
                        current.Right = null;
                        return;
                    }
                    queue.Enqueue(current.Right);
                }
                if (current.Left != null)
                {
                    if (current.Left.Equals(deepestNode))
                    {
                        current.Left = null;
                        return;
                    }
                    queue.Enqueue(current.Left);
                }
            }
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
        public bool IsEmpty()
        {
            if (_Root == null) return true;
            else return false;
        }
    }
}