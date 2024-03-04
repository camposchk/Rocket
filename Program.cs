using AIContinuous.Collections;
using AIContinuous.Search;

var tree = BuildTree();
Console.WriteLine(tree);

var found = Search.BFSearch(tree.Root, 99);
Console.WriteLine($"Goal found: {found}");

return;

Tree<int> BuildTree()
{
    // Tree 1 (root: 50)
    var node = new TreeNode<int>(6);
    node = new TreeNode<int>(21, children: new List<TreeNode<int>> { node });
    var node2 = new TreeNode<int>(45);
    node = new TreeNode<int>(12, children: new List<TreeNode<int>> { node, node2 });
    node = new TreeNode<int>(50, children: new List<TreeNode<int>> { node });

    var tree1 = new Tree<int>(node);

    // Tree 2 (root: 1)
    var root = new TreeNode<int>(1)
               .AddChild(new TreeNode<int>(70))
               .AddChild(new TreeNode<int>(61));

    var tree2 = new Tree<int>(root);

    // Tree 3 (root: 30)
    root = new TreeNode<int>(30)
           .AddChild(new TreeNode<int>(96))
           .AddChild(new TreeNode<int>(9));

    var tree3 = new Tree<int>(root);

    // Tree4 (root: 150)
    root = new TreeNode<int>(150)
           .AddChild(tree3.Root)
           .AddChild(new TreeNode<int>(5))
           .AddChild(new TreeNode<int>(11));

    var tree4 = new Tree<int>(root);

    // Tree 5 (root: 100)
    root = new TreeNode<int>(100)
           .AddChild(tree1.Root)
           .AddChild(tree2.Root)
           .AddChild(tree4.Root);

    var tree5 = new Tree<int>(root);

    return tree5;
}

