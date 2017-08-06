using System;

namespace Jal.Monads
{
    public static class ExceptionExtensions
    {
        public static Result ToResult(this Exception content)
        {
            return Result.Failure(new []{content.Message, content.StackTrace});
        }

        public static Result ToResult<TOutput>(this Exception content)
        {
            return Result.Failure<TOutput>(new[] { content.Message, content.StackTrace });
        }
    }
}