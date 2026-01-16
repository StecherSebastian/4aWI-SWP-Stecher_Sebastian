namespace Algorithmen
{
    public class BubbleSortFactory<T> : AlgorithmFactory<T> where T : IComparable<T>
    {
        public BubbleSortFactory() {}
        public override Algorithm<T> CreateAlgorithm()
        {
            return new BubbleSort<T>();
        }
    }
}