using Common;
using Datastructure;

namespace DatastructureTests
{
    public class SimpleLinkedListUnitTests
    {
        [Test]
        public void AddFirst_AddObjects_ReturnsObjects()
        {
            Person person1 = new("Sebastian");
            Person person2 = new("Matthias");
            Person person3 = new("Fleisch");
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddFirst(person1);
            linkedList.AddFirst(person2);
            linkedList.AddFirst(person3);
            Assert.That(linkedList.GetAllNodesData(), Is.EqualTo(new List<Person> { person3, person2, person1 }));
        }
        [Test]
        public void AddLast_AddObject_ReturnsObject()
        {
            Person person = new("Sebastian");
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(person);
            Assert.That(linkedList.Head?.Data, Is.EqualTo(person));
        }
        [Test]
        public void InsertAfter_ReturnsObject()
        {
            Person person1 = new("Lukas");
            Person person2 = new("Matthias");
            Person person3 = new("Fleisch");
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(person1);
            linkedList.AddLast(person2);
            int? pos = linkedList.PosOfElement(person2);
            linkedList.InsertAfter(person1, person3);
            Assert.Multiple(() =>
            {
                Assert.That(linkedList.GetAllNodesData(), Is.EqualTo(new List<Person> { person1, person3, person2 }));
                Assert.That(linkedList.PosOfElement(person2), !Is.EqualTo(pos));
            });
        }
        [Test]
        public void InsertBefore_ReturnsObject()
        {
            Person person1 = new("Lukas");
            Person person2 = new("Matthias");
            Person person3 = new("Fleisch");
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(person1);
            linkedList.AddLast(person2);
            int? pos = linkedList.PosOfElement(person2);
            linkedList.InsertBefore(person2, person3);
            Assert.Multiple(() =>
            {
                Assert.That(linkedList.GetAllNodesData(), Is.EqualTo(new List<Person> { person1, person3, person2 }));
                Assert.That(linkedList.PosOfElement(person2), !Is.EqualTo(pos));
            });
        }
        [Test]
        public void InsertBefore_BeforeHead_ReturnsObject()
        {
            Person person1 = new("Lukas");
            Person person2 = new("Matthias");
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(person1);
            int? pos = linkedList.PosOfElement(person1);
            linkedList.InsertBefore(person1, person2);
            Assert.Multiple(() =>
            {
                Assert.That(linkedList.GetAllNodesData(), Is.EqualTo(new List<Person> { person2, person1 }));
                Assert.That(linkedList.PosOfElement(person1), !Is.EqualTo(pos));
            });
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
        [Test]
        public void PosOfElement_ReturnsInteger()
        {
            Person person1 = new("Matthias");
            Person person2 = new("Florian");
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(person1);
            linkedList.AddLast(person2);
            Assert.Multiple(() =>
            {
                Assert.That(linkedList.PosOfElement(person1), Is.EqualTo(0));
                Assert.That(linkedList.PosOfElement(person2), Is.EqualTo(1));
            });
        }
    }
}