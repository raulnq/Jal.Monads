using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using Jal.Monads;

namespace Jal.Monads.Test
{
    [TestClass]
    public class EitherTests
    {
        [TestMethod]
        public void Monitor_WithRightState_ShouldTrue()
        {
            var flag = false;
            
            var sut = 10.AsRight<string, int>();

            var either = sut.Monitor(onright: (int right) => { flag = true; });

            flag.ShouldBeTrue();

            either.IsLeft.ShouldBeFalse();

            either.IsRight.ShouldBeTrue();

            either.Right.ShouldBe(10);

            either.Left.ShouldBe(default(string));
        }

        [TestMethod]
        public void Monitor_WithLeftState_ShouldFalse()
        {
            var flag = false;

            var sut = "ten".AsLeft<string, int>();

            var result = sut.Monitor(onright:(int right) => { flag = true; });

            flag.ShouldBeFalse();

            result.IsLeft.ShouldBeTrue();

            result.IsRight.ShouldBeFalse();

            result.Left.ShouldBe("ten");

            result.Right.ShouldBe(default(int));
        }

        [TestMethod]
        public void Map_WithRightState_ShouldTrue()
        {
            var flag = false;

            var sut = 10.AsRight<string, int>();

            var date = DateTime.Now;

            var result = sut.Map((int right) => { flag = true; return date; });

            flag.ShouldBeTrue();

            result.IsLeft.ShouldBeFalse();

            result.IsRight.ShouldBeTrue();

            result.Right.ShouldBe(date);

            result.Left.ShouldBe(default(string));
        }

        [TestMethod]
        public void Bind_WithRightState_ShouldTrue()
        {
            var flag = false;

            var sut = 10.AsRight<string, int>();

            var date = DateTime.Now;

            var result = sut.Bind((int right) => { flag = true; return date.AsRight<string, DateTime>(); });

            flag.ShouldBeTrue();

            result.IsLeft.ShouldBeFalse();

            result.IsRight.ShouldBeTrue();

            result.Right.ShouldBe(date);

            result.Left.ShouldBe(default(string));
        }

        [TestMethod]
        public void Map_WithLeftState_ShouldFalse()
        {
            var flag = false;

            var sut = "ten".AsLeft<string, int>();

            var date = DateTime.Now;

            var result = sut.Map((int right) => { flag = true; return date; });

            flag.ShouldBeFalse();

            result.IsLeft.ShouldBeTrue();

            result.IsRight.ShouldBeFalse();

            result.Left.ShouldBe("ten");

            result.Right.ShouldBe(default(DateTime));
        }

        [TestMethod]
        public void Bind_WithLeftState_ShouldFalse()
        {
            var flag = false;

            var sut = "ten".AsLeft<string, int>();

            var date = DateTime.Now;

            var result = sut.Bind((int right) => { flag = true; return date.AsRight<string, DateTime>(); });

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

            var sut = 10.AsRight<string, int>();

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

            var sut = "ten".AsLeft<string, int>();

            var result = sut.Monitor((string left) => { flag = true; });

            flag.ShouldBeTrue();

            result.IsLeft.ShouldBeTrue();

            result.IsRight.ShouldBeFalse();

            result.Left.ShouldBe("ten");

            result.Right.ShouldBe(default(int));
        }

        [TestMethod]
        public void Map_WithRightState_ShouldFalse()
        {
            var flag = false;

            var sut = 10.AsRight<string, int>();

            var date = DateTime.Now;

            var result = sut.Map((string left) => { flag = true; return date; });

            flag.ShouldBeFalse();

            result.IsLeft.ShouldBeFalse();

            result.IsRight.ShouldBeTrue();

            result.Left.ShouldBe(default(DateTime));

            result.Right.ShouldBe(10);
        }

        [TestMethod]
        public void Map_WithLeftState_ShouldTrue()
        {
            var flag = false;

            var sut = "ten".AsLeft<string, int>();

            var date = DateTime.Now;

            var result = sut.Map((string left) => { flag = true; return date; });

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

            var sut = 10.AsRight<string, int>();

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

            var sut = "ten".AsLeft<string, int>();

            var result = sut.Monitor(left => { lflag = true; }, right => { rflag = true; });

            lflag.ShouldBeTrue();

            rflag.ShouldBeFalse();

            result.IsLeft.ShouldBeTrue();

            result.IsRight.ShouldBeFalse();

            result.Left.ShouldBe("ten");

            result.Right.ShouldBe(default(int));
        }

        [TestMethod]
        public void Match_WithLeftState_ShouldTrue()
        {
            var rflag = false;

            var lflag = false;

            var sut = "ten".AsLeft<string, int>();

            var result = sut.Match(left => { lflag = true; return "L";  }, right => { rflag = true; return "R"; });

            lflag.ShouldBeTrue();

            rflag.ShouldBeFalse();

            result.ShouldBe("L");
        }

        [TestMethod]
        public void Match_WithRightState_ShouldTrue()
        {
            var rflag = false;

            var lflag = false;

            var sut = 10.AsRight<string, int>();

            var result = sut.Match(left => { lflag = true; return "L"; }, right => { rflag = true; return "R"; });

            lflag.ShouldBeFalse();

            rflag.ShouldBeTrue();

            result.ShouldBe("R");
        }


        [TestMethod]
        public void MonitorBoth_WithRightState_ShouldTrue()
        {
            var flag = false;

            var sut = 10.AsRight<string, int>();

            var result = sut.Monitor(() => { flag = true; });

            flag.ShouldBeTrue();

            result.IsLeft.ShouldBeFalse();

            result.IsRight.ShouldBeTrue();

            result.Left.ShouldBe(default(string));

            result.Right.ShouldBe(10);
        }

        [TestMethod]
        public void Monitor_WithLefttState_ShouldTrue()
        {
            var flag = false;

            var sut = "ten".AsLeft<string, int>();

            var result = sut.Monitor(() => { flag = true; });

            flag.ShouldBeTrue();

            result.IsLeft.ShouldBeTrue();

            result.IsRight.ShouldBeFalse();

            result.Left.ShouldBe("ten");

            result.Right.ShouldBe(default(int));
        }
    }
}