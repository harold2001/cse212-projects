public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start

        // PLAN:
        // 1. Allocate a double[] of size 'length'.
        var result = new double[length];

        // 2. For each index i from 0 to length-1:
        //      a. Compute the (i+1)-th multiple: number * (i+1).
        //      b. Store it at result[i].
        for (int i = 0; i < length; i++)
        {
            // (i + 1) because the first multiple is number*1, then number*2, …
            result[i] = number * (i + 1);
        }

        // 3. Return the filled array.
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start

        // PLAN:
        // 1. Let n = data.Count.
        int n = data.Count;

        // 2. Compute k = amount % n (though here amount ≤ n, so k == amount).
        int k = amount % n;

        // 3. Slice off the last k elements into a new list 'tail':
        var tail = data.GetRange(n - k, k);

        // 4. Remove those k elements from the end of 'data':
        data.RemoveRange(n - k, k);

        // 5. Insert 'tail' back at the front of 'data':
        data.InsertRange(0, tail);
    }
}
