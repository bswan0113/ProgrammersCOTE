// using System;
// using System.Collections.Generic;
//
// public class Solution {
//     public int[] solution(int[] prices) {
//         int[] answer = new int[prices.Length];
//
//         for (int i = 0; i < prices.Length; i++) {
//             int count = 0;
//             for (int j = i + 1; j < prices.Length; j++) {
//                 count++;
//
//                 if (prices[i] > prices[j]) {
//                     break;
//                 }
//             }
//             answer[i] = count;
//         }
//         return answer;
//     }
// }