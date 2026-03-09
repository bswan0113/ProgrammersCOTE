// using System;
// using System.Collections.Generic;
// using System.Linq;
//
// public class Solution {
//     public int solution(string numbers) {
//         int answer = 0;
//         HashSet<int> numberSet = new HashSet<int>();
//         bool[] visited = new bool[numbers.Length];
//
//         Permute("", numbers, visited, numberSet);
//
//         foreach (int num in numberSet)
//         {
//             if (IsPrime(num))
//             {
//                 answer++;
//             }
//         }
//
//         return answer;
//     }
//
//     void Permute(string current, string chars, bool[] visited, HashSet<int> result)
//     {
//         if (current != "")
//         {
//             result.Add(int.Parse(current));
//         }
//
//         for (int i = 0; i < chars.Length; i++)
//         {
//             if (visited[i]) continue;
//
//             visited[i] = true;
//             Permute(current + chars[i], chars, visited, result);
//             visited[i] = false;
//         }
//     }
//
//     public bool IsPrime(int n) {
//         if (n < 2) return false;
//
//         for (int i = 2; i * i <= n; i++) {
//             if (n % i == 0) return false;
//         }
//         return true;
//     }
// }