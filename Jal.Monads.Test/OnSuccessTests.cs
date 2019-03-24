using NUnit.Framework;
using System.Threading.Tasks;
using Jal.Monads.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Jal.Monads.Result;

namespace Jal.Monads.Test
{

    [TestClass]
    public class OnSuccessTests : AbstractTests
    {

        [TestMethod]
        public void OnSuccess_WithInputAndAction_ShouldBeExecuted()
        {
            var executed = false;

            var sut = "".ToSuccess<string, Error>();

            var result = sut.OnSuccess(x => { executed = true; });

            SuccessEval(result, executed); 
        }


        [TestMethod]
        public void OnSuccess_WithInputAndAction_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = new Error().ToFailure<string, Error>();

            var result = sut.OnSuccess(x => { executed=true; });

            FailureEval(result, executed);
        }

        [TestMethod]
        public void OnSuccess_WithAction_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Success<Error>();

            var result = sut.OnSuccess(() => { executed = true; });

            SuccessEval(result, executed);

        }

        [TestMethod]
        public void OnSuccess_WithAction_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Failure(new Error());

            var result = sut.OnSuccess(() => { executed = true; });

            FailureEval(result, executed);
        }

        [TestMethod]
        public void OnSuccess_WithFunc_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Success<Error>();

            var result = sut.OnSuccess(() =>
            {
                executed = true;
                return Success<Error>();
            });

            SuccessEval(result, executed);
        }

        //[TestMethod]
        //public void OnAsyncSuccess_WithFunc_ShouldBeExecuted()
        //{
        //    var executed = false;

        //    var sut = Task.FromResult(Result.Success());

        //    var result = sut.OnSuccessAsync(async () =>
        //    {
        //        executed = true;
        //        return await Task.FromResult(Result.Success());
        //    });

        //    SuccessAsyncEval(result, executed);
        //}

        [TestMethod]
        public void OnSuccess_WithFunc_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Failure<string, Error>(new Error());

            var result = sut.OnSuccess(() =>
            {
                executed = true;
                return Success<int, Error>(5);
            });

            FailureEval(result, executed);
        }

        [TestMethod]
        public void OnSuccess_WithInputAndFunc_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Success<string, Error>("");

            var result = sut.OnSuccess(x =>
            {
                executed = true;
                return Success<int, Error>(5);
            });

            SuccessEval(result, executed);
        }

        [TestMethod]
        public void OnSuccess_WithInputAndFunc_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Failure<string, Error>(new Error());

            var result = sut.OnSuccess(x =>
            {
                executed = true;
                return Success<Error>();
            });

            FailureEval(result, executed);
        }

        [TestMethod]
        public void OnSuccess_WithFuncResultOutput_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Success<Error>();

            var result = sut.OnSuccess(() =>
            {
                executed = true;
                return Success<int, Error>(5);
            });

            SuccessEval(result, executed);
        }

        [TestMethod]
        public void OnSuccess_WithFuncResultOutput_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Failure(new Error());

            var result = sut.OnSuccess(() =>
            {
                executed = true;
                return Success<int, Error>(5);
            });

            FailureEval(result, executed);
        }

        [TestMethod]
        public void OnSuccess_WithInputAndFuncResultOutput_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Success<string, Error>("");

            var result = sut.OnSuccess(x =>
            {
                executed = true;
                return Success<int, Error>(5);
            });

            SuccessEval(result, executed);
        }

        [TestMethod]
        public void OnSuccess_WithInputAndFuncResultOutput_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Failure<string, Error>(new Error());

            var result = sut.OnSuccess(x =>
            {
                executed = true;
                return Success<int, Error>(5);
            });

            FailureEval(result, executed);
        }
    }
}