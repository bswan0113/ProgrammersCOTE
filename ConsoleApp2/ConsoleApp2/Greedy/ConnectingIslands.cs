// using System;
// using System.Collections.Generic;
// using System.Linq;
//
// public class Solution {
//     public int solution(int n, int[,] costs) {
//         int answer = 0;
//         List<(int start,int end ,int cost)> list = new List<(int,int,int)>();
//         int[] islands = new int[n];
//         for (int i = 0; i < n; i++)
//         {
//             islands[i] = i;
//         }
//
//         for (int i = 0; i < costs.GetLength(0); i++) {
//             list.Add((costs[i, 0], costs[i, 1], costs[i, 2]));
//         }
//         list.Sort((a, b) => a.cost.CompareTo(b.cost));
//
//         foreach (var island in list)
//         {
//             int parentA = GetParent(islands, island.start);
//             int parentB = GetParent(islands, island.end);
//             if (parentA != parentB)
//             {
//                 islands[parentA] = parentB;
//                 answer += island.cost;
//             }
//         }
//
//         return answer;
//     }
//
//     public int GetParent(int [] islands, int node)
//     {
//         if (islands[node] == node)
//         {
//             return node;
//         }
//         else
//         {
//             return GetParent(islands, islands[node]);
//         }
//     }
//
//
// }