/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // Constructor initializes an empty nested list.
 *     public NestedInteger();
 *
 *     // Constructor initializes a single integer.
 *     public NestedInteger(int value);
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // Set this NestedInteger to hold a single integer.
 *     public void SetInteger(int value);
 *
 *     // Set this NestedInteger to hold a nested list and adds a nested integer to it.
 *     public void Add(NestedInteger ni);
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
public class Solution {
    private int sum = 0;
    
    public int DepthSum(IList<NestedInteger> nestedList) {
        foreach(var x in nestedList) {
            DFS(x, 1);
        }

        return sum;
    }
    
    private void DFS(NestedInteger node, int depth) {
        if(node.IsInteger()) {
            sum += depth * node.GetInteger();
            return;
        }
        
        foreach(var x in node.GetList()) {
            DFS(x, depth + 1);
        }
    }
}