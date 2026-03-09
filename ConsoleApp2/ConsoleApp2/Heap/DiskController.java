import java.util.Comparator;
import java.util.PriorityQueue;

class Solution {
    public int solution(int[][] jobs) {
        int answer = 0;
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
            WaitWorker work = new WaitWorker(i, jobs[i][0], jobs[i][1]);
            allWorker.offer(work);
        }

        int globalTime = 0;

        while (!allWorker.isEmpty() || !waitQueue.isEmpty()) {
            WaitWorker nextWork = allWorker.peek();
            
            if (nextWork != null && nextWork.requestTime == globalTime) {
                WaitWorker work = allWorker.poll();
                waitQueue.offer(work);
            }

            if (hardDisk.IsWorking()) {
                WorkResult isWorkEnd = hardDisk.Work();
                totalWaitTime += isWorkEnd.totalWorkTime;
                hardDisk.StartWorking(waitQueue.poll());
            } else {
                hardDisk.StartWorking(waitQueue.poll());
            }
            for(int i=0; i<waitQueue.size(); i++) {
                waitQueue.peek().WaitTick();
            }

            globalTime++;
        }
        answer = totalWaitTime / jobs.length;

        return answer;
    }

    class WaitWorker {
        public int num;
        public int requestTime;
        public int timeTaken;
        public int waitTime;

        public WaitWorker(int num, int requestTime, int timeTaken) {
            this.num = num;
            this.requestTime = requestTime;
            this.timeTaken = timeTaken;
        }

        public void WaitTick() {
            waitTime++;
        }
    }

    class WorkResult {
        public boolean isWorkEnd;
        public int totalWorkTime;
        
        public WorkResult(boolean isWorkEnd, int totalWorkTime) {
            this.isWorkEnd = isWorkEnd;
            this.totalWorkTime = totalWorkTime;
        }
    }

    class HardDisk {
        private WaitWorker _currentWorker;
        private int _workingTime;

        public boolean IsWorking() {
            return _currentWorker != null;
        }

        public void StartWorking(WaitWorker worker) {
            _currentWorker = worker;
            Work();
        }

        public WorkResult Work() {
            if (_currentWorker == null) return new WorkResult(false, 0);
            _workingTime++;
            if (_workingTime == _currentWorker.timeTaken) {
                int totalWorkTime = _workingTime - _currentWorker.waitTime;
                EndWorking();
                return new WorkResult(true, totalWorkTime);
            }
            return new WorkResult(false, 0);
        }

        private void EndWorking() {
            _currentWorker = null;
            _workingTime = 0;
        }
    }
}