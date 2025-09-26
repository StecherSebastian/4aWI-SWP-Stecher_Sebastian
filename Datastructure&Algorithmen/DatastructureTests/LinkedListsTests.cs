using Datastructure;

namespace DatastructureTests
{
    public class SimpleLinkedListUnitTests
    {
        [Test]
        public void AddLast_AddObject_ReturnsObject()
        {
            Person person = new("Sebastian");
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(person);
            Assert.That(linkedList.Head?.Data, Is.EqualTo(person));
        }
        [Test]
        public void GetAllNodes_AddObjects_ReturnsListNodes()
        {
            Person person = new("Lukas");
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(person);
            linkedList.AddLast(person);
            Assert.That(linkedList.GetAllNodes(), Is.EqualTo(new List<Person> { person, person }));
        }
        [Test]
        public void Contains_ReturnsBool()
        {
            Person person1 = new("Matthias");
            Person person2 = new("Florian");
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(person1);
            linkedList.AddLast(person2);
            Assert.That(linkedList.Contains(person2), Is.True);
        }
    }
}