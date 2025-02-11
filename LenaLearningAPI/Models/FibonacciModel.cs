namespace LenaLearningAPI.Models
{
    [Serializable]
    public class FibonacciNumberResponse
    {
        public int Number {  get; set; }
        public long FibonacciNumber { get; set; }
        public string Message { get; set; }
    }

    [Serializable]
    public class FibonacciListResponse
    {
        public int UpTo { get; set; }
        public long[] FibonacciNumbers { get; set; }
        public string Message { get; set; }
    }

    [Serializable]
    public class FibonacciRangeResponse
    {
        public int Start { get; set; }
        public int End { get; set; }
        public long[] FibonacciNumbers { get; set; }
        public string Message { get; set; }
    }
}
