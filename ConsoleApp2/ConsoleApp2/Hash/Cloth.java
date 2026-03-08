
import java.util.*;

class Solution {
    public int solution(String[][] clothes) {
        int answer = 1;
        HashMap<String, List<String>> map = new HashMap<>();
        for (String[] cloth : clothes) {
            String type = cloth[1];
            String name = cloth[0];
            if(!map.containsKey(type)){
                map.put(type, new ArrayList<>());
            }
            map.get(type).add(name);
        }
        for(String type : map.keySet()){
            answer *= (map.get(type).size() + 1);
        }
        answer--;
        
        return answer;
    }
}