
import java.util.PriorityQueue;

class Solution {
    public int solution(int[] scoville, int K) {
        int answer = 0;
        int resultScoville = 0;
        PriorityQueue<Integer> pq = new PriorityQueue<>();
        for (int i : scoville) {
            if(i < K) {
                pq.offer(i);
            }   
        }
        while(!pq.isEmpty()){
            if(pq.size() == 1){
                if(pq.poll() < K){
                    return -1;
                } else {
                    break;
                }
            } 
            int first = pq.poll();
            int second = pq.poll();
            resultScoville = first + (second * 2);
            if(resultScoville < K){
                pq.offer(resultScoville);
            }
            answer++;
        }

        return answer;
    }
}