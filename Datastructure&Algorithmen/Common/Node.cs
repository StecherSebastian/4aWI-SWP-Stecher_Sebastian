namespace Common
{
    public class Node<T>(T t) : IComparable<Node<T>>
    {
        public Node<T>? Next;
        public Node<T>? Previous;
        public T Data = t;
        public override bool Equals(object? obj)
        {
            if (obj is not Node<T> other) return false;
            else return EqualityComparer<T>.Default.Equals(Data, other.Data);
        }
        public override int GetHashCode()
        {
            if (Data == null) return 0;
            else return EqualityComparer<T>.Default.GetHashCode(Data);
        }
        public int CompareTo(Node<T>? other)
        {
            if (other == null) return 1;
            else return Comparer<T>.Default.Compare(Data, other.Data);
        }
    }
}