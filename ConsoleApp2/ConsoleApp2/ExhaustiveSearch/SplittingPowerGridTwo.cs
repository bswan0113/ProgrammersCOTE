// using System;
// using System.Collections.Generic;
// using System.Linq;
//
// public class Solution {
//     public int solution(int n, int[,] wires) {
//         int answer = Int32.MaxValue;
//         for (int i = 0; i < wires.GetLength(0); i++)
//         {
//             var leftResult = LinkedWireCount(wires[i, 0],i, new List<int>(), wires);
//             var rightResult = n - leftResult;
//             var gap = Math.Abs(leftResult - rightResult);
//             answer = Math.Min(answer, gap);
//
//         }
//         return answer;
//     }
//
//     public int LinkedWireCount(int startPoint, int cutPoint, List<int> visitedPoint, int[,] wires)
//     {
//         visitedPoint.Add(startPoint);
//
//         for (int i = 0; i < wires.GetLength(0); i++)
//         {
//             if (i == cutPoint) continue;
//
//             int lPoint = wires[i, 0];
//             int rPoint = wires[i, 1];
//
//             if (lPoint == startPoint || rPoint == startPoint)
//             {
//                 int nextPoint = (lPoint == startPoint) ? rPoint : lPoint;
//
//                 if (!visitedPoint.Contains(nextPoint))
//                 {
//                     LinkedWireCount(nextPoint, cutPoint, visitedPoint, wires);
//                 }
//             }
//         }
//
//         return visitedPoint.Count;
//     }
// }