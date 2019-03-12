using System;
using System.Threading.Tasks;

namespace Jal.Monads
{
    public static class EitherExtensions
    {
        public static Either<L, R> ToRight<L, R>(this R right)
        {
            return Either.Right<L, R>(right);
        }

        public static Either<L, R> ToLeft<L, R>(this L left)
        {
            return Either.Left<L, R>(left);
        }

        public static T Return<L, R, T>(this Either<L, R> either, Func<L, T> onleft, Func<R, T> onright)
        {
            if (onright == null)
            {
                throw new ArgumentNullException(nameof(onright));
            }
            if (onleft == null)
            {
                throw new ArgumentNullException(nameof(onleft));
            }

            if (either.IsLeft)
            {
                return onleft(either.Left);
            }
            else
            {
                return onright(either.Right);
            }
        }

        public static Either<L, R> MatchRight<L,R>(this Either<L,R> either, Action<R> onright)
        {
            if (onright == null)
            {
                throw new ArgumentNullException(nameof(onright));
            }

            if (either.IsRight)
            {
                onright(either.Right);
            }

            return either;
        }

        public static Either<L, T> MatchRight<L, R, T>(this Either<L, R> either, Func<R, T> onright)
        {
            if (onright == null)
            {
                throw new ArgumentNullException(nameof(onright));
            }

            if (either.IsRight)
            {
                var t = onright(either.Right);

                return new Either<L, T>(t);
            }

            return new Either<L, T>(either.Left);
        }

        public static Either<L, R> MatchLeft<L, R>(this Either<L, R> either, Action<L> onleft)
        {
            if (onleft == null)
            {
                throw new ArgumentNullException(nameof(onleft));
            }

            if (either.IsLeft)
            {
                onleft(either.Left);
            }

            return either;
        }

        public static Either<T, R> MatchLeft<L, R, T>(this Either<L, R> either, Func<L, T> onleft)
        {
            if (onleft == null)
            {
                throw new ArgumentNullException(nameof(onleft));
            }

            if (either.IsLeft)
            {
                var t = onleft(either.Left);

                return new Either<T, R>(t);
            }

            return new Either<T, R>(either.Right);
        }

        public static Either<L, R> Match<L, R>(this Either<L, R> either, Action<L> onleft, Action<R> onright)
        {
            if (onleft == null)
            {
                throw new ArgumentNullException(nameof(onleft));
            }
            if (onright == null)
            {
                throw new ArgumentNullException(nameof(onright));
            }

            if (either.IsRight)
            {
                onright(either.Right);
            }

            if (either.IsLeft)
            {
                onleft(either.Left);
            }

            return either;
        }

        public static Either<L, R> Match<L, R>(this Either<L, R> either, Action onboth)
        {
            if (onboth == null)
            {
                throw new ArgumentNullException(nameof(onboth));
            }

            onboth();

            return either;
        }
    }
}
