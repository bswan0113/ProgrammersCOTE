// using System;
//
// public class Solution {
//     public int solution(int[] numbers, int target) {
//         return Descend(numbers, target, 0, 0);
//     }
//
//     public int Descend(int[] numbers, int target, int index, int total) {
//         if (index == numbers.Length)
//         {
//             if (total == target)
//             {
//                 return 1;
//             }
//             return 0;
//         }
//
//         int plus = Descend(numbers, target, index + 1, total + numbers[index]);
//         int minus = Descend(numbers, target, index + 1, total - numbers[index]);
//
//         return plus + minus;
//     }
// }