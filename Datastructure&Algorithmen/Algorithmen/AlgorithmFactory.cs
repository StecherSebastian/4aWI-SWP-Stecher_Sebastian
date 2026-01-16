namespace Algorithmen
{
    public abstract class AlgorithmFactory<T> where T : IComparable<T>
    {
        public abstract Algorithm<T> CreateAlgorithm();
    }
}