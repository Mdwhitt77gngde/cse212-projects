using System.Collections;
using System.Collections.Generic;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  If n <= 0, return 0. A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Insert permutations of length 'size' from a list of 'letters' into results.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // If we've built a permutation of required length, add it.
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // For each available letter, choose it and recurse with the remaining letters.
        for (int i = 0; i < letters.Length; i++)
        {
            char c = letters[i];
            string remaining = letters.Substring(0, i) + letters.Substring(i + 1);
            PermutationsChoose(results, remaining, size, word + c);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count ways to climb using steps of 1,2,3 with memoization (remember dictionary).
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        if (remember == null)
            remember = new Dictionary<int, decimal>();

        if (remember.ContainsKey(s))
            return remember[s];

        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Expand wildcard '*' into all binary strings and add to results.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int idx = pattern.IndexOf('*');
        if (idx < 0)
        {
            // No wildcard left — add the concrete binary string.
            results.Add(pattern);
            return;
        }

        // Replace first '*' with '0' and '1' and recurse.
        string with0 = pattern.Substring(0, idx) + "0" + pattern.Substring(idx + 1);
        string with1 = pattern.Substring(0, idx) + "1" + pattern.Substring(idx + 1);
        WildcardBinary(with0, results);
        WildcardBinary(with1, results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// Use recursion to insert all paths that start at (0,0) and end at the 'end' square into results.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();

        // If this move isn't valid, stop exploring this path.
        if (!maze.IsValidMove(currPath, x, y))
            return;

        // Add current position to path
        currPath.Add((x, y));

        // If this is the end, record the path (AsString extension) and then backtrack.
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            // backtrack
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Explore neighbors: right, left, down, up
        SolveMaze(results, maze, x + 1, y, currPath);
        SolveMaze(results, maze, x - 1, y, currPath);
        SolveMaze(results, maze, x, y + 1, currPath);
        SolveMaze(results, maze, x, y - 1, currPath);

        // Backtrack: remove current position before returning
        currPath.RemoveAt(currPath.Count - 1);
    }
}
