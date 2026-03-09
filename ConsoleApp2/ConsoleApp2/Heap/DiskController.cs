// using System;
// using System.Collections.Generic;
//
// public class Solution {
//     public int solution(int[,] jobs) {
//         int answer = 0;
//         int totalWaitTime = 0;
//         HardDisk hardDisk = new HardDisk();
//         Comparer<WaitWorker> comparer = Comparer<WaitWorker>.Create((x, y) =>
//         {
//             int timeTaken = x.timeTaken.CompareTo(y.timeTaken);
//             if (timeTaken != 0) return timeTaken;
//             int requestTime = x.requestTime.CompareTo(y.requestTime);
//             return requestTime == 0 ? x.num.CompareTo(y.num) : requestTime;
//         });
//
//         PriorityQueue<WaitWorker, WaitWorker> waitQueue = new PriorityQueue<WaitWorker, WaitWorker>(comparer);
//         PriorityQueue<WaitWorker, int> allWorker = new PriorityQueue<WaitWorker, int>();
//         for (int i = 0; i < jobs.GetLength(0); i++)
//         {
//             var work = new WaitWorker(i, jobs[i, 0], jobs[i, 1]);
//             allWorker.Enqueue(work, work.requestTime);
//         }
//
//         int globalTime = 0;
//
//         while (allWorker.Count > 0 || waitQueue.Count > 0)
//         {
//             var nextWork = allWorker.Peek();
//             if (nextWork.requestTime == globalTime)
//             {
//                 var work = allWorker.Dequeue();
//                 waitQueue.Enqueue(work,work);
//             }
//
//             var nextWorker = waitQueue.Dequeue();
//             if (!hardDisk.IsWorking)
//             {
//                 var isWorkEnd = hardDisk.Work();
//                 totalWaitTime += isWorkEnd.totalWorkTime;
//                 hardDisk.StartWorking(nextWorker);
//             }
//             else
//             {
//                 hardDisk.StartWorking(nextWorker);
//             }
//
//             globalTime++;
//         }
//
//
//         return answer;
//     }
//
//     class WaitWorker
//     {
//         public int num;
//         public int requestTime;
//         public int timeTaken;
//         public int waitTime;
//
//         public WaitWorker(int num, int requestTime, int timeTaken)
//         {
//             this.num = num;
//             this.requestTime = requestTime;
//             this.timeTaken = timeTaken;
//         }
//
//         public void Wait()
//         {
//             waitTime++;
//         }
//     }
//
//     class HardDisk
//     {
//         private WaitWorker? _currentWorker;
//         public bool IsWorking => _currentWorker != null;
//         private int _workingTime;
//
//         public void StartWorking(WaitWorker worker)
//         {
//             _currentWorker = worker;
//             Work();
//         }
//
//         public (bool isWorkEnd, int totalWorkTime) Work()
//         {
//             if (_currentWorker == null) return (false,0);
//             _workingTime++;
//             if (_workingTime == _currentWorker.timeTaken)
//             {
//                 var totalWorkTime = _workingTime - _currentWorker.waitTime;
//                 EndWorking();
//                 return (true, totalWorkTime);
//             }
//             return (false,0);
//         }
//
//         private void EndWorking()
//         {
//             _currentWorker = null;
//             _workingTime = 0;
//         }
//     }
//
// }