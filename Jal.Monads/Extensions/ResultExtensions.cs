using System;

namespace Jal.Monads.Extensions
{
    public static class ResultExtensions
    {

        public static Result<T, E> ToSuccess<T, E>(this T content)
        {
            return content;
        }

        public static Result<T, E> ToFailure<T, E>(this E error)
        {
            return error;
        }

        public static Result<E> ToFailure<E>(this E error)
        {
            return error;
        }

        public static Result<T, E> Monitor<T, E>(this Result<T, E> result, Action<T> onsuccess = null, Action<E> onfailure = null)
        {
            if (result.IsSuccess)
            {
                onsuccess?.Invoke(result.Content);
            }
            else
            {
                onfailure?.Invoke(result.Error);
            }

            return result;
        }

        public static Result<E> Monitor<E>(this Result<E> result, Action onsuccess = null, Action<E> onfailure = null)
        {
            if (result.IsSuccess)
            {
                onsuccess?.Invoke();
            }
            else
            {
                onfailure?.Invoke(result.Error);
            }

            return result;
        }

        public static Result<E> Bind<T, E>(this Result<T, E> result, Func<T, Result<E>> onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (result.IsSuccess)
            {
                return onsuccess(result.Content);
            }

            return result.Error;
        }

        public static Result<O, E> Bind<E, O>(this Result<E> result, Func<Result<O, E>> onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (result.IsSuccess)
            {
                return onsuccess();
            }

            return result.Error;
        }

        public static O Return<E, O>(this Result<E> result, Func<O> onsuccess, Func<E, O> onfailure)
        {
            return ResultCoreExtensions.Match(result, onsuccess, onfailure);
        }

        public static Result<E> OnSuccess<E>(this Result<E> result, Action action)
        {
            return Monitor(result, onsuccess: action);
        }

        public static Result<E> OnFailure<E>(this Result<E> result, Action<E> action)
        {
            return Monitor(result, onfailure: action);
        }

        public static Result<E> OnBoth<E>(this Result<E> result, Action onsuccess, Action<E> onfailure)
        {
            return Monitor(result, onsuccess, onfailure);
        }

        public static Result<E> OnSuccess<E>(this Result<E> result, Func<Result<E>> onsuccess)
        {
            return ResultCoreExtensions.Bind(result, onsuccess);
        }

        public static Result<O, E> OnSuccess<E, O>(this Result<E> result, Func<Result<O, E>> onsuccess)
        {
            return Bind(result, onsuccess);
        }

        public static O Return<T, E, O>(this Result<T, E> result, Func<T, O> onsuccess, Func<E, O> onfailure)
        {
            return ResultCoreExtensions.Match(result, onsuccess, onfailure);
        }

        public static Result<T, E> OnFailure<T, E>(this Result<T, E> result, Action<E> action)
        {
            return Monitor(result, onfailure: action);
        }

        public static Result<T, E> OnSuccess<T, E>(this Result<T, E> result, Action<T> onsuccess)
        {
            return Monitor(result, onsuccess: onsuccess);
        }

        public static Result<T, E> OnBoth<T, E>(this Result<T, E> result, Action<T> onsuccess, Action<E> onfailure)
        {
            return Monitor(result, onsuccess, onfailure);
        }

        public static Result<O, E> OnSuccess<T, E, O>(this Result<T, E> result, Func<T, Result<O, E>> onsuccess)
        {
            return ResultCoreExtensions.Bind(result, onsuccess);
        }

        public static Result<E> OnSuccess<T, E>(this Result<T, E> result, Func<T, Result<E>> onsuccess)
        {
            return Bind(result, onsuccess);
        }

        //public static Result<T, E> UnWrap<T, E>(this Result<Maybe<T>, E> result, Func<E> none)
        //{
        //    if (result.IsSuccess)
        //    {
        //        return result.Content.Match(some => Result.Success<T, E>(some), () => Result.Failure<T, E>(none()));
        //    }

        //    return Result.Failure<T, E>(result.Error);
        //}

        //public static Result<T, E> UnWrap<T, E>(this Result<Try<T>, E> result, Func<Exception, E> failure)
        //{
        //    if (result.IsSuccess)
        //    {
        //        return result.Content.Match(value => Result.Success<T, E>(value), e => Result.Failure<T, E>(failure(e)));
        //    }

        //    return Result.Failure<T, E>(result.Error);
        //}
    }
}
