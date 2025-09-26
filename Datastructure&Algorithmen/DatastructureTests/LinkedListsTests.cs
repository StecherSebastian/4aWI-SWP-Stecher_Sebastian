using Common;
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
        public void GetAllNodesData_AddObjects_ReturnsListObjects()
        {
            Person person = new("Lukas");
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(person);
            linkedList.AddLast(person);
            Assert.That(linkedList.GetAllNodesData(), Is.EqualTo(new List<Person> { person, person }));
        }
        [Test]
        public void GetNode_ReturnsNode()
        {
            Person person1 = new("Lukas");
            Person person2 = new("Matthias");
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(person1);
            linkedList.AddLast(person2);
            Assert.That(linkedList.GetNode(person2), Is.EqualTo(new Node<Person>(person2)));
        }
        [Test]
        public void GetNodeBefore_ReturnsNode()
        {
            Person person1 = new("Lukas");
            Person person2 = new("Matthias");
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(person1);
            linkedList.AddLast(person2);
            Assert.That(linkedList.GetNodeBefore(person2), Is.EqualTo(new Node<Person>(person1)));
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