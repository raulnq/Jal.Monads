using System;

namespace Jal.Monads
{
    public static class ResultExtensions
    {
        public static Result<T> ToResult<T>(this T content)
        {
            return Result.Success(content);
        }

        public static TOutput Return<TInput, TOutput>(this Result<TInput> result, Func<TInput, TOutput> onsuccess, Func<string, TOutput> onfailure)
        {
            if (onfailure == null)
            {
                throw new ArgumentNullException(nameof(onfailure));
            }
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (result.IsSuccess)
            {
                return onsuccess(result.Content);
            }
            else
            {
                return onfailure(string.Join(",", result.Errors));
            }
        }

        public static TOutput Return<TInput, TOutput>(this Result<TInput> result, Func<TInput, TOutput> onsuccess, Func<string[], TOutput> onfailure)
        {
            if (onfailure == null)
            {
                throw new ArgumentNullException(nameof(onfailure));
            }
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (result.IsSuccess)
            {
                return onsuccess(result.Content);
            }
            else
            {
                return onfailure(result.Errors);
            }
        }

        //Tee
        public static Result<TInput> OnFailure<TInput>(this Result<TInput> result, Action<TInput> onfailure)
        {
            if (onfailure == null)
            {
                throw new ArgumentNullException(nameof(onfailure));
            }

            if (result.IsFailure)
            {
                onfailure(result.Content);
            }

            return result;
        }

        //Tee
        public static Result<TInput> OnSuccess<TInput>(this Result<TInput> result, Action<TInput> onsuccess)
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

        //Bind
        public static Result<TOutput> OnSuccess<TInput, TOutput>(this Result<TInput> result, Func<TInput, Result<TOutput>> onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (result.IsSuccess)
            {
                return onsuccess(result.Content);
            }

            return new Result<TOutput>(result.Errors);
        }

        //Map
        public static Result<TOutput> OnSuccess<TInput, TOutput>(this Result<TInput> result, Func<TInput, TOutput> onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (result.IsSuccess)
            {
                return onsuccess(result.Content).ToResult();
            }

            return new Result<TOutput>(result.Errors);
        }

        //Monitor
        public static Result<TInput> OnBoth<TInput>(this Result<TInput> result, Action<TInput> onboth)
        {
            if (onboth == null)
            {
                throw new ArgumentNullException(nameof(onboth));
            }

            onboth(result.Content);

            return result;
        }

        public static Result Merge(this Result result, Result other)
        {
            if (result.IsSuccess && other.IsSuccess)
            {
                return Result.Success();
            }

            return Result.Failure(Merge(result.Errors, other.Errors));
        }

        public static T[] Merge<T>(T[] first, T[] second)
        {
            var result = new T[first.Length + second.Length];
            Array.Copy(first, result, first.Length);
            Array.Copy(second, 0, result, first.Length, second.Length);
            return result;
        }
    }
}
