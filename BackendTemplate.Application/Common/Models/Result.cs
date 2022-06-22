namespace BackendTemplate.Application.Common.Models
{
    public class Result
    {
        public Result(bool succeeded, Dictionary<string, string[]> errors)
        {
            Succeeded = succeeded;
            Errors = errors;
        }

        public bool Succeeded { get; set; }

        public Dictionary<string, string[]> Errors { get; set; }

        public static Result Success()
        {
            return new Result(true, new Dictionary<string, string[]>());
        }

        public static Result Failure(Dictionary<string, string[]> errors)
        {
            return new Result(false, errors);
        }
    }
}
