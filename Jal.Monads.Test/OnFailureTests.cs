﻿using NUnit.Framework;

namespace Jal.Monads.Test
{
    public class OnFailureTests : AbstractTests
    {

        [Test]
        public void OnFailure_WithInputAndAction_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Success("");

            var result = sut.OnFailure(errors => { executed = true; });

            SuccessEval(result, !executed);
        }

        [Test]
        public void OnFailure_WithInputAndAction_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Result.Failure<string>("");

            var result = sut.OnFailure(errors => { executed = true; });

            FailureEval(result, !executed);
        }

        [Test]
        public void OnFailure_WithAction_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Success();

            var result = sut.OnFailure(errors => { executed = true; });

            SuccessEval(result, !executed);

        }

        [Test]
        public void OnFailure_WithAction_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Result.Failure("");

            var result = sut.OnFailure(errors => { executed = true; });

            FailureEval(result, !executed);
        }

        [Test]
        public void OnFailure_WithFunc_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Success();

            var result = sut.OnFailure(errors =>
            {
                executed = true;
                return Result.Success();
            });

            SuccessEval(result, !executed);
        }

        [Test]
        public void OnFailure_WithFunc_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Result.Failure("");

            var result = sut.OnFailure(errors =>
            {
                executed = true;
                return Result.Success();
            });

            SuccessEval(result, executed);
        }

        [Test]
        public void OnFailure_WithInputAndFunc_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Success("");

            var result = sut.OnFailure(errors =>
            {
                executed = true;
                return Result.Success();
            });

            SuccessEval(result, !executed);
        }

        [Test]
        public void OnFailure_WithInputAndFunc_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Result.Failure<string>("");

            var result = sut.OnFailure(errors =>
            {
                executed = true;
                return Result.Success();
            });

            SuccessEval(result, executed);
        }


        [Test]
        public void OnFailure_WithInputAndFuncResultInput_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Success("");

            var result = sut.OnFailure(x =>
            {
                executed = true;
                return Result.Success("");
            });

            SuccessEval(result, !executed);
        }

        [Test]
        public void OnFailure_WithInputAndFuncResultInput_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Result.Failure<string>("");

            var result = sut.OnFailure(x =>
            {
                executed = true;
                return Result.Success("");
            });

            SuccessEval(result, executed);
        }

        [Test]
        public void OnFailure_WithInputAndFuncOutput_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Success("");

            var result = sut.OnFailure(x =>
            {
                executed = true;
                return "";
            });

            SuccessEval(result, !executed);
        }

        [Test]
        public void OnFailure_WithInputAndFuncOutput_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Result.Failure<string>("");

            var result = sut.OnFailure(x =>
            {
                executed = true;
                return "";
            });

            SuccessEval(result, executed);
        }
    }
}