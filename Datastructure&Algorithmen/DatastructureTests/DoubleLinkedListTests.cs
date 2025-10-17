using Common;
using Datastructure;

namespace DatastructureTests
{
    public class DoubleLinkedListTests
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
            _Person3 = new("Arnold");
            _PersonNull = null;
        }
        [Test]
        public void AddFirst_AddMultipleObjects_ObjectsInCorrectOrder()
        {
            DoubleLinkedList<Person> linkedList = new();
            linkedList.AddFirst(_Person1);
            linkedList.AddFirst(_Person2);
            linkedList.AddFirst(_Person3);
            Assert.Multiple(() =>
            {
                Assert.That(linkedList.GetAllNodesData(DoubleLinkedList<Person>.Direction.fromFirst),
                    Is.EqualTo(new List<Person> { _Person3, _Person2, _Person1 }));
                Assert.That(linkedList.GetAllNodesData(DoubleLinkedList<Person>.Direction.fromLast),
                    Is.EqualTo(new List<Person> { _Person1, _Person2, _Person3 }));
            });
        }
        [Test]
        public void AddFirt_AddNull_ObjectsInCorrectOrder()
        {
            DoubleLinkedList<Person> linkedList = new();
            linkedList.AddFirst(_Person1);
            linkedList.AddFirst(_PersonNull);
            Assert.Multiple(() =>
            {
                Assert.That(linkedList.GetAllNodesData(DoubleLinkedList<Person>.Direction.fromFirst),
                    Is.EqualTo(new List<Person?> { _PersonNull, _Person1 }));
                Assert.That(linkedList.GetAllNodesData(DoubleLinkedList<Person>.Direction.fromLast),
                    Is.EqualTo(new List<Person?> { _Person1, _PersonNull }));
            });
        }
        [Test]
        public void AddLast_AddMultipleObjects_ObjectsInCorrectOrder()
        {
            DoubleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            linkedList.AddLast(_Person2);
            linkedList.AddLast(_Person3);
            Assert.Multiple(() =>
            {
                Assert.That(linkedList.GetAllNodesData(DoubleLinkedList<Person>.Direction.fromFirst),
                    Is.EqualTo(new List<Person?> { _Person1, _Person2, _Person3 }));
                Assert.That(linkedList.GetAllNodesData(DoubleLinkedList<Person>.Direction.fromLast),
                    Is.EqualTo(new List<Person?> { _Person3, _Person2, _Person1 }));
            });
        }
        [Test]
        public void AddLast_AddNull_ObjectsInCorrectOrder()
        {
            DoubleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            linkedList.AddLast(_PersonNull);
            Assert.Multiple(() =>
            {
                Assert.That(linkedList.GetAllNodesData(DoubleLinkedList<Person>.Direction.fromFirst),
                    Is.EqualTo(new List<Person?> { _Person1, _PersonNull }));
                Assert.That(linkedList.GetAllNodesData((DoubleLinkedList<Person>.Direction)1),
                    Is.EqualTo(new List<Person?> { _PersonNull, _Person1 }));
            });
        }
        [Test]
        public void AddLast_ListEmptyAddFirst_LastCorrectlyInitialized()
        {
            DoubleLinkedList<Person> linkedList = new();
            linkedList.AddFirst(_Person1);
            linkedList.AddLast(_Person2);
            linkedList.AddFirst(_Person3);
            Assert.Multiple(() =>
            {
                Assert.That(linkedList.GetAllNodesData(DoubleLinkedList<Person>.Direction.fromFirst),
                    Is.EqualTo(new List<Person?> { _Person3, _Person1, _Person2 }));
                Assert.That(linkedList.GetAllNodesData(DoubleLinkedList<Person>.Direction.fromLast),
                    Is.EqualTo(new List<Person?> { _Person2, _Person1, _Person3 }));
            });
        }
        [Test]
        public void InsertAfter_InsertBetween_ObjectsInCorrectOrder()
        {
            DoubleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            linkedList.AddLast(_Person2);
            linkedList.InsertAfter(_Person1, _Person3);
            Assert.Multiple(() =>
            {
                Assert.That(linkedList.GetAllNodesData(DoubleLinkedList<Person>.Direction.fromFirst),
                    Is.EqualTo(new List<Person?> { _Person1, _Person3, _Person2 }));
                Assert.That(linkedList.GetAllNodesData(DoubleLinkedList<Person>.Direction.fromLast),
                    Is.EqualTo(new List<Person?> { _Person2, _Person3, _Person1 }));
            });
        }
        [Test]
        public void InsertAfter_ObjectBeforeDoesNotExist_ObjectsInCorrectOrder()
        {
            DoubleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person2);
            linkedList.InsertAfter(_Person1, _Person3);
            Assert.Multiple(() =>
            {
                Assert.That(linkedList.GetAllNodesData(DoubleLinkedList<Person>.Direction.fromFirst),
                    Is.EqualTo(new List<Person?> { _Person2, _Person3 }));
                Assert.That(linkedList.GetAllNodesData(DoubleLinkedList<Person>.Direction.fromLast),
                    Is.EqualTo(new List<Person?> { _Person3, _Person2 }));
            });
        }
        [Test]
        public void InsertAfter_InsertNull_ObjectsInCorrectOrder()
        {
            DoubleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            linkedList.AddLast(_Person2);
            linkedList.InsertAfter(_Person1, _PersonNull);
            Assert.Multiple(() =>
            {
                Assert.That(linkedList.GetAllNodesData(DoubleLinkedList<Person>.Direction.fromFirst),
                    Is.EqualTo(new List<Person?> { _Person1, _PersonNull, _Person2 }));
                Assert.That(linkedList.GetAllNodesData(DoubleLinkedList<Person>.Direction.fromLast),
                    Is.EqualTo(new List<Person?> { _Person2, _PersonNull, _Person1 }));
            });
        }
        [Test]
        public void InsertBefore_InsertBetween_ObjectsInCorrectOrder()
        {
            DoubleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            linkedList.AddLast(_Person2);
            linkedList.InsertBefore(_Person2, _Person3);
            Assert.Multiple(() =>
            {
                Assert.That(linkedList.GetAllNodesData(DoubleLinkedList<Person>.Direction.fromFirst),
                    Is.EqualTo(new List<Person?> { _Person1, _Person3, _Person2 }));
                Assert.That(linkedList.GetAllNodesData(DoubleLinkedList<Person>.Direction.fromLast),
                    Is.EqualTo(new List<Person?> { _Person2, _Person3, _Person1 }));
            });
        }
        [Test]
        public void InserBefore_BeforeHead_ObjectsInCorrectOrder()
        {
            DoubleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            linkedList.InsertBefore(_Person1, _Person2);
            Assert.Multiple(() =>
            {
                Assert.That(linkedList.GetAllNodesData(DoubleLinkedList<Person>.Direction.fromFirst),
                    Is.EqualTo(new List<Person?> { _Person2, _Person1 }));
                Assert.That(linkedList.GetAllNodesData(DoubleLinkedList<Person>.Direction.fromLast),
                    Is.EqualTo(new List<Person?> { _Person1, _Person2 }));
            });
        }
        [Test]
        public void InsertBefore_ObjectAfterDoesNotExist_ObjectsInCorrectOrder()
        {
            DoubleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person2);
            linkedList.InsertBefore(_Person1, _Person3);
            Assert.Multiple(() =>
            {
                Assert.That(linkedList.GetAllNodesData(DoubleLinkedList<Person>.Direction.fromFirst),
                    Is.EqualTo(new List<Person?> { _Person3, _Person2 }));
                Assert.That(linkedList.GetAllNodesData(DoubleLinkedList<Person>.Direction.fromLast),
                    Is.EqualTo(new List<Person?> { _Person2, _Person3 }));
            });
        }
        [Test]
        public void InsertBefore_InsertNull_ObjectsInCorrectOrder()
        {
            DoubleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            linkedList.AddLast(_Person2);
            linkedList.InsertBefore(_Person2, _PersonNull);
            Assert.Multiple(() =>
            {
                Assert.That(linkedList.GetAllNodesData(DoubleLinkedList<Person>.Direction.fromFirst),
                    Is.EqualTo(new List<Person?> { _Person1, _PersonNull, _Person2 }));
                Assert.That(linkedList.GetAllNodesData(DoubleLinkedList<Person>.Direction.fromLast),
                    Is.EqualTo(new List<Person?> { _Person2, _PersonNull, _Person1 }));
            });
        }
        [Test]
        public void PosOfElement_AddingMultipleObjects_ObjectsWithCorrectIndex()
        {
            DoubleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            linkedList.AddLast(_Person2);
            linkedList.AddLast(_Person3);
            Assert.Multiple(() =>
            {
                Assert.That(linkedList.PosOfElement(_Person1, DoubleLinkedList<Person>.Direction.fromFirst),
                    Is.EqualTo(0));
                Assert.That(linkedList.PosOfElement(_Person2, DoubleLinkedList<Person>.Direction.fromFirst),
                    Is.EqualTo(1));
                Assert.That(linkedList.PosOfElement(_Person3, DoubleLinkedList<Person>.Direction.fromFirst),
                    Is.EqualTo(2));
                Assert.That(linkedList.PosOfElement(_Person1, DoubleLinkedList<Person>.Direction.fromLast),
                    Is.EqualTo(-3));
                Assert.That(linkedList.PosOfElement(_Person2, DoubleLinkedList<Person>.Direction.fromLast),
                    Is.EqualTo(-2));
                Assert.That(linkedList.PosOfElement(_Person3, DoubleLinkedList<Person>.Direction.fromLast),
                    Is.EqualTo(-1));
            });
        }
        [Test]
        public void BubbleSort_AddingMultipleObjects_ObjectsSorted()
        {
            DoubleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            linkedList.AddLast(_Person2);
            linkedList.AddLast(_Person3);
            linkedList.AddLast(_PersonNull);
            linkedList.BubbleSort();
            Assert.That(linkedList.GetAllNodesData(0), Is.EqualTo(new List<Person> { _PersonNull, _Person3, _Person2, _Person1 }));
        }
    }
}