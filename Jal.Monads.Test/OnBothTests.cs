using NUnit.Framework;

namespace Jal.Monads.Test
{
    public class OnBothTests : AbstractTests
    {

        [Test]
        public void OnBoth_WithInputAndAction_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Success("");

            var result = sut.OnBoth(() => { executed = true; });

            SuccessEval(result, executed);
        }

        [Test]
        public void OnBoth_WithInputAndAction_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Result.Failure<string>("");

            var result = sut.OnBoth(() => { executed = true; });

            FailureEval(result, !executed);
        }

        [Test]
        public void OnBoth_WithAction_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Success();

            var result = sut.OnBoth(() => { executed = true; });

            SuccessEval(result, executed);

        }

        [Test]
        public void OnBoth_WithAction_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Result.Failure("");

            var result = sut.OnBoth(() => { executed = true; });

            FailureEval(result, !executed);
        }

        [Test]
        public void OnBoth_WithFunc_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Success();

            var result = sut.OnBoth(() =>
                {
                    executed = true;
                    return Result.Success();
                }
                ,errors =>
                {
                    executed = false;
                    return Result.Success();
                });

            SuccessEval(result, executed);
        }

        [Test]
        public void OnBoth_WithFunc_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Result.Failure("");

            var result = sut.OnBoth(() =>
                {
                    executed = false;
                    return Result.Success();
                }
                , errors =>
                {
                    executed = true;
                    return Result.Success();
                });

            SuccessEval(result, executed);
        }

        [Test]
        public void OnBoth_WithInputAndFunc_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Success("");

            var result = sut.OnBoth(x =>
                {
                    executed = true;
                    return Result.Success();
                }
                , errors =>
                {
                    executed = false;
                    return Result.Success();
                });

            SuccessEval(result, executed);
        }

        [Test]
        public void OnBoth_WithInputAndFunc_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Result.Failure<string>("");

            var result = sut.OnBoth(x =>
                {
                    executed = false;
                    return Result.Success();
                }
                , errors =>
                {
                    executed = true;
                    return Result.Success();
                });

            SuccessEval(result, executed);
        }


        [Test]
        public void OnBoth_WithInputAndFuncResultInput_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Success("");

            var result = sut.OnBoth<string>(x =>
                {
                    executed = true;
                    return Result.Success("");
                }
                , errors =>
                {
                    executed = false;
                    return Result.Success("");
                });

            SuccessEval(result, executed);
        }

        [Test]
        public void OnBoth_WithInputAndFuncResultInput_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Result.Failure<string>("");

            var result = sut.OnBoth<string>(x =>
                {
                    executed = false;
                    return Result.Success("");
                }
                , errors =>
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

            var result = sut.OnBoth(x =>
                {
                    executed = true;
                    return Result.Success<int?>(1);
                }
                , errors =>
                {
                    executed = false;
                    return Result.Success<int?>(1);
                });

            SuccessEval(result, executed);
        }

        [Test]
        public void OnBoth_WithInputAndFuncOutput_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Result.Failure<string>("");

            var result = sut.OnBoth(x =>
                {
                    executed = false;
                    return Result.Success<int?>(1);
                }
                , errors =>
                {
                    executed = true;
                    return Result.Success<int?>(1);
                });

            SuccessEval(result, executed);
        }

        [Test]
        public void OnBoth_With2Action_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Success();

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

        [Test]
        public void OnBoth_With2Action_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Result.Failure("");

            var result = sut.OnBoth(() =>
                {
                    executed = false;
                }
                , errors =>
                {
                    executed = true;
                });

            SuccessEval(result, executed);
        }

        [Test]
        public void OnBoth_WithInputAnd2Action_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Success("");

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

        [Test]
        public void OnBoth_WithInputAnd2Action_ShouldNotBeExecuted()
        {
            var executed = false;

            var sut = Result.Failure<string>("");

            var result = sut.OnBoth(() =>
                {
                    executed = false;
                }
                , errors =>
                {
                    executed = true;
                });

            SuccessEval(result, executed);
        }
    }
}