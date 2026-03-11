// using System;
// using System.Collections.Generic;
//
// public class Solution {
//     public int solution(int n, int[,] computers) {
//         Dictionary<int, HashSet<int>> networkMap = new Dictionary<int, HashSet<int>>();
//
//         for (int i = 0; i < n; i++)
//         {
//             networkMap.Add(i, new HashSet<int>());
//             networkMap[i].Add(i);
//         }
//
//         for (int i = 0; i < n; i++)
//         {
//             for (int j = 0; j < n; j++)
//             {
//                 if (i == j) continue;
//
//                 if (computers[i, j] == 1)
//                 {
//                     int keyI = -1;
//                     int keyJ = -1;
//
//                     foreach (var kvp in networkMap)
//                     {
//                         if (kvp.Value.Contains(i)) keyI = kvp.Key;
//                         if (kvp.Value.Contains(j)) keyJ = kvp.Key;
//                     }
//
//                     if (keyI != -1 && keyJ != -1 && keyI != keyJ)
//                     {
//                         networkMap[keyI].UnionWith(networkMap[keyJ]);
//                         networkMap.Remove(keyJ);
//                     }
//                 }
//             }
//         }
//
//         return networkMap.Count;
//     }
// }

// using System;
// using System.Collections.Generic;
//
// public class Solution {
//     public int solution(int n, int[,] computers) {
//         int[] parent = new int[n];
//
//         for (int i = 0; i < n; i++) {
//             parent[i] = i;
//         }
//
//         int Find(int x) {
//             if (parent[x] == x) return x;
//             return parent[x] = Find(parent[x]);
//         }
//
//         void Union(int a, int b) {
//             int rootA = Find(a);
//             int rootB = Find(b);
//             if (rootA != rootB) {
//                 parent[rootB] = rootA;
//             }
//         }
//
//         for (int i = 0; i < n; i++) {
//             for (int j = 0; j < n; j++) {
//                 if (i != j && computers[i, j] == 1) {
//                     Union(i, j);
//                 }
//             }
//         }
//
//         HashSet<int> networkSet = new HashSet<int>();
//         for (int i = 0; i < n; i++) {
//             networkSet.Add(Find(i));
//         }
//
//         return networkSet.Count;
//     }
// }
// using System;
//
// public class Solution {
//     public int solution(int n, int[,] computers) {
//         int answer = 0;
//         bool[] visited = new bool[n];
//
//         void DFS(int current) {
//             visited[current] = true;
//             for (int next = 0; next < n; next++) {
//                 if (current != next && computers[current, next] == 1 && !visited[next]) {
//                     DFS(next);
//                 }
//             }
//         }
//
//         for (int i = 0; i < n; i++) {
//             if (!visited[i]) {
//                 DFS(i);
//                 answer++;
//             }
//         }
//
//         return answer;
//     }
// }