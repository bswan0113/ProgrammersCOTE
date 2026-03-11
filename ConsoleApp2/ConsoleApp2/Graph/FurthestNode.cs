// using System;
// using System.Collections.Generic;
// using System.Linq;
//
// public class Solution {
//     public int solution(int n, int[,] edge) {
//         int answer = 0;
//         List<int>[] graph = new List<int>[n + 1];
//         for (int i = 1; i <= n; i++) graph[i] = new List<int>();
//
//         for (int i = 0; i < edge.GetLength(0); i++) {
//             int u = edge[i, 0];
//             int v = edge[i, 1];
//             graph[u].Add(v);
//             graph[v].Add(u);
//         }
//         int[] distances = new int[n + 1];
//         for (int i = 0; i <= n; i++)
//         {
//             distances[i] = -1;
//         }
//         Queue<int> queue = new Queue<int>();
//         distances[1] = 0;
//         queue.Enqueue(1);
//         while (queue.Count > 0) {
//             int current = queue.Dequeue();
//
//             foreach (int next in graph[current]) {
//                 if (distances[next] == -1) {
//                     distances[next] = distances[current] + 1;
//                     queue.Enqueue(next);
//                 }
//             }
//         }
//
//         int max = 0;
//
//         for (int i = 0; i < distances.Length; i++)
//         {
//             var distance = distances[i];
//             if (distance > max)
//             {
//                 answer = 0;
//                 max = distance;
//                 answer++;
//             }else if (distance == max)
//             {
//                 answer++;
//             }
//         }
//
//         return answer;
//     }
// }