﻿using System;

namespace Jal.Monads
{
    public static class EitherCoreExtensions
    {
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
    }
}
