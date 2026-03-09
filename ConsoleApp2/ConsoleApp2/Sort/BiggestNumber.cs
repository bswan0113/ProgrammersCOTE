using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

public class Solution {
    public string solution(int[] numbers) {
        StringBuilder answer = new StringBuilder();
        Dictionary<int, List<int>> numberDict = new Dictionary<int, List<int>>(9);

        foreach (var num in numbers)
        {
            int firstDigit = num.ToString()[0] - '0';
            if (!numberDict.ContainsKey(firstDigit))
            {
                numberDict.Add(firstDigit, new List<int>());
            }
            numberDict[firstDigit].Add(num);
        }

        foreach (var kvp in numberDict)
        {
            kvp.Value.Sort((x, y) =>
            {
                string sx = x.ToString();
                string sy = y.ToString();
                return String.Compare((sy + sx), sx + sy, StringComparison.Ordinal);
            });
        }

        for (int i = 9; i >= 0; i--)
        {
            numberDict.TryGetValue(i, out var queue);
            if(queue == null) continue;
            foreach (var num in queue)
            {
                answer.Append(num);
            }
        }

        if (answer.Length > 0 && answer[0] == '0')
        {
            return "0";
        }

        return answer.ToString();
    }
}