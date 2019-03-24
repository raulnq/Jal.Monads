using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Jal.Monads.Result;
using Shouldly;
using Jal.Monads.Extensions;

namespace Jal.Monads.Test
{
    [TestClass]
    public class ResultTests
    {
        [TestMethod]
        public void ToSuccess_WithIntAndNoError_ShouldBeTrue()
        {
            var sut = 5.ToSuccess<int, string>();

            sut.IsSuccess.ShouldBeTrue();

            sut.IsFailure.ShouldBeFalse();

            sut.Content.ShouldBe(5);

            sut.Error.ShouldBe(default(string));
        }

        [TestMethod]
        public void Success_WithIntAndNoError_ShouldBeTrue()
        {
            var sut = Success<int, string>(5);

            sut.IsSuccess.ShouldBeTrue();

            sut.IsFailure.ShouldBeFalse();

            sut.Content.ShouldBe(5);

            sut.Error.ShouldBe(default(string));
        }

        [TestMethod]
        public void Success_WithNoError_ShouldBeTrue()
        {
            var sut = Success<string>();

            sut.IsSuccess.ShouldBeTrue();

            sut.IsFailure.ShouldBeFalse();

            sut.Error.ShouldBe(default(string));
        }

        [TestMethod]
        public void Failure_WithIntAndError_ShouldBeTrue()
        {
            var sut = Failure<int, string>("error");

            sut.IsSuccess.ShouldBeFalse();

            sut.IsFailure.ShouldBeTrue();

            sut.Content.ShouldBe(0);

            sut.Error.ShouldBe("error");
        }

        [TestMethod]
        public void ToFailure_WithIntAndError_ShouldBeTrue()
        {
            var sut = "error".ToFailure<int, string>();

            sut.IsSuccess.ShouldBeFalse();

            sut.IsFailure.ShouldBeTrue();

            sut.Content.ShouldBe(0);

            sut.Error.ShouldBe("error");
        }

        [TestMethod]
        public void Failure_WithError_ShouldBeTrue()
        {
            var sut = Failure("error");

            sut.IsSuccess.ShouldBeFalse();

            sut.IsFailure.ShouldBeTrue();

            sut.Error.ShouldBe("error");
        }

        [TestMethod]
        public void ToFailure_WithError_ShouldBeTrue()
        {
            var sut = "error".ToFailure();

            sut.IsSuccess.ShouldBeFalse();

            sut.IsFailure.ShouldBeTrue();

            sut.Error.ShouldBe("error");
        }

        [TestMethod]
        public void ImplicitOperator_FromErrorToResult_ShouldBeTrue()
        {
            Result<int, string> sut = "error";

            sut.IsSuccess.ShouldBeFalse();

            sut.IsFailure.ShouldBeTrue();

            sut.Content.ShouldBe(0);

            sut.Error.ShouldBe("error");
        }

        [TestMethod]
        public void ImplicitOperator_FromNoErrorToResult_ShouldBeTrue()
        {
            Result<int, string> sut = 5;
            
            sut.IsSuccess.ShouldBeTrue();

            sut.IsFailure.ShouldBeFalse();

            sut.Content.ShouldBe(5);

            sut.Error.ShouldBe(default(string));
        }

        [TestMethod]
        public void ImplicitOperator_FromResultToNoError_ShouldBe()
        {
            var value = Success<int, string>(5);

            int sutsuccess = value;

            string sutfailure = value;

            sutsuccess.ShouldBe(5);

            sutfailure.ShouldBe(default(string));
        }

        [TestMethod]
        public void ImplicitOperator_FromResultToError_ShouldBe()
        {
            var value = Failure<int, string>("error");

            string sutfailure = value;

            int sutsuccess = value;

            sutfailure.ShouldBe("error");

            sutsuccess.ShouldBe(default(int));
        }
    }
}