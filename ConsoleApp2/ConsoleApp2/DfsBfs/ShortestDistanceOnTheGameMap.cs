// using System;
// using System.Collections.Generic;
//
// class Solution {
//     public int solution(int[,] maps) {
//         int n = maps.GetLength(0);
//         int m = maps.GetLength(1);
//
//         int[] dy = { -1, 1, 0, 0 };
//         int[] dx = { 0, 0, -1, 1 };
//
//         int[,] dist = new int[n, m];
//         Queue<(int, int)> q = new Queue<(int, int)>();
//
//         q.Enqueue((0, 0));
//         dist[0, 0] = 1;
//
//         while (q.Count > 0) {
//             var (y, x) = q.Dequeue();
//
//             if (y == n - 1 && x == m - 1) return dist[y, x];
//
//             for (int i = 0; i < 4; i++) {
//                 int ny = y + dy[i];
//                 int nx = x + dx[i];
//
//                 if (ny >= 0 && ny < n && nx >= 0 && nx < m &&
//                     maps[ny, nx] == 1 && dist[ny, nx] == 0) {
//                     dist[ny, nx] = dist[y, x] + 1;
//                     q.Enqueue((ny, nx));
//                 }
//             }
//         }
//
//         return -1;
//     }
// }