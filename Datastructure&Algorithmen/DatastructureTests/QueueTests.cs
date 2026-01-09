using Common;
using Datastructure;

namespace DatastructureTests;
public class QueueTests
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
    public void Enqueue_AddMultipleObjects_ObjectsInQueue()
    {
        Datastructure.Queue<Person> queue = new();
        queue.Enqueue(_Person1);
        queue.Enqueue(_Person2);
        queue.Enqueue(_Person3);
        queue.Enqueue(_PersonNull);
        Assert.Multiple(() =>
        {
            Assert.That(queue.Dequeue(), Is.EqualTo(_Person1));
            Assert.That(queue.Dequeue(), Is.EqualTo(_Person2));
            Assert.That(queue.Dequeue(), Is.EqualTo(_Person3));
            Assert.That(queue.Dequeue(), Is.EqualTo(_PersonNull));
            Assert.That(queue.IsEmpty(), Is.True);
        });
    }
    [Test]
    public void Dequeue_EmptyQueue_ThrowsInvalidOperationException()
    {
        Datastructure.Queue<Person> queue = new();
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());  
    }
    [Test]
    public void Peek_PushAndPopObjects_ReturnCorrectObject()
    {
        Datastructure.Queue<Person> queue = new();
        queue.Enqueue(_Person1);
        queue.Enqueue(_Person2);
        queue.Dequeue();
        Assert.That(queue.Peek(), Is.EqualTo(_Person2));
    }
    [Test]
    public void Peek_EmptyQueue_ThrowsInvalidOperationException()
    {
        Datastructure.Queue<Person> queue = new();
        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }
    [Test]
    public void Size_PushAndPopObjects_ReturnCorrectSize()
    {
        Datastructure.Queue<Person> queue = new();
        queue.Enqueue(_Person1);
        queue.Enqueue(_Person2);
        queue.Dequeue();
        Assert.That(queue.Size(), Is.EqualTo(1));
    }
    [Test]
    public void IsEmpty_EmptyQueue_ReturnsTrue()
    {
        Datastructure.Queue<Person> queue = new();
        Assert.That(queue.IsEmpty(), Is.True);
    }
    [Test]
    public void IsEmpty_NotEmptyQueue_ReturnsFalse()
    {
        Datastructure.Queue<Person> queue = new();
        queue.Enqueue(_Person1);
        Assert.That(queue.IsEmpty(), Is.False);
    }
}
