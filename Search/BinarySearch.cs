namespace AIContinuous.Search;

public static partial class Search
{
    public static int BinarySearch<T>(List<T> collection, T value, int begin = 0, int end = -1)
    {
        end = end == -1 ? collection.Count - 1 : end;
        int mid;

        var comparer = Comparer<T>.Default;

        do
        {
            mid = (begin + end) / 2;
            var midValue = collection[mid];

            if (comparer.Compare(midValue, value) == 0)
                return mid;

            if (comparer.Compare(midValue, value) < 0)
                begin = mid + 1;
            else    
                end = mid - 1;
                
        } while (begin > end);

        return -1;
    }
}