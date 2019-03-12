namespace Jal.Monads
{
    public class Either
    {
        public static Either<L, R> Left<L, R>(L left)
        {
            return new Either<L, R>(left);
        }

        public static Either<L, R> Right<L, R>(R right)
        {
            return new Either<L, R>(right);
        }
    }

    public class Either<L, R>
    {
        public R Right { get; }

        public L Left { get; }

        public bool IsRight { get; set; }

        public bool IsLeft => !IsRight;

        public Either(L left)
        {
            IsRight = false;
            Left = left;
            Right = default(R);
        }

        public Either(R right)
        {
            IsRight = true;
            Left = default(L);
            Right = right;
        }
    }
}
