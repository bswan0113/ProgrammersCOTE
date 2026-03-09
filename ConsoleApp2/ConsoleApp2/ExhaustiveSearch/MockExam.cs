using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(int[] answers) {
        var firstLoser = new int[] {1,2,3,4,5};
        var secondLoser = new int[] {2,1,2,3,2,4,2,5};
        var thirdLoser = new int [] {3,3,1,1,2,2,4,4,5,5};
        int firstResult = 0;
        int secondResult = 0;
        int thirdResult = 0;

        for (int i = 0; i < answers.Length; i++)
        {
            var questionAnswer = answers[i];
            if (questionAnswer == GetResult(firstLoser, i)) firstResult++;
            if (questionAnswer == GetResult(secondLoser, i)) secondResult++;
            if (questionAnswer == GetResult(thirdLoser, i)) thirdResult++;
        }

        int maxScore = Math.Max(firstResult, Math.Max(secondResult, thirdResult));
        List<int> resultList = new List<int>();
        if (firstResult == maxScore) resultList.Add(1);
        if (secondResult == maxScore) resultList.Add(2);
        if (thirdResult == maxScore) resultList.Add(3);

        return resultList.ToArray();
    }

    private int GetResult(int[] arr, int index)
    {
        return arr[index % arr.Length];
    }
}