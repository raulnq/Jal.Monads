using NUnit.Framework;
using System.Threading.Tasks;

namespace Jal.Monads.Test
{
    public class OnSuccessTests : AbstractTests
    {

        [Test]
        public void OnSuccess_WithInputAndAction_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Success("");

            var result = sut.OnSuccess(x => { executed = true; });

            SuccessEval(result, executed); 
        }


        [Test]
        public void OnSuccess_WithInputAndAction_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Result.Failure<string>("");

            var result = sut.OnSuccess(x => { executed=true; });

            FailureEval(result, executed);
        }

        [Test]
        public void OnSuccess_WithAction_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Success();

            var result = sut.OnSuccess(() => { executed = true; });

            SuccessEval(result, executed);

        }

        [Test]
        public void OnSuccess_WithAction_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Result.Failure("");

            var result = sut.OnSuccess(() => { executed = true; });

            FailureEval(result, executed);
        }

        [Test]
        public void OnSuccess_WithFunc_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Success();

            var result = sut.OnSuccess(() =>
            {
                executed = true;
                return Result.Success();
            });

            SuccessEval(result, executed);
        }

        [Test]
        public void OnAsyncSuccess_WithFunc_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Task.FromResult(Result.Success());

            var result = sut.OnSuccessAsync(async () =>
            {
                executed = true;
                return await Task.FromResult(Result.Success());
            });

            SuccessAsyncEval(result, executed);
        }

        [Test]
        public void OnSuccess_WithFunc_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Result.Failure("");

            var result = sut.OnSuccess(() =>
            {
                executed = true;
                return Result.Success();
            });

            FailureEval(result, executed);
        }

        [Test]
        public void OnSuccess_WithInputAndFunc_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Success("");

            var result = sut.OnSuccess(x =>
            {
                executed = true;
                return Result.Success();
            });

            SuccessEval(result, executed);
        }

        [Test]
        public void OnSuccess_WithInputAndFunc_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Result.Failure<string>("");

            var result = sut.OnSuccess(x =>
            {
                executed = true;
                return Result.Success();
            });

            FailureEval(result, executed);
        }

        [Test]
        public void OnSuccess_WithFuncResultOutput_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Success();

            var result = sut.OnSuccess(() =>
            {
                executed = true;
                return Result.Success<int?>(1);
            });

            SuccessEval(result, executed);
        }

        [Test]
        public void OnSuccess_WithFuncResultOutput_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Result.Failure("");

            var result = sut.OnSuccess(() =>
            {
                executed = true;
                return Result.Success<int?>(1);
            });

            FailureEval(result, executed);
        }

        [Test]
        public void OnSuccess_WithInputAndFuncResultOutput_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Success("");

            var result = sut.OnSuccess(x =>
            {
                executed = true;
                return Result.Success<int?>(1);
            });

            SuccessEval(result, executed);
        }

        [Test]
        public void OnSuccess_WithInputAndFuncResultOutput_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Result.Failure<string>("");

            var result = sut.OnSuccess(x =>
            {
                executed = true;
                return Result.Success<int?>(1);
            });

            FailureEval(result, executed);
        }
    }
}