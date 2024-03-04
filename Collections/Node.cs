namespace AIContinuous.Collections;

public class Node<T> : INode<T>
{
    public T Value { get; set; }
    public List<Node<T>> Neighbours { get; set; }
    public int Connections => Neighbours.Count;

    public Node
    (
        T value = default,
        List<Node<T>> neighbours = null!
    ) 
    {
        this.Value = value;
        this.Neighbours = neighbours ?? new List<Node<T>>();
    }

    public Node<T> AddNode(Node<T> node)
    {
        Neighbours.Add(node);
        node.Neighbours.Add(this);
        
        return this;
    }

    public Node<T> RemoveNode(Node<T> node)
    {
        Neighbours.Remove(node);
        node.Neighbours.Remove(this);

        return this;
    }
}
