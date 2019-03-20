using System;

namespace Jal.Monads
{
    public class Maybe<T>
    {
        public T Value { get; }

        public bool HasValue { get; }

        private Maybe(T value)
        {

            Value = value;
            HasValue = true;
        }

        private Maybe()
        {
            HasValue = false;
        }

        public static Maybe<T> Return(T value)
        {
            return value != null ? new Maybe<T>(value) : Maybe<T>.None;
        }

        public static Maybe<T> Some(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            return new Maybe<T>(value);
        }

        public static Maybe<T> None => new Maybe<T>();

        public static implicit operator Maybe<T>(T value)
        {
            return Maybe<T>.Return(value);
        }

        public static explicit operator T(Maybe<T> maybe)
        {
            return maybe.Value;
        }
    }
}
