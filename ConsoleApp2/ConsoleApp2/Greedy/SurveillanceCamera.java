import java.util.Arrays;

class Solution {
    public int solution(int[][] routes) {
        int answer = 0;
        Arrays.sort(routes, (x, y) -> Integer.compare(x[1], y[1]));
        int lastCameraPosition = Integer.MIN_VALUE;
        for (int i = 0; i < routes.length; i++) {
            if (lastCameraPosition < routes[i][0]) {
                lastCameraPosition = routes[i][1];
                answer++;
            }
        }
        return answer;
    }
}