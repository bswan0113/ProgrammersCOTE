// using System;
// using System.Collections.Generic;
// using System.Linq;
//
// public class Solution {
//     public int solution(int[] priorities, int location) {
//         int answer = 0;
//         Queue<(int index, int priority)> processQueue = new Queue<(int, int)>();
//         Dictionary<int, int> priorityDict = new Dictionary<int, int>();
//         for (int i = 0; i < priorities.Length; i++)
//         {
//             processQueue.Enqueue((i, priorities[i]));
//             if (priorityDict.ContainsKey(priorities[i]))
//             {
//                 priorityDict[priorities[i]]++;
//             }
//             else
//             {
//                 priorityDict.Add(priorities[i], 1);
//             }
//         }
//
//         while (processQueue.Count > 0)
//         {
//             var queue = processQueue.Dequeue();
//             var index = queue.index;
//             int priority = queue.priority;
//             if (priorityDict.Any(x => x.Key > priority))
//             {
//                 processQueue.Enqueue((index, priority));
//             }
//             else
//             {
//                 answer++;
//                 priorityDict[priority]--;
//                 if (priorityDict[priority] == 0)
//                 {
//                     priorityDict.Remove(priority);
//                 }
//                 if (location == index) break;
//             }
//         }
//         return answer;
//     }
// }