// using System;
// using System.Collections.Generic;
// using System.Linq;
//
// public class Solution {
//     public int solution(int n, int[] lost, int[] reserve) {
//         Array.Sort(lost);
//         Array.Sort(reserve);
//         List<int> students = new List<int>(new int[n + 1]);
//         foreach (var re in reserve)
//         {
//             students[re]++;
//         }
//
//         foreach (var lo in lost)
//         {
//             students[lo]--;
//         }
//
//         for (int i = 0; i < students.Count; i++)
//         {
//             var student = students[i];
//             if(student == 0) continue;
//             if (student == -1)
//             {
//                 var prevStudent = i == 0 ? 0 : students[i - 1];
//                 if (prevStudent > 0)
//                 {
//                     students[i] = 0;
//                     students[i - 1] = 0;
//                     continue;
//                 }
//                 var nextStudent = i == students.Count - 1 ? 0 : students[i + 1];
//                 if (nextStudent > 0)
//                 {
//                     students[i] = 0;
//                     students[i + 1] = 0;
//                 }
//             }
//         }
//
//
//         return students.Count(student => student >= 0) - 1;
//     }
// }