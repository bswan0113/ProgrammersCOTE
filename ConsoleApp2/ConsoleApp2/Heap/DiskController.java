import java.util.Comparator;
import java.util.PriorityQueue;

class Solution {
    public int solution(int[][] jobs) {
        int totalWaitTime = 0;
        HardDisk hardDisk = new HardDisk();
        
        Comparator<WaitWorker> comparer = (x, y) -> {
            int timeTaken = Integer.compare(x.timeTaken, y.timeTaken);
            if (timeTaken != 0) return timeTaken;
            int requestTime = Integer.compare(x.requestTime, y.requestTime);
            return requestTime == 0 ? Integer.compare(x.num, y.num) : requestTime;
        };

        PriorityQueue<WaitWorker> waitQueue = new PriorityQueue<>(comparer);
        PriorityQueue<WaitWorker> allWorker = new PriorityQueue<>((x, y) -> Integer.compare(x.requestTime, y.requestTime));
        
        for (int i = 0; i < jobs.length; i++) {
            allWorker.offer(new WaitWorker(i, jobs[i][0], jobs[i][1]));
        }

        int globalTime = 0;

        while (!allWorker.isEmpty() || !waitQueue.isEmpty() || hardDisk.IsWorking()) {
            
            while (!allWorker.isEmpty() && allWorker.peek().requestTime <= globalTime) {
                waitQueue.offer(allWorker.poll());
            }

            if (!hardDisk.IsWorking()) {
                if (waitQueue.isEmpty()) {
                    globalTime = allWorker.peek().requestTime;
                    continue;
                }
                hardDisk.StartWorking(waitQueue.poll(), globalTime);
            }

            WorkResult result = hardDisk.SkipToEnd();
            globalTime = result.endTime;
            totalWaitTime += result.totalWorkTime;
            while (!allWorker.isEmpty() && allWorker.peek().requestTime <= globalTime) {
                waitQueue.offer(allWorker.poll());
            }
        }

        return totalWaitTime / jobs.length;
    }

    class WaitWorker {
        public int num;
        public int requestTime;
        public int timeTaken;

        public WaitWorker(int num, int requestTime, int timeTaken) {
            this.num = num;
            this.requestTime = requestTime;
            this.timeTaken = timeTaken;
        }
    }

    class WorkResult {
        public boolean isWorkEnd;
        public int totalWorkTime;
        public int endTime;
        
        public WorkResult(boolean isWorkEnd, int totalWorkTime, int endTime) {
            this.isWorkEnd = isWorkEnd;
            this.totalWorkTime = totalWorkTime;
            this.endTime = endTime;
        }
    }

    class HardDisk {
        private WaitWorker _currentWorker;
        private int _startTime;

        public boolean IsWorking() {
            return _currentWorker != null;
        }

        public void StartWorking(WaitWorker worker, int currentTime) {
            _currentWorker = worker;
            _startTime = currentTime;
        }

        public WorkResult SkipToEnd() {
            int endTime = _startTime + _currentWorker.timeTaken;
            int totalWorkTime = endTime - _currentWorker.requestTime;
            EndWorking();
            return new WorkResult(true, totalWorkTime, endTime);
        }

        private void EndWorking() {
            _currentWorker = null;
            _startTime = 0;
        }
    }
}