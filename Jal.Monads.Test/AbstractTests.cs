using Shouldly;
using System.Threading.Tasks;

namespace Jal.Monads.Test
{
    public abstract class AbstractTests
    {
        public void SuccessEval<TInput>(Result<TInput> result, bool executed)
        {
            executed.ShouldBeTrue();

            result.IsSuccess.ShouldBeTrue();

            result.Content.ShouldNotBeNull();
        }

        public void SuccessAsyncEval<TInput>(Task<Result<TInput>> result, bool executed)
        {
            executed.ShouldBeTrue();

            var r = result.GetAwaiter().GetResult();

            r.IsSuccess.ShouldBeTrue();

            r.Content.ShouldNotBeNull();
        }

        public void SuccessEval(Result result, bool executed)
        {
            executed.ShouldBeTrue();

            result.IsSuccess.ShouldBeTrue();
        }

        public void SuccessAsyncEval(Task<Result> result, bool executed)
        {
            executed.ShouldBeTrue();

            var r = result.GetAwaiter().GetResult();

            r.IsSuccess.ShouldBeTrue();
        }

        public void FailureEval<TInput>(Result<TInput> result, bool executed)
        {
            result.IsSuccess.ShouldBeFalse();

            executed.ShouldBeFalse();

            result.Content.ShouldBeNull();

            result.Errors.ShouldHaveSingleItem();
        }

        public void FailureEval(Result result, bool executed)
        {
            result.IsSuccess.ShouldBeFalse();

            executed.ShouldBeFalse();

            result.Errors.ShouldHaveSingleItem();
        }
    }
}