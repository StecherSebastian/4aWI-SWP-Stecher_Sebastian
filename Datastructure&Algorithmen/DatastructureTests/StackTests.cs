using Common;

namespace DatastructureTests
{
    public class StackTests
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
        public void Push_AddSeveralObject_ObjectsInStack()
        {
            Datastructure.Stack<Person> stack = new();
            stack.Push(_Person1);
            stack.Push(_Person2);
            stack.Push(_Person3);
            stack.Push(_PersonNull);
            Assert.Multiple(() =>
            {
                Assert.That(stack.Pop(), Is.EqualTo(_PersonNull));
                Assert.That(stack.Pop(), Is.EqualTo(_Person3));
                Assert.That(stack.Pop(), Is.EqualTo(_Person2));
                Assert.That(stack.Pop(), Is.EqualTo(_Person1));
                Assert.That(stack.IsEmpty(), Is.True);
            });
        }
        [Test]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            Datastructure.Stack<Person> stack = new();
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }
        [Test]
        public void Size_PushAndPopObjects_ReturnCorrectSize()
        {
            Datastructure.Stack<Person> stack = new();
            stack.Push(_Person1);
            stack.Push(_Person2);
            stack.Pop();
            Assert.That(stack.Size(), Is.EqualTo(1));
        }
        [Test]
        public void IsEmpty_EmptyStack_ReturnsTrue()
        {
            Datastructure.Stack<Person> stack = new();
            Assert.That(stack.IsEmpty(), Is.True);
        }
        [Test]
        public void IsEmpty_NotEmptyStack_ReturnsFalse()
        {
            Datastructure.Stack<Person> stack = new();
            stack.Push(_Person1);
            Assert.That(stack.IsEmpty(), Is.False);
        }
        [Test]
        public void Top_PushAndPopObjects_ReturnCorrectTop()
        {
            Datastructure.Stack<Person> stack = new();
            stack.Push(_Person1);
            stack.Push(_Person2);
            stack.Pop();
            Assert.That(stack.Top(), Is.EqualTo(_Person1));
        }
        [Test]
        public void Top_EmptyStack_ThrowInvalidOperationException()
        {
            Datastructure.Stack<Person> stack = new();
            Assert.Throws<InvalidOperationException>(() => stack.Top());
        }
    }
}
