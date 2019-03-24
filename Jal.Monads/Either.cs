namespace Jal.Monads
{
    public static class Either
    {
        public static Either<L, R> Left<L, R>(L left)
        {
            return Either<L, R>.Return(left);
        }

        public static Either<L, R> Right<L, R>(R right)
        {
            return Either<L, R>.Return(right);
        }
    }
    public class Either<L, R>
    {
        public R Right { get; }

        public L Left { get; }

        public bool IsRight { get; set; }

        public bool IsLeft => !IsRight;

        private Either(L left)
        {
            IsRight = false;
            Left = left;
            Right = default(R);
        }

        private Either(R right)
        {
            IsRight = true;
            Left = default(L);
            Right = right;
        }


        public static implicit operator Either<L, R>(R right)
        {
            return new Either<L, R>(right);
        }

        public static implicit operator Either<L, R>(L left)
        {
            return new Either<L, R>(left);
        }

        public static explicit operator L(Either<L, R> either)
        {
            return either.Left;
        }

        public static explicit operator R(Either<L, R> either)
        {
            return either.Right;
        }

        public static Either<L, R> Return(L left)
        {
            return new Either<L, R>(left);
        }

        public static Either<L, R> Return(R right)
        {
            return new Either<L, R>(right);
        }
    }
}
