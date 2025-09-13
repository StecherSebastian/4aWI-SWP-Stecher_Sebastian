namespace Datastructure
{
    public class SimpleLinkedList
    {
        public Node head = null!;
        public void AddLast(object data)
        {
            if (head == null)
            {
                head = new Node();
                Node toAdd = new Node();
                toAdd.data = data;
                head.next = toAdd;
            }
            else
            {
                Node toAdd = new Node();
                toAdd.data = data;
                Node? current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = toAdd;
            }
        }
        public List<object> getAllNodes()
        {
            List<object> result = new List<object>();
            Node? current = head;
            while (current.next != null)
            {
                current = current.next;
                result.Add(current.data);
            }
            return result;
        }
        public bool checkForObject(object objectToFind)
        {
            Node? current = head;
            while (current != null)
            {
                if (current.data == objectToFind)
                    return true;
                else
                    current = current.next;
            }
            return false;
        }
    }
}