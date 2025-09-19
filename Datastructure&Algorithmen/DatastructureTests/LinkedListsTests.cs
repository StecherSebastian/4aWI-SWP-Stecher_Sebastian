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
        public void AddLast_AddObject_ReturnsObject()
        {
            Person person = new Person();
            SimpleLinkedList<Person> linkedList = new SimpleLinkedList<Person>();
            linkedList.AddLast(person);
            Assert.That(linkedList.Head.Data, Is.EqualTo(person));
        }
        [Test]
        public void GetAllNodes_AddObjects_ReturnsListNodes()
        {
            Person person = new Person();
            SimpleLinkedList<Person> linkedList = new SimpleLinkedList<Person>();
            linkedList.AddLast(person);
            linkedList.AddLast(person);
            Assert.That(linkedList.GetAllNodes(), Is.EqualTo(new List<Person> { person, person }));
        }
        [Test]
        public void Contains_ReturnsBool()
        {
            Person person1 = new Person();
            Person person2 = new Person("first", "last");
            SimpleLinkedList<Person> linkedList = new SimpleLinkedList<Person>();
            linkedList.AddLast(person1);
            linkedList.AddLast(person2);
            Assert.That(linkedList.Contains(person2), Is.True);
        }
    }
}