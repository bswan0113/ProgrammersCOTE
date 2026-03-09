// using System;
//
// public class Solution {
//     public int solution(int[,] sizes) {
//         int answer = 0;
//         int maxW = 0;
//         int maxH = 0;
//
//         for (int i = 0; i < sizes.GetLength(0); i++)
//         {
//             var wGreaterThanH = sizes[i, 0] > sizes[i, 1];
//             var targetW = wGreaterThanH ? sizes[i, 0] : sizes[i, 1];
//             var targetH = wGreaterThanH ? sizes[i, 1] : sizes[i, 0];
//             maxW = Math.Max(maxW, targetW);
//             maxH = Math.Max(maxH, targetH);
//         }
//
//
//         return maxW * maxH;
//     }
// }