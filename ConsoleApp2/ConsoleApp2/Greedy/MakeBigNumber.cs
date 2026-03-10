// using System;
// using System.Collections.Generic;
// using System.Linq;
//
// public class Solution {
//     public string solution(string number, int k) {
//         Stack<char> stack = new Stack<char>();
//
//         for (int i = 0; i < number.Length; i++)
//         {
//             char currentNum = number[i];
//             while (k > 0 && stack.Count > 0 && stack.Peek() < currentNum)
//             {
//                 stack.Pop();
//                 k--;
//             }
//             stack.Push(currentNum);
//         }
//
//         string answer = string.Concat(stack.Reverse());
//
//         if (k > 0)
//         {
//             answer = answer.Substring(0, answer.Length - k);
//         }
//
//         return answer;
//     }
// }