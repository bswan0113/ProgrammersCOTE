import java.util.*;

public class Solution {
    public int[] solution(int []arr) {
        int prevNum = -1;
        List<Integer> resultList = new ArrayList<>();
        for (int num : arr) {
            if (num != prevNum) {
                prevNum = num;
                resultList.add(num);
            }
        }
        int[] answer = new int[resultList.size()];
        for (int i = 0; i < resultList.size(); i++) {
            answer[i] = resultList.get(i);
        }
        return answer;
    }
}