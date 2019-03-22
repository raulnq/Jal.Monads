using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Jal.Monads.Extensions;
using static Jal.Monads.Result;

namespace Jal.Monads.Test
{
    [TestClass]
    public class OnBothTests : AbstractTests
    {

        [TestMethod]
        public void OnBoth_WithAction_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Success<Error>();

            var result = sut.OnSuccess(() => { executed = true; });

            SuccessEval(result, executed);

        }

        [TestMethod]
        public void OnBoth_WithAction_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Failure(new Error());

            var result = sut.OnSuccess(() => { executed = true; });

            FailureEval(result, executed);
        }

        [TestMethod]
        public void OnBoth_With2Action_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Success<Error>();

            var result = sut.OnBoth(() =>
                {
                    executed = true;
                }
                , errors =>
                {
                    executed = false;
                });

            SuccessEval(result, executed);
        }

        [TestMethod]
        public void OnBoth_With2Action_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Failure(new Error());

            var result = sut.OnBoth(() =>
                {
                    executed = false;
                }
                , errors =>
                {
                    executed = true;
                });

            FailureEval(result, !executed);
        }

        [TestMethod]
        public void OnBoth_WithInputAnd2Action_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Success<string, Error>("");

            var result = sut.OnBoth(() =>
                {
                    executed = true;
                }
                , errors =>
                {
                    executed = false;
                });

            SuccessEval(result, executed);
        }

        [TestMethod]
        public void OnBoth_WithInputAnd2Action_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Failure<string, Error>(new Error());

            var result = sut.OnBoth(() =>
                {
                    executed = false;
                }
                , errors =>
                {
                    executed = true;
                });

            FailureEval(result, !executed);
        }
    }
}