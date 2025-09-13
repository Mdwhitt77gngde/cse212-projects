using System.Runtime.CompilerServices;

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
    // 1. Create an array called 'result' with length 'length'.
    // 2. For each index i from 0 to length-1:
    //      - compute multiple = number * (i + 1)
    //      - store multiple into result[i]
    // 3. Return result.
        // TODO Problem 1 Start
        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

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
    // 1. If data is null or empty, do nothing and return.
    // 2. Normalize amount: use amount = amount % data.Count so that amount == data.Count becomes 0.
    // 3. If normalized amount is 0, nothing to do (return).
    // 4. Take the last 'amount' elements as a temporary list (tail).
    //    - tail = data.GetRange(data.Count - amount, amount)
    // 5. Remove those last 'amount' items from data:
    //    - data.RemoveRange(data.Count - amount, amount)
    // 6. Insert the saved 'tail' at the front of data:
    //    - data.InsertRange(0, tail)
    // 7. The original list is modified in-place (no return value).
        // TODO Problem 2 Start
        if (data == null || data.Count == 0)
        {
            return;
        }

        int n = data.Count;

        amount = amount % n;

        if (amount == 0)
        {
            return;
        }

        List<int> tail = data.GetRange(n - amount, amount);

        data.RemoveRange(n - amount, amount);

        data.InsertRange(0, tail);

        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
    }
}
