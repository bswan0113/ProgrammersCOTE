// using System;
//
// public class Solution {
//     public long solution(int n, int[] times) {
//         long answer = 0;
//         Array.Sort(times);
//         long min = 1;
//         long max = (long)times[times.Length - 1] * n;
//
//         while (min <= max)
//         {
//             long mid = (min + max) / 2;
//             long total = 0;
//
//             for (int i = 0; i < times.Length; i++) {
//                 total += mid / times[i];
//             }
//
//             if (total >= n)
//             {
//                 answer = mid;
//                 max = mid - 1;
//             }
//             else
//             {
//                 min = mid + 1;
//             }
//         }
//
//         return answer;
//     }
// }