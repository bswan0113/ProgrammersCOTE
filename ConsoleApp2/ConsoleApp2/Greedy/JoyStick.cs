using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(string name) {
        int answer = 0;
        answer += GetWMove(name);
        for (int i = 0; i < name.Length; i++)
        {
            var target = name[i];
            answer += GetHMove(target);
        }

        return answer;
    }

    int GetHMove(char target)
    {
        int up = target - 'A';
        int down = 'Z' - target + 1;
        int minMove = Math.Min(up, down);
        return minMove;
    }

    int GetWMove(string name)
    {
        int n = name.Length;
        int minMove = n - 1;
        for (int i = 0; i < n; i++)
        {
            int next = i + 1;
            while (next < n && name[next] == 'A')
            {
                next++;
            }
            int move = i + i + (n - next);
            minMove = Math.Min(minMove, move);
            int moveBack = (n - next) * 2 + i;
            minMove = Math.Min(minMove, moveBack);
        }
        return minMove;
    }
}