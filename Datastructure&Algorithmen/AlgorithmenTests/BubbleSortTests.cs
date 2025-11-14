using Algorithmen;
using Common;

namespace AlgorithmenTests
{
    public class BubbleSortTests
    {
        [Test]
        public void Sort_AddMultipleObjects_ObjectsSorted()
        {
            Person person1 = new("Sebastian");
            Person person2 = new("Lukas");
            Person person3 = new("Stephan");
            Person? personNull = null;
            MockSortable<Person> linkedList = new(new[] { person1, person2, person3, personNull });
            BubbleSortStrategy<Person> sorter = new();
            sorter.Sort(linkedList);
            Assert.That(linkedList.ToList(), Is.EqualTo(new List<Person?> { personNull, person2, person1, person3 }));
        }
    }
}