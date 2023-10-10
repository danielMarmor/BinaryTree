// See https://aka.ms/new-console-template for more information
using BinaryTree;
using InnerRectangles;

Console.WriteLine("Hello, World!");

var rect = new Rectangle(14, 35);

var innerRects = rect.GetInnerRetangles();

foreach(var inner in innerRects)
{
    Console.WriteLine(inner);
}

var binaryTree = new BinaryTreeNodes();

binaryTree.InsertNode("A");
binaryTree.InsertNode("D");
binaryTree.InsertNode("H");
binaryTree.InsertNode("E");
binaryTree.InsertNode("G");
binaryTree.InsertNode("Y");
binaryTree.InsertNode("T");
binaryTree.InsertNode("Z");
binaryTree.InsertNode("B");

var levelNodes =  binaryTree.GetLevelTreeItems();
foreach(var node in levelNodes)
{
    Console.WriteLine(node.Data);
}


