using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;
using Jal.Monads.Extensions;

namespace Jal.Monads.Test
{
    public class Error
    {
        public string Description { get; set; }
    }

    [TestClass]
    public class ReturnTests
    {
        [TestMethod]
        public void Return_WithOutputAndOnSucess_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result<Error>.Success();

            var result = sut.Return(() =>
                {
                    executed = true;
                    return "";
                }
                , (Error error) =>
                {
                    executed = false;
                    return string.Empty;
                });

            executed.ShouldBeTrue();

            result.ShouldBe("");
        }

        [TestMethod]
        public void Return_WithOutputAndOnFailure_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result<Error>.Failure(new Error());

            var result = sut.Return(() =>
                {
                    executed = false;
                    return string.Empty;
                }
                , (Error error) =>
                {
                    executed = true;
                    return "";
                });

            executed.ShouldBeTrue();

            result.ShouldBe("");

        }

        [TestMethod]
        public void Return_WithOutputAndOnSucess2_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result<Error>.Success();

            var result = sut.Return(() =>
                {
                    executed = true;
                    return "";
                }
                , (Error error) =>
                {
                    executed = false;
                    return string.Empty;
                });

            executed.ShouldBeTrue();

            result.ShouldBe("");
        }

        [TestMethod]
        public void Return_WithOutputAndOnFailure2_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result<Error>.Failure(new Error());

            var result = sut.Return(() =>
                {
                    executed = false;
                    return string.Empty;
                }
                , (Error error) =>
                {
                    executed = true;
                    return "";
                });

            executed.ShouldBeTrue();

            result.ShouldBe("");

        }

        [TestMethod]
        public void Return_WithInputOutputAndOnSucess_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result<string, Error>.Success("");

            var result = sut.Return(x =>
            {
                executed = true;
                return "";
            }
            , (Error error) =>
            {
                executed = false;
                return string.Empty;
            });

            executed.ShouldBeTrue();

            result.ShouldBe("");
        }

        [TestMethod]
        public void Return_WithInputOutputAndOnFailure_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result<string, Error>.Failure(new Error());

            var result = sut.Return(x =>
            {
                executed = false;
                return string.Empty;
            }
                , (Error error) =>
                {
                    executed = true;
                    return "";
                });

            executed.ShouldBeTrue();

            result.ShouldBe("");

        }

        [TestMethod]
        public void Return_WithInputOutputAndOnSucess2_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result<int, Error>.Success(1);

            var result = sut.Return(x =>
            {
                executed = true;
                return "";
            }
                , (Error error) =>
                {
                    executed = false;
                    return string.Empty;
                });

            executed.ShouldBeTrue();

            result.ShouldBe("");
        }

        [TestMethod]
        public void Return_WithInputOutputAndOnFailure2_ShouldBeExecuted()
        {
            var executed = false;

            var sut = Result<int, Error>.Failure(new Error());

            var result = sut.Return(x =>
            {
                executed = false;
                return string.Empty;
            }
                , (Error error) =>
                {
                    executed = true;
                    return "";
                });

            executed.ShouldBeTrue();

            result.ShouldBe("");

        }
    }
}