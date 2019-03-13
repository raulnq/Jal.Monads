using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace Jal.Monads.Test
{
    [TestClass]
    public class EitherTests
    {
        [TestMethod]
        public void Monitor_WithRightState_ShouldTrue()
        {
            var flag = false;

            var sut = Either.Right<string, int>(10);

            var result = sut.Monitor((int right) => { flag = true; });

            flag.ShouldBeTrue();

            result.IsLeft.ShouldBeFalse();

            result.IsRight.ShouldBeTrue();

            result.Right.ShouldBe(10);

            result.Left.ShouldBe(default(string));
        }

        [TestMethod]
        public void Monitor_WithLeftState_ShouldFalse()
        {
            var flag = false;

            var sut = Either.Left<string, int>("ten");

            var result = sut.Monitor((int left) => { flag = true; });

            flag.ShouldBeFalse();

            result.IsLeft.ShouldBeTrue();

            result.IsRight.ShouldBeFalse();

            result.Left.ShouldBe("ten");

            result.Right.ShouldBe(default(int));
        }

        [TestMethod]
        public void Bind_WithRightState_ShouldTrue()
        {
            var flag = false;

            var sut = Either.Right<string, int>(10);

            var date = DateTime.Now;

            var result = sut.Bind((int right) => { flag = true; return date; });

            flag.ShouldBeTrue();

            result.IsLeft.ShouldBeFalse();

            result.IsRight.ShouldBeTrue();

            result.Right.ShouldBe(date);

            result.Left.ShouldBe(default(string));
        }

        [TestMethod]
        public void BindMonad_WithRightState_ShouldTrue()
        {
            var flag = false;

            var sut = Either.Right<string, int>(10);

            var date = DateTime.Now;

            var result = sut.Bind((int right) => { flag = true; return Either.Right<string, DateTime>(date); });

            flag.ShouldBeTrue();

            result.IsLeft.ShouldBeFalse();

            result.IsRight.ShouldBeTrue();

            result.Right.ShouldBe(date);

            result.Left.ShouldBe(default(string));
        }

        [TestMethod]
        public void Bind_WithLeftState_ShouldFalse()
        {
            var flag = false;

            var sut = Either.Left<string, int>("ten");

            var date = DateTime.Now;

            var result = sut.Bind((int right) => { flag = true; return date; });

            flag.ShouldBeFalse();

            result.IsLeft.ShouldBeTrue();

            result.IsRight.ShouldBeFalse();

            result.Left.ShouldBe("ten");

            result.Right.ShouldBe(default(DateTime));
        }

        [TestMethod]
        public void BindMonad_WithLeftState_ShouldFalse()
        {
            var flag = false;

            var sut = Either.Left<string, int>("ten");

            var date = DateTime.Now;

            var result = sut.Bind((int right) => { flag = true; return Either.Right<string, DateTime>(date); });

            flag.ShouldBeFalse();

            result.IsLeft.ShouldBeTrue();

            result.IsRight.ShouldBeFalse();

            result.Left.ShouldBe("ten");

            result.Right.ShouldBe(default(DateTime));
        }

        [TestMethod]
        public void Monitor_WithRightState_ShouldFalse()
        {
            var flag = false;

            var sut = Either.Right<string, int>(10);

            var result = sut.Monitor((string left) => { flag = true; });

            flag.ShouldBeFalse();

            result.IsLeft.ShouldBeFalse();

            result.IsRight.ShouldBeTrue();

            result.Right.ShouldBe(10);

            result.Left.ShouldBe(default(string));
        }

        [TestMethod]
        public void Monitor_WithLeftState_ShouldTrue()
        {
            var flag = false;

            var sut = Either.Left<string, int>("ten");

            var result = sut.Monitor((string left) => { flag = true; });

            flag.ShouldBeTrue();

            result.IsLeft.ShouldBeTrue();

            result.IsRight.ShouldBeFalse();

            result.Left.ShouldBe("ten");

            result.Right.ShouldBe(default(int));
        }

        [TestMethod]
        public void Bind_WithRightState_ShouldFalse()
        {
            var flag = false;

            var sut = Either.Right<string, int>(10);

            var date = DateTime.Now;

            var result = sut.Bind((string left) => { flag = true; return date; });

            flag.ShouldBeFalse();

            result.IsLeft.ShouldBeFalse();

            result.IsRight.ShouldBeTrue();

            result.Left.ShouldBe(default(DateTime));

            result.Right.ShouldBe(10);
        }

        [TestMethod]
        public void Bind_WithLeftState_ShouldTrue()
        {
            var flag = false;

            var sut = Either.Left<string, int>("ten");

            var date = DateTime.Now;

            var result = sut.Bind((string left) => { flag = true; return date; });

            flag.ShouldBeTrue();

            result.IsLeft.ShouldBeTrue();

            result.IsRight.ShouldBeFalse();

            result.Right.ShouldBe(default(int));

            result.Left.ShouldBe(date);
        }

        [TestMethod]
        public void MonitorLeftRight_WithRightState_ShouldFalse()
        {
            var rflag = false;

            var lflag = false;

            var sut = Either.Right<string, int>(10);

            var result = sut.Monitor(left => { lflag = true; }, right => { rflag = true;});

            lflag.ShouldBeFalse();

            rflag.ShouldBeTrue();

            result.IsLeft.ShouldBeFalse();

            result.IsRight.ShouldBeTrue();

            result.Left.ShouldBe(default(string));

            result.Right.ShouldBe(10);
        }

        [TestMethod]
        public void MonitorLeftRight_WithLeftState_ShouldTrue()
        {
            var rflag = false;

            var lflag = false;

            var sut = Either.Left<string, int>("ten");

            var result = sut.Monitor(left => { lflag = true; }, right => { rflag = true; });

            lflag.ShouldBeTrue();

            rflag.ShouldBeFalse();

            result.IsLeft.ShouldBeTrue();

            result.IsRight.ShouldBeFalse();

            result.Left.ShouldBe("ten");

            result.Right.ShouldBe(default(int));
        }

        [TestMethod]
        public void Return_WithLeftState_ShouldTrue()
        {
            var rflag = false;

            var lflag = false;

            var sut = Either.Left<string, int>("ten");

            var result = sut.Match(left => { lflag = true; return "L";  }, right => { rflag = true; return "R"; });

            lflag.ShouldBeTrue();

            rflag.ShouldBeFalse();

            result.ShouldBe("L");
        }

        [TestMethod]
        public void Return_WithRightState_ShouldTrue()
        {
            var rflag = false;

            var lflag = false;

            var sut = Either.Right<string, int>(10);

            var result = sut.Match(left => { lflag = true; return "L"; }, right => { rflag = true; return "R"; });

            lflag.ShouldBeFalse();

            rflag.ShouldBeTrue();

            result.ShouldBe("R");
        }


        [TestMethod]
        public void MatchBoth_WithRightState_ShouldTrue()
        {
            var flag = false;

            var sut = Either.Right<string, int>(10);

            var result = sut.Monitor(() => { flag = true; });

            flag.ShouldBeTrue();

            result.IsLeft.ShouldBeFalse();

            result.IsRight.ShouldBeTrue();

            result.Left.ShouldBe(default(string));

            result.Right.ShouldBe(10);
        }

        [TestMethod]
        public void MatchBoth_WithLefttState_ShouldTrue()
        {
            var flag = false;

            var sut = Either.Left<string, int>("ten");

            var result = sut.Monitor(() => { flag = true; });

            flag.ShouldBeTrue();

            result.IsLeft.ShouldBeTrue();

            result.IsRight.ShouldBeFalse();

            result.Left.ShouldBe("ten");

            result.Right.ShouldBe(default(int));
        }
    }
}