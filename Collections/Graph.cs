namespace AIContinuous.Collections;

public class Graph<T> : Node<T>
{
    public Graph(T value = default, List<Node<T>> neighbours = null!) : base(value, neighbours) { }
}
