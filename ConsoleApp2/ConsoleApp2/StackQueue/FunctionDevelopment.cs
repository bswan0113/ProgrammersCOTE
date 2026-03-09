// using System;
// using System.Collections.Generic;
// using System.Linq;
//
// public class Solution {
//     public int[] solution(int[] progresses, int[] speeds) {
//         List<int> result = new List<int>();
//         Queue<int> queue = new Queue<int>();
//
//         for (int i = 0; i < progresses.Length; i++) {
//             int days = (100 - progresses[i] + speeds[i] - 1) / speeds[i];
//             queue.Enqueue(days);
//         }
//
//         int deployDay = queue.Dequeue();
//         int count = 1;
//
//         while (queue.Count > 0) {
//             int nextDay = queue.Dequeue();
//
//             if (nextDay <= deployDay) {
//                 count++;
//             } else {
//                 result.Add(count);
//                 count = 1;
//                 deployDay = nextDay;
//             }
//         }
//         result.Add(count);
//
//         return result.ToArray();
//     }
// }