// using System;
// using System.Collections.Generic;
// using System.Linq;
//
// public class Solution {
//     public int solution(string word) {
//         VDictionary dictionary = new VDictionary();
//         return dictionary.GetWordIndex(word);
//     }
//
//     class VDictionary
//     {
//         List<String> words = new List<String>();
//         private Char[] vowels = new[] {'A', 'E', 'I', 'O', 'U'};
//
//         private const int MaxWordLength = 5;
//
//         public VDictionary()
//         {
//             words.Add("A");
//             var canCreate = true;
//             for (int i = 0; canCreate; i++)
//             {
//                 string prevWord = words[i];
//                 string nextWord = GetNextWord(prevWord);
//                 words.Add(nextWord);
//                 if (nextWord == "UUUUU")
//                 {
//                     canCreate = false;
//                 }
//             }
//         }
//
//         public int GetWordIndex(string word)
//         {
//             if (!words.Contains(word)) return -1;
//             return words.IndexOf(word) + 1;
//         }
//
//         public string GetNextWord(string currentWord)
//         {
//             if (CanIncreaseLength(currentWord))
//             {
//                 return currentWord + vowels[0];
//             }
//             else
//             {
//                 for (int i = currentWord.Length - 1; i >= 0; i--)
//                 {
//                     var targetChar = currentWord[i];
//                     if (CanIncreaseIndex(targetChar))
//                     {
//                         var nextChar = GetNextChar(targetChar);
//                         return currentWord.Substring(0, i) + nextChar;
//                     }
//                 }
//             }
//
//             return "";
//         }
//
//         public int GetIndex(char c)
//         {
//             return Array.IndexOf(vowels, c);
//         }
//
//         public char GetNextChar(char c)
//         {
//             return vowels[GetIndex(c) + 1];
//         }
//
//         public bool CanIncreaseIndex(char c)
//         {
//             return c != vowels[vowels.Length - 1];
//         }
//
//         public bool CanIncreaseLength(string currentWord)
//         {
//             return currentWord.Length < MaxWordLength;
//         }
//     }
// }