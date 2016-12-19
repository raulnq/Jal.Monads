namespace Jal.Monads
{
    public sealed class Result<T> : Result
    {
        public T Content { get; }

        public Result(T content) : base(true, new string[] { })
        {
            Content = content;
        }

        public Result(string[] errors) : base(false, errors)
        {
            Content = default(T);
        }

        public static implicit operator Result<T>(T content)
        {
            return new Result<T>(content);
        }

        public static explicit operator T(Result<T> result)
        {
            return result.Content;
        }
    }

    public class Result
    {
        public string[] Errors { get; }

        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;

        protected Result(bool isSuccess, string[] errors)
        {
            IsSuccess = isSuccess;
            Errors = errors;
        }

        public static Result Failure(string[] errors)
        {
            return new Result(false, errors);
        }

        public static Result Success()
        {
            return new Result(true, new string[] { });
        }

        public static Result<TContent> Success<TContent>(TContent content)
        {
            return new Result<TContent>(content);
        }

        public static Result<TContent> Failure<TContent>(string[] errors)
        {
            return new Result<TContent>(errors);
        }
    }
}
