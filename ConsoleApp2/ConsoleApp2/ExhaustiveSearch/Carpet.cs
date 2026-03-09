// using System;
// using System.Collections.Generic;
// using System.Linq;
//
// public class Solution {
//     public int[] solution(int brown, int yellow)
//     {
//         int[] answer = new int[2];
//         HashSet<(int w ,int h)> numberSet = new HashSet<(int, int)>();
//         for (int i = 1; i <= Math.Sqrt(yellow); i++)
//         {
//             if (yellow % i == 0)
//             {
//                 numberSet.Add((i, yellow / i));
//             }
//         }
//         for (int i = 0; i < numberSet.Count; i++)
//         {
//             var number = numberSet.ElementAt(i);
//             var result = (number.w + number.h + 2) * 2;
//             if (result == brown)
//             {
//                 answer[0] = number.w > number.h ? number.w + 2: number.h + 2;
//                 answer[1] = number.w > number.h ? number.h + 2: number.w + 2;
//             }
//         }
//         return answer;
//     }
//
// }