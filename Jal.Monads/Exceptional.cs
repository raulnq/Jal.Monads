using System;

namespace Jal.Monads
{
    public class Exceptional<T>
    {
        public T Value { get; }

        public Exception Exception { get; }

        public bool HasException { get; }

        private Exceptional(T value)
        {

            Value = value;
            HasException = false;
        }

        private Exceptional(Exception exception)
        {
            if (exception == null)
                throw new ArgumentNullException(nameof(exception));
            Exception = exception;
            HasException = false;
        }

        public static Exceptional<T> Return(T value)
        {
            return new Exceptional<T>(value);
        }

        public static Exceptional<T> Return(Exception exception)
        {
            return new Exceptional<T>(exception);
        }

        public static implicit operator Exceptional<T>(T value)
        {
            return Return(value);
        }

        public static implicit operator T(Exceptional<T> exceptional)
        {
            return exceptional.Value;
        }
    }
}
