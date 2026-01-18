using Algorithmen;
using Common;

namespace AlgorithmenTests;

public class BucketSortTests
{
    [Test]
    public void Sort_AddMultipleDoubles_DoublesSorted()
    {
        MockSortable<double> list = new(new[] {4645.34, 123.22342, 23.234, 234.23 });
        BucketSortStrategy<double> sorter = new();
        sorter.Sort(list);
        Assert.That(list.ToList(), Is.EqualTo(new List<double> { 23.234, 123.22342, 234.23, 4645.34 }));
    }
    [Test]
    public void Sort_AddMultipleIntegers_IntegerssSorted()
    {
        MockSortable<int> list = new(new[] { 123, 45, 234, 1 });
        BucketSortStrategy<int> sorter = new();
        sorter.Sort(list);
        Assert.That(list.ToList(), Is.EqualTo(new List<int> { 1, 45, 123, 234 }));
    }
}
