namespace AIContinuous.Collections;

public class Tree<T>
{
    public TreeNode<T> Root     { get; set; }
    public List<TreeNode<T>> Branches => Root.Children;

    public Tree(TreeNode<T> root = null!)
    {
        Root = root;
    }

    public Tree<T> AddBranch(TreeNode<T> branch)
    {
        Root.AddChild(branch);
        branch.Parent = Root;

        return this;
    }

    public Tree<T> AddBranch(Tree<T> branch)
    {
        Root.AddChild(branch.Root);
        branch.Root.Parent = Root;

        return this;
    }

    public override string ToString()
    {
        return Root.ToString();
    }
}