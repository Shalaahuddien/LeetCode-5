public class Solution {
    public bool CanPartition(int[] nums) {
        var sum = nums.Sum();
        
        if(sum % 2 != 0) {
            return false;
        }
        
        var target = sum / 2;
        var dp = new bool[nums.Length][];
        dp[0] = new bool[target + 1];
        dp[0][0] = true;
        
        if(nums[0] <= target) {
            dp[0][nums[0]] = true;
        }
            
        for(int i = 1; i < dp.Length; i++) {
            dp[i] = new bool[target + 1];
            
            for(int j = 0; j <= target; j++) {
                var prev = dp[i - 1][j];
                
                if(prev) {
                    dp[i][j] = true;
                    
                    if(j + nums[i] <= target) {
                        dp[i][j + nums[i]] = true;
                    }
                    
                }
            }
        }
        
        return dp.Any(x => x[target]);
    }
}

public class SolutionTopDown {
    public bool CanPartition(int[] nums) {
        var sum = nums.Sum();
        
        if(sum % 2 != 0) {
            return false;
        }
        
        var dp = new bool?[nums.Length][];
    
        for(int i = 0; i < dp.Length; i++) {
            dp[i] = new bool?[sum / 2 + 1];
        }
        
        return DP(nums, 0, sum / 2, dp);
    }
    
    private bool DP(int[] nums, int pos, int target, bool?[][] dp) {
        if(target < 0) {
            return false;
        }
        
        if(target == 0) {
            return true;
        }
        
        if(pos == nums.Length) {
            return false;
        }
        
        if(dp[pos][target] is bool calculated) {
            return calculated;
        }
        
        var val = nums[pos];
        
        dp[pos][target] = DP(nums, pos + 1, target - val, dp) || DP(nums, pos + 1, target, dp);
        return (bool)dp[pos][target];
    }
}