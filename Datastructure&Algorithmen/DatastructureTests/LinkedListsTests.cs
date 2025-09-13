using Datastructure;

namespace DatastructureTests
{
    public class SimpleLinkedListUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddObject_ReturnsObject()
        {
            Person person = new Person();
            SimpleLinkedList linkedList = new SimpleLinkedList();
            linkedList.AddLast(person);
            Assert.That(linkedList.head.next.data, Is.EqualTo(person));
        }
        [Test]
        public void GetAllNodes_AddObjects_ReturnsListNodes()
        {
            Person person = new Person();
            SimpleLinkedList linkedList = new SimpleLinkedList();
            linkedList.AddLast(person);
            linkedList.AddLast(person);
            Assert.That(linkedList.getAllNodes(), Is.EqualTo(new List<object> { person, person }));
        }
        [Test]
        public void CheckForObject_ReturnsBool()
        {
            Person person1 = new Person();
            Person person2 = new Person("first", "last");
            SimpleLinkedList linkedList = new SimpleLinkedList();
            linkedList.AddLast(person1);
            linkedList.AddLast(person2);
            Assert.That(linkedList.checkForObject(person2), Is.True);
        }
    }
}