// using System;
// using System.Linq;
//
// public class Solution {
//     public int[] solution(int[] array, int[,] commands) {
//         int[] answer = new int[commands.GetLength(0)];
//
//         for (int i = 0; i < commands.GetLength(0); i++)
//         {
//             var start = commands[i, 0] - 1;
//             var end = commands[i, 1] - 1;
//             var target = commands[i, 2] - 1;
//             var length = end - start + 1;
//             var newArr = array.Skip(start).Take(length).OrderBy(x => x).ToArray();
//             answer[i] = newArr[target];
//         }
//         return answer;
//     }
// }