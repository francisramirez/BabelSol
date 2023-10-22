

namespace BabelSol.Persistence.Core
{
    public class DataResult
    {
        public DataResult()
        {
            this.Success = true;

        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
