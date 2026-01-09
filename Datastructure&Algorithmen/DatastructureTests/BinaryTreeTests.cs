using Common;
using Datastructure;

namespace DatastructureTests;

public class BinaryTreeTests
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
    public void Insert_MultipleObjects_Return()
    {
        BinaryTree<Person> binaryTree = new();
        binaryTree.Insert(_Person1);
        binaryTree.Insert(_Person2);
        binaryTree.Insert(_Person3);
        Assert.That(binaryTree.Traversal(), Is.EqualTo(new List<Person>() { _Person1, _Person2, _Person3 }));
    }
}
