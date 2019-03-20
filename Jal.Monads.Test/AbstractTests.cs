using Shouldly;
using System.Threading.Tasks;

namespace Jal.Monads.Test
{
    public abstract class AbstractTests
    {
        public void SuccessEval<TInput>(Result<TInput, Error> result, bool executed)
        {
            executed.ShouldBeTrue();

            result.IsSuccess.ShouldBeTrue();

            result.Content.ShouldNotBeNull();
        }

        public void SuccessAsyncEval<TInput>(Task<Result<TInput, Error>> result, bool executed)
        {
            executed.ShouldBeTrue();

            var r = result.GetAwaiter().GetResult();

            r.IsSuccess.ShouldBeTrue();

            r.Content.ShouldNotBeNull();
        }

        public void SuccessEval(Result<Error> result, bool executed)
        {
            executed.ShouldBeTrue();

            result.IsSuccess.ShouldBeTrue();
        }

        public void SuccessAsyncEval(Task<Result<Error>> result, bool executed)
        {
            executed.ShouldBeTrue();

            var r = result.GetAwaiter().GetResult();

            r.IsSuccess.ShouldBeTrue();
        }

        public void FailureEval<TInput>(Result<TInput, Error> result, bool executed)
        {
            result.IsSuccess.ShouldBeFalse();

            executed.ShouldBeFalse();

            result.Content.ShouldBe(default(TInput));
        }

        public void FailureEval(Result<Error> result, bool executed)
        {
            result.IsSuccess.ShouldBeFalse();

            executed.ShouldBeFalse();
        }
    }
}