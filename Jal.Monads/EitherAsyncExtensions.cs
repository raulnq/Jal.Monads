﻿using System;
using System.Threading.Tasks;

namespace Jal.Monads
{
    public static class EitherAsyncExtensions
    {
        public static async Task<Either<L, R>> MatchRightAsync<L, R>(this Task<Either<L, R>> either, Action<R> onright)
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

        public static async Task<Either<L, R>> MatchRightAsync<L, R>(this Task<Either<L, R>> either, Func<R, Task> onright)
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

        public static async Task<Either<L, T>> MatchRightAsync<L, R, T>(this Task<Either<L, R>> either, Func<R, T> onright)
        {
            if (onright == null)
            {
                throw new ArgumentNullException(nameof(onright));
            }

            var e = await either;

            if (e.IsRight)
            {
                var t = onright(e.Right);

                return new Either<L, T>(t);
            }

            return new Either<L, T>(e.Left);
        }

        public static async Task<Either<L, T>> MatchRightAsync<L, R, T>(this Task<Either<L, R>> either, Func<R, Task<T>> onright)
        {
            if (onright == null)
            {
                throw new ArgumentNullException(nameof(onright));
            }

            var e = await either;

            if (e.IsRight)
            {
                var t = await onright(e.Right);

                return new Either<L, T>(t);
            }

            return new Either<L, T>(e.Left);
        }

        public static async Task<Either<L, R>> MatchLeftAsync<L, R>(this Task<Either<L, R>> either, Action<L> onleft)
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

        public static async Task<Either<L, R>> MatchLeftAsync<L, R>(this Task<Either<L, R>> either, Func<L, Task> onleft)
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

        public static async Task<Either<T, R>> MatchLeftAsync<L, R, T>(this Task<Either<L, R>> either, Func<L, T> onleft)
        {
            if (onleft == null)
            {
                throw new ArgumentNullException(nameof(onleft));
            }

            var e = await either;

            if (e.IsLeft)
            {
                var t = onleft(e.Left);

                return new Either<T, R>(t);
            }

            return new Either<T, R>(e.Right);
        }

        public static async Task<Either<T, R>> MatchLeftAsync<L, R, T>(this Task<Either<L, R>> either, Func<L, Task<T>> onleft)
        {
            if (onleft == null)
            {
                throw new ArgumentNullException(nameof(onleft));
            }

            var e = await either;

            if (e.IsLeft)
            {
                var t = await onleft(e.Left);

                return new Either<T, R>(t);
            }

            return new Either<T, R>(e.Right);
        }

        public async static Task<Either<L, R>> MatchAsync<L, R>(this Task<Either<L, R>> either, Action<L> onleft, Action<R> onright)
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

        public async static Task<Either<L, R>> MatchAsync<L, R>(this Task<Either<L, R>> either, Func<L, Task> onleft, Func<R, Task> onright)
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

        public async static Task<Either<L, R>> MatchAsync<L, R>(this Task<Either<L, R>> either, Action onboth)
        {
            if (onboth == null)
            {
                throw new ArgumentNullException(nameof(onboth));
            }

            var e = await either;

            onboth();

            return e;
        }

        public async static Task<Either<L, R>> MatchAsync<L, R>(this Task<Either<L, R>> either, Func<Task> onboth)
        {
            if (onboth == null)
            {
                throw new ArgumentNullException(nameof(onboth));
            }

            var e = await either;

            await onboth();

            return e;
        }

        public async static Task<T> ReturnAsync<L, R, T>(this Task<Either<L, R>> either, Func<L, T> onleft, Func<R, T> onright)
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

        public async static Task<T> ReturnAsync<L, R, T>(this Task<Either<L, R>> either, Func<L, Task<T>> onleft, Func<R, Task<T>> onright)
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
