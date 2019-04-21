namespace Jal.Monads
{
    public static class Either
    {
        public static Either<L, R> Left<L, R>(L left)
        {
            return left;
        }

        public static Either<L, R> Right<L, R>(R right)
        {
            return right;
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
            Right = default;
        }

        private Either(R right)
        {
            IsRight = true;
            Left = default;
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

        public static implicit operator L(Either<L, R> either)
        {
            return either.Left;
        }

        public static implicit operator R(Either<L, R> either)
        {
            return either.Right;
        }

        public static Either<L, R> Return(L left)
        {
            return left;
        }

        public static Either<L, R> Return(R right)
        {
            return right;
        }
    }
}
