namespace Common
{
    public class Node<T>(T t)
    {
        public Node<T>? Next;
        public T Data = t;
    }
}