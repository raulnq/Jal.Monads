using NUnit.Framework;
using Shouldly;

namespace Jal.Monads.Test
{
    public class ReturnTests
    {
        [Test]
        public void Return_WithOutputAndOnSucess_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Success();

            var result = sut.Return(() =>
                {
                    executed = true;
                    return "";
                }
                , (string errors) =>
                {
                    executed = false;
                    return string.Empty;
                });

            executed.ShouldBeTrue();

            result.ShouldBe("");
        }

        [Test]
        public void Return_WithOutputAndOnFailure_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Failure("");

            var result = sut.Return(() =>
                {
                    executed = false;
                    return string.Empty;
                }
                , (string errors) =>
                {
                    executed = true;
                    return "";
                });

            executed.ShouldBeTrue();

            result.ShouldBe("");

        }

        [Test]
        public void Return_WithOutputAndOnSucess2_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Success();

            var result = sut.Return(() =>
                {
                    executed = true;
                    return "";
                }
                , (string[] errors) =>
                {
                    executed = false;
                    return string.Empty;
                });

            executed.ShouldBeTrue();

            result.ShouldBe("");
        }

        [Test]
        public void Return_WithOutputAndOnFailure2_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Failure("");

            var result = sut.Return(() =>
                {
                    executed = false;
                    return string.Empty;
                }
                , (string[] errors) =>
                {
                    executed = true;
                    return "";
                });

            executed.ShouldBeTrue();

            result.ShouldBe("");

        }

        [Test]
        public void Return_WithInputOutputAndOnSucess_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Success(1);

            var result = sut.Return(x =>
            {
                executed = true;
                return "";
            }
            , (string errors) =>
            {
                executed = false;
                return string.Empty;
            });

            executed.ShouldBeTrue();

            result.ShouldBe("");
        }

        [Test]
        public void Return_WithInputOutputAndOnFailure_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Failure<int>("");

            var result = sut.Return(x =>
            {
                executed = false;
                return string.Empty;
            }
                , (string errors) =>
                {
                    executed = true;
                    return "";
                });

            executed.ShouldBeTrue();

            result.ShouldBe("");

        }

        [Test]
        public void Return_WithInputOutputAndOnSucess2_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Success(1);

            var result = sut.Return(x =>
            {
                executed = true;
                return "";
            }
                , (string[] errors) =>
                {
                    executed = false;
                    return string.Empty;
                });

            executed.ShouldBeTrue();

            result.ShouldBe("");
        }

        [Test]
        public void Return_WithInputOutputAndOnFailure2_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result.Failure<int>("");

            var result = sut.Return(x =>
            {
                executed = false;
                return string.Empty;
            }
                , (string[] errors) =>
                {
                    executed = true;
                    return "";
                });

            executed.ShouldBeTrue();

            result.ShouldBe("");

        }
    }
}