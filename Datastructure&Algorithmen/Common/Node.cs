namespace Common
{
    public class Node<T>(T t)
    {
        public Node<T>? Next { get; set; }
        public T Data { get; set; } = t;
    }
}