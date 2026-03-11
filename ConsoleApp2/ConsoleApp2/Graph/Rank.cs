// using System;
// using System.Collections.Generic;
// using System.Linq;
//
//
// public class Solution {
//     public int solution(int n, int[,] results) {
//         int answer = 0;
//         Dictionary<int, Player> playerDict = new Dictionary<int, Player>();
//
//         for (int i = 1; i <= n; i++)
//         {
//             playerDict.Add(i, new Player(i));
//         }
//
//         for (int i = 0; i < results.GetLength(0); i++)
//         {
//             var winner = playerDict[results[i, 0]];
//             var loser = playerDict[results[i, 1]];
//             playerDict[winner.num].Win(loser);
//             playerDict[loser.num].Lose(winner);
//         }
//
//         int length = n - 1;
//         foreach (var player in playerDict.Values)
//         {
//             int winCount = CountPlayers(player, true);
//             int loseCount = CountPlayers(player, false);
//             if (winCount + loseCount == length)
//             {
//                 answer++;
//             }
//
//         }
//         return answer;
//     }
//
//     public int CountPlayers(Player startPlayer, bool isWinDirection)
//     {
//         HashSet<int> visited = new HashSet<int>();
//         Stack<Player> stack = new Stack<Player>();
//
//         stack.Push(startPlayer);
//         visited.Add(startPlayer.num);
//
//         while (stack.Count > 0)
//         {
//             Player current = stack.Pop();
//             List<Player> nextList = isWinDirection ? current.winList : current.loseList;
//
//             foreach (var next in nextList)
//             {
//                 if (!visited.Contains(next.num))
//                 {
//                     visited.Add(next.num);
//                     stack.Push(next);
//                 }
//             }
//         }
//         return visited.Count - 1;
//     }
//
//
//
//     public class Player
//     {
//         public int num;
//         public List<Player> winList = new List<Player>();
//         public List<Player> loseList = new List<Player>();
//
//         public Player(int num)
//         {
//             this.num = num;
//         }
//
//
//         public void Win(Player loser)
//         {
//             winList.Add(loser);
//         }
//
//         public void Lose(Player winner)
//         {
//             loseList.Add(winner);
//         }
//     }
// }
