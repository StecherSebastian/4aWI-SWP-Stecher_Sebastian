using Common;
using Datastructure;

namespace DatastructureTests
{
    public class SimpleLinkedListUnitTests
    {
        private Person _Person1;
        private Person _Person2;
        private Person _Person3;
        private Person? _PersonNull;
        [SetUp]
        public void Setup()
        {
            _Person1 = new("Sebastian");
            _Person2 = new("Lukas");
            _Person3 = new("Stephan");
            _PersonNull = null;
        }
        [Test]
        public void AddFirst_AddMultipleObjects_ObjectsInCorrectOrder()
        {
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddFirst(_Person1);
            linkedList.AddFirst(_Person2);
            linkedList.AddFirst(_Person3);
            Assert.That(linkedList.GetAllNodesData(), Is.EqualTo(new List<Person> { _Person3, _Person2, _Person1 }));
        }
        [Test]
        public void AddFirt_AddNull_ObjectsInCorrectOrder()
        {
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddFirst(_Person1);
            linkedList.AddFirst(_PersonNull);
            Assert.That(linkedList.GetAllNodesData(), Is.EqualTo(new List<Person?> { _PersonNull, _Person1 }));
        }
        [Test]
        public void AddLast_AddMultipleObjects_ObjectsInCorrectOrder()
        {
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            linkedList.AddLast(_Person2);
            linkedList.AddLast(_Person3);
            Assert.That(linkedList.GetAllNodesData(), Is.EqualTo(new List<Person> { _Person1, _Person2, _Person3}));
        }
        [Test]
        public void AddLast_AddNull_ObjectsInCorrectOrder()
        {
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            linkedList.AddLast(_PersonNull);
            Assert.That(linkedList.GetAllNodesData(), Is.EqualTo(new List<Person?> { _Person1, _PersonNull }));
        }
        [Test]
        public void InsertAfter_InsertBetween_ObjectsInCorrectOrder()
        {
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            linkedList.AddLast(_Person2);
            int? pos = linkedList.PosOfElement(_Person2);
            linkedList.InsertAfter(_Person1, _Person3);
            Assert.Multiple(() =>
            {
                Assert.That(linkedList.GetAllNodesData(), Is.EqualTo(new List<Person> { _Person1, _Person3, _Person2 }));
                Assert.That(linkedList.PosOfElement(_Person2), !Is.EqualTo(pos));
            });
        }
        [Test]
        public void InsertAfter_ObjectBeforeDoesNotExist_AddLast()
        {
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            linkedList.InsertAfter(_Person3, _Person2);
            Assert.That(linkedList.GetAllNodesData(), Is.EqualTo(new List<Person> { _Person1, _Person2 }));
        }
        [Test]
        public void InsertAfter_InsertNull_ObjectsInCorrectOrder()
        {
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            linkedList.InsertAfter(_Person1, _PersonNull);
            Assert.That(linkedList.GetAllNodesData(), Is.EqualTo(new List<Person> { _Person1, _PersonNull }));
        }
        [Test]
        public void InsertBefore_InsertBetween_ObjectsInCorrectOrder()
        {
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            linkedList.AddLast(_Person2);
            int? pos = linkedList.PosOfElement(_Person2);
            linkedList.InsertBefore(_Person2, _Person3);
            Assert.Multiple(() =>
            {
                Assert.That(linkedList.GetAllNodesData(), Is.EqualTo(new List<Person> { _Person1, _Person3, _Person2 }));
                Assert.That(linkedList.PosOfElement(_Person2), !Is.EqualTo(pos));
            });
        }
        [Test]
        public void InsertBefore_InsertBeforeHead_ObjectsInCorrectOrder()
        {
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            int? pos = linkedList.PosOfElement(_Person1);
            linkedList.InsertBefore(_Person1, _Person2);
            Assert.Multiple(() =>
            {
                Assert.That(linkedList.GetAllNodesData(), Is.EqualTo(new List<Person> { _Person2, _Person1 }));
                Assert.That(linkedList.PosOfElement(_Person1), !Is.EqualTo(pos));
            });
        }
        [Test]
        public void InsertBefore_ObjectAfterDoesNotExist_AddFirst()
        {
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            linkedList.InsertBefore(_Person3, _Person2);
            Assert.That(linkedList.GetAllNodesData(), Is.EqualTo(new List<Person> { _Person2, _Person1 }));
        }
        [Test]
        public void InsertBefore_InsertNull_ObjectsInCorrectOrder()
        {
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            linkedList.InsertBefore(_Person1, _PersonNull);
            Assert.That(linkedList.GetAllNodesData(), Is.EqualTo(new List<Person> { _PersonNull, _Person1 }));
        }
        [Test]
        public void GetAllNodesData_AddMultipleObjects_ReturnsListObjects()
        {
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            linkedList.AddLast(_Person2);
            Assert.That(linkedList.GetAllNodesData(), Is.EqualTo(new List<Person> { _Person1, _Person2 }));
        }
        [Test]
        public void GetNode_ObjectExists_ReturnsNode()
        {
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            linkedList.AddLast(_Person2);
            Assert.That(linkedList.GetNode(_Person2), Is.EqualTo(new Node<Person>(_Person2)));
        }
        [Test]
        public void GetNodeBefore_ObjectExists_ReturnsNode()
        {
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            linkedList.AddLast(_Person2);
            Assert.That(linkedList.GetNodeBefore(_Person2), Is.EqualTo(new Node<Person>(_Person1)));
        }
        [Test]
        public void Contains_ObjectExists_ReturnsTrue()
        {
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            linkedList.AddLast(_Person2);
            Assert.That(linkedList.Contains(_Person2), Is.True);
        }
        [Test]
        public void PosOfElement_AddMultipleObjects_ReturnsCorrectPosition()
        {
            SingleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            linkedList.AddLast(_Person2);
            Assert.Multiple(() =>
            {
                Assert.That(linkedList.PosOfElement(_Person1), Is.EqualTo(0));
                Assert.That(linkedList.PosOfElement(_Person2), Is.EqualTo(1));
            });
        }
    }
}