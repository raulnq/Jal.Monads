using System;

namespace Jal.Monads
{
    public static class Maybe
    {
        public static Maybe<T> Some<T>(T value)
        {
            return Maybe<T>.Return(value);
        }

        public static Maybe<T> None<T>()
        {
            return Maybe<T>.None;
        }
    }
    public class Maybe<T>
    {
        public T Value { get; }

        public bool HasValue { get; }

        private Maybe(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            Value = value;
            HasValue = true;
        }

        private Maybe()
        {
            HasValue = false;
            Value = default(T);
        }

        public static Maybe<T> Return(T value)
        {
            return new Maybe<T>(value);
        }

        public static Maybe<T> None => new Maybe<T>();

        public static implicit operator Maybe<T>(T value)
        {
            return Return(value);
        }

        public static implicit operator T(Maybe<T> maybe)
        {
            return maybe.Value;
        }
    }
}
