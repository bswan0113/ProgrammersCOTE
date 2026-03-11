// using System;
//
// public class Solution {
//     public int solution(int distance, int[] rocks, int n) {
//         int answer = 0;
//         int min = 1;
//         int max = distance;
//         Array.Sort(rocks);
//
//         while (min <= max)
//         {
//             int mid = (max + min) / 2;
//             int crashCount = 0;
//             int currentPos = 0;
//             for (int i = 0; i < rocks.Length; i++)
//             {
//                 var jumpDistance = rocks[i] - currentPos;
//                 if (jumpDistance < mid)
//                 {
//                     crashCount++;
//                 }
//                 else
//                 {
//                     currentPos = rocks[i];
//                 }
//             }
//
//             if (distance - currentPos < mid)
//             {
//                 crashCount++;
//             }
//             if (crashCount > n)
//             {
//                 max = mid - 1;
//
//             }
//             else
//             {
//                 answer = mid;
//                 min = mid + 1;
//             }
//         }
//
//
//         return answer;
//     }
// }