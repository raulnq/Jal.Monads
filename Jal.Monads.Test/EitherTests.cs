using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace Jal.Monads.Test
{
    [TestClass]
    public class EitherTests
    {
        [TestMethod]
        public void MatchRightWithAction_WithRightState_ShouldTrue()
        {
            var flag = false;

            var sut = Either.Right<string, int>(10);

            var result = sut.MatchRight(right => { flag = true; });

            flag.ShouldBeTrue();

            result.IsLeft.ShouldBeFalse();

            result.IsRight.ShouldBeTrue();

            result.Right.ShouldBe(10);

            result.Left.ShouldBe(default(string));
        }

        [TestMethod]
        public void MatchRightWithAction_WithLeftState_ShouldFalse()
        {
            var flag = false;

            var sut = Either.Left<string, int>("ten");

            var result = sut.MatchRight(left => { flag = true; });

            flag.ShouldBeFalse();

            result.IsLeft.ShouldBeTrue();

            result.IsRight.ShouldBeFalse();

            result.Left.ShouldBe("ten");

            result.Right.ShouldBe(default(int));
        }

        [TestMethod]
        public void MatchRightWithFunc_WithRightState_ShouldTrue()
        {
            var flag = false;

            var sut = Either.Right<string, int>(10);

            var date = DateTime.Now;

            var result = sut.MatchRight(right => { flag = true; return date; });

            flag.ShouldBeTrue();

            result.IsLeft.ShouldBeFalse();

            result.IsRight.ShouldBeTrue();

            result.Right.ShouldBe(date);

            result.Left.ShouldBe(default(string));
        }

        [TestMethod]
        public void MatchRightWithFunction_WithLeftState_ShouldFalse()
        {
            var flag = false;

            var sut = Either.Left<string, int>("ten");

            var date = DateTime.Now;

            var result = sut.MatchRight(left => { flag = true; return date; });

            flag.ShouldBeFalse();

            result.IsLeft.ShouldBeTrue();

            result.IsRight.ShouldBeFalse();

            result.Left.ShouldBe("ten");

            result.Right.ShouldBe(default(DateTime));
        }

        [TestMethod]
        public void MatchLefttWithAction_WithRightState_ShouldFalse()
        {
            var flag = false;

            var sut = Either.Right<string, int>(10);

            var result = sut.MatchLeft(right => { flag = true; });

            flag.ShouldBeFalse();

            result.IsLeft.ShouldBeFalse();

            result.IsRight.ShouldBeTrue();

            result.Right.ShouldBe(10);

            result.Left.ShouldBe(default(string));
        }

        [TestMethod]
        public void MatchLeftWithAction_WithLeftState_ShouldTrue()
        {
            var flag = false;

            var sut = Either.Left<string, int>("ten");

            var result = sut.MatchLeft(left => { flag = true; });

            flag.ShouldBeTrue();

            result.IsLeft.ShouldBeTrue();

            result.IsRight.ShouldBeFalse();

            result.Left.ShouldBe("ten");

            result.Right.ShouldBe(default(int));
        }

        [TestMethod]
        public void MatchLeftWithFunc_WithRightState_ShouldFalse()
        {
            var flag = false;

            var sut = Either.Right<string, int>(10);

            var date = DateTime.Now;

            var result = sut.MatchLeft(right => { flag = true; return date; });

            flag.ShouldBeFalse();

            result.IsLeft.ShouldBeFalse();

            result.IsRight.ShouldBeTrue();

            result.Left.ShouldBe(default(DateTime));

            result.Right.ShouldBe(10);
        }

        [TestMethod]
        public void MatchLeftWithFunction_WithLeftState_ShouldTrue()
        {
            var flag = false;

            var sut = Either.Left<string, int>("ten");

            var date = DateTime.Now;

            var result = sut.MatchLeft(left => { flag = true; return date; });

            flag.ShouldBeTrue();

            result.IsLeft.ShouldBeTrue();

            result.IsRight.ShouldBeFalse();

            result.Right.ShouldBe(default(int));

            result.Left.ShouldBe(date);
        }

        [TestMethod]
        public void MatchWithAction_WithRightState_ShouldFalse()
        {
            var rflag = false;

            var lflag = false;

            var sut = Either.Right<string, int>(10);

            var result = sut.Match(left => { lflag = true; }, right => { rflag = true;});

            lflag.ShouldBeFalse();

            rflag.ShouldBeTrue();

            result.IsLeft.ShouldBeFalse();

            result.IsRight.ShouldBeTrue();

            result.Left.ShouldBe(default(string));

            result.Right.ShouldBe(10);
        }

        [TestMethod]
        public void MatchWithAction_WithLeftState_ShouldTrue()
        {
            var rflag = false;

            var lflag = false;

            var sut = Either.Left<string, int>("ten");

            var result = sut.Match(left => { lflag = true; }, right => { rflag = true; });

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

            var result = sut.Return(left => { lflag = true; return "L";  }, right => { rflag = true; return "R"; });

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

            var result = sut.Return(left => { lflag = true; return "L"; }, right => { rflag = true; return "R"; });

            lflag.ShouldBeFalse();

            rflag.ShouldBeTrue();

            result.ShouldBe("R");
        }


        [TestMethod]
        public void Match_WithRightState_ShouldTrue()
        {
            var flag = false;

            var sut = Either.Right<string, int>(10);

            var result = sut.Match(() => { flag = true; });

            flag.ShouldBeTrue();

            result.IsLeft.ShouldBeFalse();

            result.IsRight.ShouldBeTrue();

            result.Left.ShouldBe(default(string));

            result.Right.ShouldBe(10);
        }

        [TestMethod]
        public void Match_WithLefttState_ShouldTrue()
        {
            var flag = false;

            var sut = Either.Left<string, int>("ten");

            var result = sut.Match(() => { flag = true; });

            flag.ShouldBeTrue();

            result.IsLeft.ShouldBeTrue();

            result.IsRight.ShouldBeFalse();

            result.Left.ShouldBe("ten");

            result.Right.ShouldBe(default(int));
        }
    }
}