namespace SsdtProjectHelper.Common
{
    public class ProcessingResult
    {
        public ProcessingResult(ResultType resultType, string content)
        {
            ResultType = resultType;
            Content = content;
        }

        public ResultType ResultType { get; }
        public string Content { get; }
    }
}
