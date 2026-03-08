using System;
using System.Collections.Generic;

public class Solution {
    public bool solution(string s) {
        var answer = true;
        if (s.StartsWith(")")) return false;

        var q = new Queue<char>();
        foreach (var t in s)
        {
            q.Enqueue(t);
        }

        var lCount = 0;
        var rCount = 0;
        while (q.Count > 0)
        {
            char ch = q.Dequeue();
            if (ch == '(') lCount++;
            else if (ch == ')') rCount++;
            if (lCount < rCount) return false;
        }
        if (lCount != rCount) return false;
        return answer;
    }
}