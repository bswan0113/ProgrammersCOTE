using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int N, int number) {
        int answer = 1;
        if (N == number)
        {
            return answer;
        }
        HashSet<int>[] dp = new HashSet<int>[9];

        for (int i = 1; i <= 8; i++) {
            dp[i] = new HashSet<int>();
        }
        dp[1].Add(N);
        for (int i = 2; i < 9; i++)
        {
            var Ncontinues ="";
            for (int k = 1; k <= i; k++)
            {
                Ncontinues+=N.ToString();
            }
            dp[i].Add(Int32.Parse(Ncontinues));
            for (int j = 1; j < i; j++)
            {
                foreach (int a in dp[j])
                {
                    foreach (int b in dp[i - j])
                    {
                        dp[i].Add(a + b);
                        dp[i].Add(a - b);
                        dp[i].Add(a * b);
                        if (b != 0)
                        {
                            dp[i].Add(a / b);
                        }
                    }
                }
            }

            foreach (int result in dp[i])
            {
                if (result == number)
                {
                    return i;
                }
            }
        }
        return -1;
    }
}