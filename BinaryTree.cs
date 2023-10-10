namespace BinaryTree
{
    public class Node
    {
        public string Data { get; set; }
        public Node? Right { get; set; }
        public Node? Left { get; set; }
        public Node(string data)
        {
            Data = data;

            Right = null;
            Left = null;
        }
    }
    public class BinaryTreeNodes
    {
        Node? Root { get; set; }

        public void InsertNode(string value)
        {
            if (Root == null)
            {
                Root = new Node(value);
                return;   
            }
            var node = Root;
            while (true)
            {
                if (node == null)
                {
                    node = new Node(value);
                    return;
                }

                //VALUE IS BIGGER ===> TO LEFT
                if (node.Data.CompareTo(value) == -1)
                {
                    node = node.Left;
                }
                //VALUE IS SMALER ===> TO LEFT
                else
                {
                    node = node.Right;
                }
            }
        }

        public IEnumerable<Node> GetLevelTreeItems()
        {
            Queue<Node> items = new Queue<Node>();

            items.Enqueue(Root!);

            while (items.Count > 0)
            {
                Node node = items.Dequeue();

                yield return node;

                if (node.Left != null)
                {
                    items.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    items.Enqueue(node.Right);
                }
            }
        }

    }
}
