using System;
using System.Threading.Tasks;

namespace Jal.Monads.Extensions
{
    public static class EitherExtensions
    {
        public static Either<L, R> ToRight<L, R>(this R right)
        {
            return right;
        }

        public static Either<L, R> ToLeft<L, R>(this L left)
        {
            return left;
        }

        public static T Match<L, R, T>(this Either<L, R> either, Func<L, T> onleft, Func<R, T> onright)
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

        public static Either<L, R> Monitor<L,R>(this Either<L,R> either, Action<R> onright)
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

        public static Either<L, T> Map<L, R, T>(this Either<L, R> either, Func<R, T> onright)
        {
            if (onright == null)
            {
                throw new ArgumentNullException(nameof(onright));
            }

            if (either.IsRight)
            {
                return onright(either.Right);
            }

            return either.Left;
        }

        public static Either<L, T> Bind<L, R, T>(this Either<L, R> either, Func<R, Either<L, T>> onright)
        {
            if (onright == null)
            {
                throw new ArgumentNullException(nameof(onright));
            }

            if (either.IsRight)
            {
                return onright(either.Right);
            }

            return either.Left;
        }

        public static Either<L, R> Monitor<L, R>(this Either<L, R> either, Action<L> onleft)
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

        public static Either<T, R> Map<L, R, T>(this Either<L, R> either, Func<L, T> onleft)
        {
            if (onleft == null)
            {
                throw new ArgumentNullException(nameof(onleft));
            }

            if (either.IsLeft)
            {
                return onleft(either.Left);
            }

            return either.Right;
        }

        public static Either<T, R> Bind<L, R, T>(this Either<L, R> either, Func<L, Either<T, R>> onleft)
        {
            if (onleft == null)
            {
                throw new ArgumentNullException(nameof(onleft));
            }

            if (either.IsLeft)
            {
                return onleft(either.Left);
            }

            return either.Right;
        }

        public static Either<L, R> Monitor<L, R>(this Either<L, R> either, Action<L> onleft, Action<R> onright)
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

        public static Either<L, R> Monitor<L, R>(this Either<L, R> either, Action onboth)
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
