namespace Jal.Monads
{

    public class Result<T,E> : Result<E>
    {
        public T Content { get; }

        private Result(T content) : base()
        {
            Content = content;
        }

        private Result(E error) : base(error)
        {
            Content = default(T);
        }

        public static implicit operator Result<T, E>(T content)
        {
            return new Result<T, E>(content);
        }

        public static implicit operator Result<T, E>(E error)
        {
            return new Result<T, E>(error);
        }

        public static explicit operator T(Result<T, E> result)
        {
            return result.Content;
        }

        public static explicit operator E(Result<T, E> result)
        {
            return result.Error;
        }

        public static Result<T, E> Return(T content)
        {
            return new Result<T, E>(content);
        }

        public new static Result<T, E> Return(E error)
        {
            return new Result<T, E>(error);
        }
    }

    public static class Result
    {
        public static Result<E> Failure<E>(E error)
        {
            return Result<E>.Return(error);
        }

        public static Result<E> Success<E>()
        {
            return Result<E>.Return();
        }

        public static Result<T, E> Success<T, E>(T content)
        {
            return Result<T, E>.Return(content);
        }

        public static Result<T, E> Failure<T, E>(E error)
        {
            return Result<T,E>.Return(error);
        }
    }

    public class Result<E>
    {
        public E Error { get; }

        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;

        protected Result()
        {
            IsSuccess = true;
            Error = default(E);
        }

        protected Result(E error)
        {
            IsSuccess = false;
            Error = error;
        }

        public static implicit operator Result<E>(E error)
        {
            return new Result<E>(error);
        }

        public static explicit operator E(Result<E> result)
        {
            return result.Error;
        }

        public static Result<E> Return(E error)
        {
            return new Result<E>(error);
        }

        public static Result<E> Return()
        {
            return new Result<E>();
        }
    }
}
