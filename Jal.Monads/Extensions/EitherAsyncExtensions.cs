using System;
using System.Threading.Tasks;

namespace Jal.Monads.Extensions
{
    public static class EitherAsyncExtensions
    {
        public static async Task<Either<L, R>> MonitorAsync<L, R>(this Task<Either<L, R>> either, Action<R> onright)
        {
            if (onright == null)
            {
                throw new ArgumentNullException(nameof(onright));
            }

            var e = await either;

            if (e.IsRight)
            {
                onright(e.Right);
            }

            return e;
        }

        public static async Task<Either<L, R>> MonitorAsync<L, R>(this Task<Either<L, R>> either, Func<R, Task> onright)
        {
            if (onright == null)
            {
                throw new ArgumentNullException(nameof(onright));
            }

            var e = await either;

            if (e.IsRight)
            {
                await onright(e.Right);
            }

            return e;
        }

        public static async Task<Either<L, T>> MapAsync<L, R, T>(this Task<Either<L, R>> either, Func<R, T> onright)
        {
            if (onright == null)
            {
                throw new ArgumentNullException(nameof(onright));
            }

            var e = await either;

            if (e.IsRight)
            {
                var t = onright(e.Right);

                return Either<L, T>.Return(t);
            }

            return Either<L, T>.Return(e.Left);
        }

        public static async Task<Either<L, T>> BindAsync<L, R, T>(this Task<Either<L, R>> either, Func<R, Either<L, T>> onright)
        {
            if (onright == null)
            {
                throw new ArgumentNullException(nameof(onright));
            }

            var e = await either;

            if (e.IsRight)
            {
                return onright(e.Right);
            }

            return Either<L, T>.Return(e.Left);
        }

        public static async Task<Either<L, T>> BindAsync<L, R, T>(this Task<Either<L, R>> either, Func<R, Task<Either<L, T>>> onright)
        {
            if (onright == null)
            {
                throw new ArgumentNullException(nameof(onright));
            }

            var e = await either;

            if (e.IsRight)
            {
                return await onright(e.Right);
            }

            return Either<L, T>.Return(e.Left);
        }

        public static async Task<Either<L, T>> MapAsync<L, R, T>(this Task<Either<L, R>> either, Func<R, Task<T>> onright)
        {
            if (onright == null)
            {
                throw new ArgumentNullException(nameof(onright));
            }

            var e = await either;

            if (e.IsRight)
            {
                var t = await onright(e.Right);

                return Either<L, T>.Return(t);
            }

            return Either<L, T>.Return(e.Left);
        }

        public static async Task<Either<L, R>> MonitorAsync<L, R>(this Task<Either<L, R>> either, Action<L> onleft)
        {
            if (onleft == null)
            {
                throw new ArgumentNullException(nameof(onleft));
            }

            var e = await either;

            if (e.IsLeft)
            {
                onleft(e.Left);
            }

            return e;
        }

        public static async Task<Either<L, R>> MonitorAsync<L, R>(this Task<Either<L, R>> either, Func<L, Task> onleft)
        {
            if (onleft == null)
            {
                throw new ArgumentNullException(nameof(onleft));
            }

            var e = await either;

            if (e.IsLeft)
            {
                await onleft(e.Left);
            }

            return e;
        }

        public static async Task<Either<T, R>> MapAsync<L, R, T>(this Task<Either<L, R>> either, Func<L, T> onleft)
        {
            if (onleft == null)
            {
                throw new ArgumentNullException(nameof(onleft));
            }

            var e = await either;

            if (e.IsLeft)
            {
                var t = onleft(e.Left);

                return Either<T, R>.Return(t);
            }

            return Either<T, R>.Return(e.Right);
        }

        public static async Task<Either<T, R>> BindAsync<L, R, T>(this Task<Either<L, R>> either, Func<L, Either<T, R>> onleft)
        {
            if (onleft == null)
            {
                throw new ArgumentNullException(nameof(onleft));
            }

            var e = await either;

            if (e.IsLeft)
            {
                return onleft(e.Left);
            }

            return Either<T, R>.Return(e.Right);
        }

        public static async Task<Either<T, R>> MapAsync<L, R, T>(this Task<Either<L, R>> either, Func<L, Task<T>> onleft)
        {
            if (onleft == null)
            {
                throw new ArgumentNullException(nameof(onleft));
            }

            var e = await either;

            if (e.IsLeft)
            {
                var t = await onleft(e.Left);

                return Either<T, R>.Return(t);
            }

            return Either<T, R>.Return(e.Right);
        }

        public static async Task<Either<T, R>> BindAsync<L, R, T>(this Task<Either<L, R>> either, Func<L, Task<Either<T, R>>> onleft)
        {
            if (onleft == null)
            {
                throw new ArgumentNullException(nameof(onleft));
            }

            var e = await either;

            if (e.IsLeft)
            {
                return await onleft(e.Left);
            }

            return Either<T, R>.Return(e.Right);
        }

        public async static Task<Either<L, R>> MonitorAsync<L, R>(this Task<Either<L, R>> either, Action<L> onleft, Action<R> onright)
        {
            if (onleft == null)
            {
                throw new ArgumentNullException(nameof(onleft));
            }
            if (onright == null)
            {
                throw new ArgumentNullException(nameof(onright));
            }

            var e = await either;

            if (e.IsRight)
            {
                onright(e.Right);
            }

            if (e.IsLeft)
            {
                onleft(e.Left);
            }

            return e;
        }

        public async static Task<Either<L, R>> MonitorAsync<L, R>(this Task<Either<L, R>> either, Func<L, Task> onleft, Func<R, Task> onright)
        {
            if (onleft == null)
            {
                throw new ArgumentNullException(nameof(onleft));
            }
            if (onright == null)
            {
                throw new ArgumentNullException(nameof(onright));
            }

            var e = await either;

            if (e.IsRight)
            {
                await onright(e.Right);
            }

            if (e.IsLeft)
            {
                await onleft(e.Left);
            }

            return e;
        }

        public async static Task<Either<L, R>> MonitorAsync<L, R>(this Task<Either<L, R>> either, Action onboth)
        {
            if (onboth == null)
            {
                throw new ArgumentNullException(nameof(onboth));
            }

            var e = await either;

            onboth();

            return e;
        }

        public async static Task<Either<L, R>> MonitorAsync<L, R>(this Task<Either<L, R>> either, Func<Task> onboth)
        {
            if (onboth == null)
            {
                throw new ArgumentNullException(nameof(onboth));
            }

            var e = await either;

            await onboth();

            return e;
        }

        public async static Task<T> MatchAsync<L, R, T>(this Task<Either<L, R>> either, Func<L, T> onleft, Func<R, T> onright)
        {
            if (onright == null)
            {
                throw new ArgumentNullException(nameof(onright));
            }
            if (onleft == null)
            {
                throw new ArgumentNullException(nameof(onleft));
            }

            var e = await either;

            if (e.IsLeft)
            {
                return onleft(e.Left);
            }
            else
            {
                return onright(e.Right);
            }
        }

        public async static Task<T> MatchAsync<L, R, T>(this Task<Either<L, R>> either, Func<L, Task<T>> onleft, Func<R, Task<T>> onright)
        {
            if (onright == null)
            {
                throw new ArgumentNullException(nameof(onright));
            }
            if (onleft == null)
            {
                throw new ArgumentNullException(nameof(onleft));
            }

            var e = await either;

            if (e.IsLeft)
            {
                return await onleft(e.Left);
            }
            else
            {
                return await onright(e.Right);
            }
        }
    }
}
