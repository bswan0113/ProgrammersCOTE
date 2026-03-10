import java.util.Queue;

class Solution {
    public int solution(int[] people, int limit) {
        int answer = 0;
        Arrays.sort(people);
        PrimaryQueue<Integer> bPrimaryQueue = new PrimaryQueue<>();
        PrimaryQueue<Integer> sPrimaryQueue = new PrimaryQueue<>((x, y) -> y - x);
        return answer;
    }
}