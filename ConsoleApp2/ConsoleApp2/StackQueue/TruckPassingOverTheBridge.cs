using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int bridge_length, int weight, int[] truck_weights) {
        int answer = 0;
        Dictionary<int, int> truckDictionary = new Dictionary<int, int>();
        Queue<int> truckQueue = new Queue<int>();
        Queue<(int truck, int entryTime)> bridgeQueue = new Queue<(int , int)>();
        for (int i = 0; i < truck_weights.Length; i++)
        {
            truckDictionary.Add(i, truck_weights[i]);
            truckQueue.Enqueue(i);
        }

        int totalWeight = 0;
        int time = 0;

        while (truckQueue.Count > 0)
        {
            time++;
            if (bridgeQueue.Count > 0 && time == bridgeQueue.Peek().entryTime + bridge_length)
            {
                var outTruck = bridgeQueue.Dequeue();
                totalWeight -= truckDictionary[outTruck.truck];
            }

            if (bridgeQueue.Count < bridge_length && totalWeight + truckDictionary[truckQueue.Peek()] <= weight)
            {
                var truck = truckQueue.Dequeue();
                totalWeight += truckDictionary[truck];
                bridgeQueue.Enqueue((truck, time));
            }
            else
            {
                if (bridgeQueue.Count > 0)
                {
                    time = bridgeQueue.Peek().entryTime + bridge_length - 1;
                }
            }
        }

        answer = time + bridge_length;
        return answer;
    }
}
