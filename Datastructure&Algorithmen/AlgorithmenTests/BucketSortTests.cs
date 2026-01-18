using Algorithmen;

namespace AlgorithmenTests;
public class BucketSortTests
{
    [Test]
    public void Sort_DoublesInISortableDatastructure_DoublesSorted()
    {
        MockSortable<double> list = new(new[] {4645.34, 123.22342, 23.234, 234.23 });
        BucketSortStrategy<double> sorter = new();
        sorter.Sort(list);
        Assert.That(list.ToList(), Is.EqualTo(new List<double> { 23.234, 123.22342, 234.23, 4645.34 }));
    }
    [Test]
    public void Sort_IntegersInISortableDatastructure_IntegerssSorted()
    {
        MockSortable<int> list = new(new[] { 123, 45, 234, 1 });
        BucketSortStrategy<int> sorter = new();
        sorter.Sort(list);
        Assert.That(list.ToList(), Is.EqualTo(new List<int> { 1, 45, 123, 234 }));
    }
    [Test]
    public void Sort_DoublesInIList_DoublesSorted()
    {
        IList<double> list = new List<double> { 4645.34, 123.22342, 23.234, 234.23 };
        var sorter = new BucketSortStrategy<double>();
        sorter.Sort(list);
        Assert.That(list, Is.EqualTo(new List<double> { 23.234, 123.22342, 234.23, 4645.34 }));
    }
    [Test]
    public void Sort_IntegersInIList_IntegersSorted()
    {
        IList<int> list = new List<int> { 123, 45, 234, 1 };
        var sorter = new BucketSortStrategy<int>();
        sorter.Sort(list);
        Assert.That(list, Is.EqualTo(new List<int> { 1, 45, 123, 234 }));
    }
}