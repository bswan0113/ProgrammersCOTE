import java.util.Arrays;

class Solution {
    public boolean solution(String[] phone_book) {
        boolean answer = true;
        if(phone_book.length == 1) {
            return answer;
        }
        Arrays.sort(phone_book);
        for(int i = 0; i < phone_book.length - 1; i++) {
            if(phone_book[i + 1].startsWith(phone_book[i])) {
                answer = false;
                break;
            }
        }   
        return answer;
    }
}