﻿using System;

namespace Jal.Monads
{
    public static class EitherExtensions
    {
        public static Either<L, R> AsRight<L, R>(this R right)
        {
            return right;
        }

        public static Either<L, R> AsLeft<L, R>(this L left)
        {
            return left;
        }

        public static Either<L, R> Monitor<L, R>(this Either<L, R> either, Action<L> onleft=null, Action<R> onright=null)
        {
            if (either.IsRight)
            {
                onright?.Invoke(either.Right);
            }

            if (either.IsLeft)
            {
                onleft?.Invoke(either.Left);
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
