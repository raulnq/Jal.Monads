using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;
using Jal.Monads.Extensions;
using static Jal.Monads.Result;

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

            var sut = Success<Error>();

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

            var sut = Failure(new Error());

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

            var sut = Success<Error>();

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

            var sut = Failure(new Error());

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

            var sut = Success<string, Error>("");

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

            var sut = Failure<string, Error>(new Error());

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

            var sut = Success<int, Error>(1);

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

            var sut = Failure<int, Error>(new Error());

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