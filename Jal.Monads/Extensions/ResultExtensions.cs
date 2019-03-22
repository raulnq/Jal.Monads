using System;

namespace Jal.Monads.Extensions
{

    public static class ResultExtensions
    {
        public static Result<T, E> UnWrap<T, E>(this Result<Maybe<T>, E> result, Func<E> none)
        {
            if(result.IsSuccess)
            {
                return result.Content.Match(some => Result<T, E>.Return(some), ()=> Result<T, E>.Return(none()));
            }

            return Result<T,E>.Return(result.Error);
        }

        public static Result<T, E> ToSuccess<T, E>(this T content)
        {
            return Result<T, E>.Return(content);
        }

        public static Result<T, E> ToFailure<T, E>(this E error)
        {
            return Result<T, E>.Return(error);
        }

        public static Result<E> ToFailure<E>(this E error)
        {
            return Result<E>.Return(error);
        }
        /************************************/
        public static O Match<T, E, O>(this Result<T, E> result, Func<T, O> onsuccess, Func<E, O> onfailure)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }
            if (onfailure == null)
            {
                throw new ArgumentNullException(nameof(onfailure));
            }

            if (result.IsSuccess)
            {
                return onsuccess(result.Content);
            }
            else
            {
                return onfailure(result.Error);
            }
        }

        public static Result<T, E> Monitor<T, E>(this Result<T, E> result, Action<T> onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (result.IsSuccess)
            {
                onsuccess(result.Content);
            }

            return result;
        }

        public static Result<T, E> Monitor<T, E>(this Result<T, E> result, Action<E> onfailure)
        {
            if (onfailure == null)
            {
                throw new ArgumentNullException(nameof(onfailure));
            }

            if (!result.IsSuccess)
            {
                onfailure(result.Error);
            }

            return result;
        }

        public static Result<T, E> Monitor<T, E>(this Result<T, E> result, Action<T> onsuccess, Action<E> onfailure)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (onfailure == null)
            {
                throw new ArgumentNullException(nameof(onfailure));
            }

            if (result.IsSuccess)
            {
                onsuccess(result.Content);
            }
            else
            {
                onfailure(result.Error);
            }

            return result;
        }

        public static Result<O, E> Bind<T, E, O>(this Result<T, E> result, Func<T, Result<O, E>> onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (result.IsSuccess)
            {
                return onsuccess(result.Content);
            }

            return Result<O, E>.Return(result.Error);
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

            return Result<E>.Return(result.Error);
        }

        /************************************/
        public static O Match<E, O>(this Result<E> result, Func<O> onsuccess, Func<E, O> onfailure)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }
            if (onfailure == null)
            {
                throw new ArgumentNullException(nameof(onfailure));
            }

            if (result.IsSuccess)
            {
                return onsuccess();
            }
            else
            {
                return onfailure(result.Error);
            }
        }

        public static Result<E> Monitor<E>(this Result<E> result, Action onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (result.IsSuccess)
            {
                onsuccess();
            }

            return result;
        }

        public static Result<E> Monitor<E>(this Result<E> result, Action<E> onfailure)
        {
            if (onfailure == null)
            {
                throw new ArgumentNullException(nameof(onfailure));
            }

            if (!result.IsSuccess)
            {
                onfailure(result.Error);
            }

            return result;
        }

        public static Result<E> Monitor<E>(this Result<E> result, Action onsuccess, Action<E> onfailure)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (onfailure == null)
            {
                throw new ArgumentNullException(nameof(onfailure));
            }

            if (result.IsSuccess)
            {
                onsuccess();
            }
            else
            {
                onfailure(result.Error);
            }

            return result;
        }

        public static Result<E> Bind<E>(this Result<E> result, Func<Result<E>> onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (result.IsSuccess)
            {
                return onsuccess();
            }

            return Result<E>.Return(result.Error);
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

            return Result<O, E>.Return(result.Error);
        }

        /************************************/
        public static O Return<E, O>(this Result<E> result, Func<O> onsuccess, Func<E, O> onfailure)
        {
            return Match(result, onsuccess, onfailure);
        }

        public static Result<E> OnSuccess<E>(this Result<E> result, Action action)
        {
            return Monitor(result, action);
        }

        public static Result<E> OnFailure<E>(this Result<E> result, Action<E> action)
        {
            return Monitor(result, action);
        }

        public static Result<E> OnBoth<E>(this Result<E> result, Action onsuccess, Action<E> onfailure)
        {
            return Monitor(result, onsuccess, onfailure);
        }

        public static Result<E> OnSuccess<E>(this Result<E> result, Func<Result<E>> onsuccess)
        {
            return Bind(result, onsuccess);
        }

        public static Result<O, E> OnSuccess<E, O>(this Result<E> result, Func<Result<O, E>> onsuccess)
        {
            return Bind(result, onsuccess);
        }

        /************************************/
        public static O Return<T, E, O>(this Result<T, E> result, Func<T, O> onsuccess, Func<E, O> onfailure)
        {
            return Match(result, onsuccess, onfailure);
        }
        public static Result<T, E> OnFailure<T, E>(this Result<T, E> result, Action<E> action)
        {
            return Monitor(result, action);
        }

        public static Result<T, E> OnSuccess<T, E>(this Result<T, E> result, Action<T> onsuccess)
        {
            return Monitor(result, onsuccess);
        }

        public static Result<T, E> OnBoth<T, E>(this Result<T, E> result, Action<T> onsuccess, Action<E> onfailure)
        {
            return Monitor(result, onsuccess, onfailure);
        }

        public static Result<O, E> OnSuccess<T, E, O>(this Result<T, E> result, Func<T, Result<O, E>> onsuccess)
        {
            return Bind(result, onsuccess);
        }

        public static Result<E> OnSuccess<T, E>(this Result<T, E> result, Func<T, Result<E>> onsuccess)
        {
            return Bind(result, onsuccess);
        }

        /************************************/
        //public static Result Merge(this Result first, Result second)
        //{
        //    if (first.IsSuccess && second.IsSuccess)
        //    {
        //        return Result.Success();
        //    }

        //    return Result.Failure(Merge(first.Errors, second.Errors));
        //}

        //public static Result<TFirst> Merge<TFirst, TSecond>(this Result<TFirst> first, Result<TSecond> second)
        //{
        //    if (first.IsSuccess && second.IsSuccess)
        //    {
        //        return first;
        //    }

        //    return new Result<TFirst>(Merge(first.Error, second.Error));
        //}

        //public static T[] Merge<T>(T[] first, T[] second)
        //{
        //    var result = new T[first.Length + second.Length];
        //    Array.Copy(first, result, first.Length);
        //    Array.Copy(second, 0, result, first.Length, second.Length);
        //    return result;
        //}
    }
}
