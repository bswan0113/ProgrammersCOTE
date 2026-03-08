class Solution {
    public String solution(String[] participant, String[] completion) {
        String answer = "";
        participant = Arrays.stream(participant).sorted().toArray(String[]::new);
        completion = Arrays.stream(completion).sorted().toArray(String[]::new);
        for(int i= 0; i < completion.length; i++){
            if(!participant[i].equals(completion[i])){
                answer = participant[i];
                break;
            }
        }   
        return answer;
    }
}