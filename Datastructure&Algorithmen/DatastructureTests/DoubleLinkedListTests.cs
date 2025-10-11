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
            _Person3 = new("Stephan");
            _PersonNull = null;
        }
        [Test]
        public void AddFirst_AddMultipleObjects_ObjectsInCorrectOrder()
        {
            DoubleLinkedList<Person> linkedList = new();
            linkedList.AddFirst(_Person1);
            linkedList.AddFirst(_Person2);
            linkedList.AddFirst(_Person3);
            Assert.That(linkedList.GetAllNodesData(), Is.EqualTo(new List<Person> { _Person3, _Person2, _Person1 }));
        }
        [Test]
        public void AddFirt_AddNull_ObjectsInCorrectOrder()
        {
            DoubleLinkedList<Person> linkedList = new();
            linkedList.AddFirst(_Person1);
            linkedList.AddFirst(_PersonNull);
            Assert.That(linkedList.GetAllNodesData(), Is.EqualTo(new List<Person?> { _PersonNull, _Person1 }));
        }
        [Test]
        public void AddLast_AddMultipleObjects_ObjectsInCorrectOrder()
        {
            DoubleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            linkedList.AddLast(_Person2);
            linkedList.AddLast(_Person3);
            Assert.That(linkedList.GetAllNodesData(), Is.EqualTo(new List<Person> { _Person1, _Person2, _Person3 }));
        }
        [Test]
        public void AddLast_AddNull_ObjectsInCorrectOrder()
        {
            DoubleLinkedList<Person> linkedList = new();
            linkedList.AddLast(_Person1);
            linkedList.AddLast(_PersonNull);
            Assert.That(linkedList.GetAllNodesData(), Is.EqualTo(new List<Person?> { _Person1, _PersonNull }));
        }
        [Test]
        public void AddLast_ListEmptyAddFirst_LastCorrectlyInitialized()
        {
            DoubleLinkedList<Person> linkedList = new();
            linkedList.AddFirst(_Person1);
            linkedList.AddLast(_Person2);
            linkedList.AddFirst(_Person3);
            Assert.That(linkedList.GetAllNodesData(), Is.EqualTo(new List<Person> { _Person3, _Person1, _Person2}));
        }
    }
}