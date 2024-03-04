using System.Text;

namespace AIContinuous.Collections;

public class TreeNode<T> : INode<T>
{
    public T                  Value    { get; set; }
    public TreeNode<T>?       Parent   { get; set; }
    public List<TreeNode<T>> Children { get; set; }

    public TreeNode(
        T value = default(T),
        TreeNode<T>? parent = null,
        List<TreeNode<T>> children = null!
    )
    {
        Value = value;
        Parent = parent;
        Children = children ?? new List<TreeNode<T>>();
        
        Parent?.AddChild(this);
        
        foreach (var child in Children.OfType<TreeNode<T>>())
            child.Parent = this;
    }

    public int GetHeight()
    {
        int height = 1;
        var current = this;

        while (current.Parent != null)
        {
            height++;
            current = current.Parent;
        }

        return height;
    }

    public TreeNode<T> AddChild(TreeNode<T> node)
    {
        node.Parent = this;
        Children.Add(node);

        return this;
    }

    public TreeNode<T> RemoveChild(TreeNode<T> node)
    {
        node.Parent = null;
        Children.Remove(node);
        
        return this;
    }

    public void ClearBranch()
    {
        foreach (var child in Children)
            child.Parent = null;
        
        Children.Clear();
    }
    
    public override string ToString()
    {
        return ToString("", true, true);
    }

    private string ToString(string indent, bool isLast, bool isRoot)
    {
        var result = new StringBuilder(indent);

        if (!isLast)
        {
            result.Append(Parent?.Children.LastOrDefault() == this
                              ? "\u2514\u2500\u2500\u2500"
                              : "\u251c\u2500\u2500\u2500");

            indent += "\u2502   ";
        }
        else if (!isRoot)
        {
            result.Append("\u2514\u2500\u2500\u2500");
            indent += "    ";
        }

        result.AppendLine(Value?.ToString());

        for (int i = 0; i < Children.Count; i++)
            result.Append(Children[i].ToString(indent, i == Children.Count - 1, false));

        return result.ToString();
    }
}