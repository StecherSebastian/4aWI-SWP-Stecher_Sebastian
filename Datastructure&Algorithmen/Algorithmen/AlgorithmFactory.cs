namespace Algorithmen
{
    public class AlgorithmFactory<T> where T : IComparable<T>
    {
        public AlgorithmFactory() { }
        public virtual Algorithm<T> CreateAlgorithm() => new Algorithm<T>();
    }
}