using AIContinuous.Collections; 

namespace AIContinuous.Search;

public static partial class Search
{
    public static bool DFSearch<T>(TreeNode<T> node, T goal)
    {
        if (EqualityComparer<T>.Default.Equals(node.Value, goal))
            return true;
        
        foreach (var currNode in node.Children)
        {
            if(EqualityComparer<T>.Default.Equals(currNode.Value, goal))
                return true;
            
            DFSearch(currNode, goal);
        }

        return false;
    }
    
}
