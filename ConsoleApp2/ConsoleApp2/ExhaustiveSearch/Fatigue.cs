// using System;
// using System.Collections.Generic;
//
// public class Solution {
//     public int solution(int k, int[,] dungeons) {
//         List<Dungeon> dungeonList = new List<Dungeon>();
//         for (int i = 0; i < dungeons.GetLength(0); i++)
//         {
//             var newDungeon = new Dungeon(dungeons[i, 0], dungeons[i, 1]);
//             dungeonList.Add(newDungeon);
//         }
//
//         return Explore(k, dungeonList, 0);
//     }
//
//     public int Explore(int fatigue, List<Dungeon> dungeons, int count)
//     {
//         int maxExpedition = count;
//
//         foreach (var t in dungeons)
//         {
//             if (t.TryVisit(ref fatigue))
//             {
//                 int result = Explore(fatigue, dungeons, count + 1);
//
//                 if (result > maxExpedition)
//                 {
//                     maxExpedition = result;
//                 }
//
//                 t.UndoVisit(ref fatigue);
//             }
//         }
//
//         return maxExpedition;
//     }
//
//     public class Dungeon
//     {
//         private int _visitCondition;
//         private int _needFatigue;
//         private bool _visited;
//
//         public Dungeon(int visitCondition, int needFatigue)
//         {
//             _visitCondition = visitCondition;
//             _needFatigue = needFatigue;
//         }
//
//         public bool TryVisit(ref int currentFatigue)
//         {
//             if(_visited) return false;
//             if (_visitCondition > currentFatigue) return false;
//             if (_needFatigue > currentFatigue) return false;
//             _visited = true;
//             currentFatigue -= _needFatigue;
//             return true;
//         }
//
//         public void UndoVisit(ref int currentFatigue)
//         {
//             _visited = false;
//             currentFatigue += _needFatigue;
//         }
//     }
// }