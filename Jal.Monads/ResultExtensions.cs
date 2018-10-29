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

        public static TOutput Return<TOutput>(this Result result, Func<TOutput> onsuccess, Func<string, TOutput> onfailure)
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
                return onsuccess();
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

        public static TOutput Return<TOutput>(this Result result, Func<TOutput> onsuccess, Func<string[], TOutput> onfailure)
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
                return onsuccess();
            }
            else
            {
                return onfailure(result.Errors);
            }
        }

        //Tee
        public static Result<TInput> OnFailure<TInput>(this Result<TInput> result, Action<string[]> onfailure)
        {
            if (onfailure == null)
            {
                throw new ArgumentNullException(nameof(onfailure));
            }

            if (result.IsFailure)
            {
                onfailure(result.Errors);
            }

            return result;
        }

        //Tee
        public static Result OnFailure(this Result result, Action<string[]> onfailure)
        {
            if (onfailure == null)
            {
                throw new ArgumentNullException(nameof(onfailure));
            }

            if (result.IsFailure)
            {
                onfailure(result.Errors);
            }

            return result;
        }

        //Bind
        public static Result OnFailure(this Result result, Func<string[], Result> onfailure)
        {
            if (onfailure == null)
            {
                throw new ArgumentNullException(nameof(onfailure));
            }

            if (result.IsFailure)
            {
                return onfailure(result.Errors);
            }

            return result;
        }

        public static Result OnFailure<TInput>(this Result<TInput> result, Func<string[], Result> onfailure)
        {
            if (onfailure == null)
            {
                throw new ArgumentNullException(nameof(onfailure));
            }

            if (result.IsFailure)
            {
                return onfailure(result.Errors);
            }

            return result;
        }

        //Bind
        public static Result<TInput> OnFailure<TInput>(this Result<TInput> result, Func<string[], Result<TInput>> onfailure)
        {
            if (onfailure == null)
            {
                throw new ArgumentNullException(nameof(onfailure));
            }

            if (result.IsFailure)
            {
                return onfailure(result.Errors);
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

        //Tee
        public static Result OnSuccess(this Result result, Action onsuccess)
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

        //Bind
        public static Result OnSuccess(this Result result, Func<Result> onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (result.IsSuccess)
            {
                return onsuccess();
            }

            return Result.Failure(result.Errors);
        }

        //Bind
        public static Result OnSuccess<TInput>(this Result<TInput> result, Func<TInput, Result> onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (result.IsSuccess)
            {
                return onsuccess(result.Content);
            }

            return Result.Failure(result.Errors);
        }

        public static Result<TOutput> OnSuccess<TOutput>(this Result result, Func<Result<TOutput>> onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (result.IsSuccess)
            {
                return onsuccess();
            }

            return new Result<TOutput>(result.Errors);
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

        public static Result<TOutput> OnBoth<TInput, TOutput>(this Result<TInput> result, Func<TInput, Result<TOutput>> onsuccess, Func<string[], Result<TOutput>> onfailure)
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
                return onfailure(result.Errors);
            }
        }

        //Monitor
        public static Result<TInput> OnBoth<TInput>(this Result<TInput> result, Action onboth)
        {
            if (onboth == null)
            {
                throw new ArgumentNullException(nameof(onboth));
            }

            onboth();

            return result;
        }

        //Monitor
        public static Result OnBoth<TInput>(this Result<TInput> result, Func<TInput, Result> onsuccess, Func<string[], Result> onfailure)
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
                return onfailure(result.Errors);
            }
        }

        //Monitor
        public static Result OnBoth(this Result result, Func<Result> onsuccess, Func<string[], Result> onfailure)
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
                return onfailure(result.Errors);
            }
        }

        //Monitor
        public static Result OnBoth(this Result result, Action onboth)
        {
            if (onboth == null)
            {
                throw new ArgumentNullException(nameof(onboth));
            }

            onboth();

            return result;
        }

        //Monitor
        public static Result OnBoth(this Result result, Action onsuccess, Action<string[]> onfailure)
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
                onfailure(result.Errors);
            }

            return result;
        }

        //Monitor
        public static Result<TInput> OnBoth<TInput>(this Result<TInput> result, Action onsuccess, Action<string[]> onfailure)
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
                onfailure(result.Errors);
            }

            return result;
        }

        public static Result Merge(this Result first, Result second)
        {
            if (first.IsSuccess && second.IsSuccess)
            {
                return Result.Success();
            }

            return Result.Failure(Merge(first.Errors, second.Errors));
        }

        public static Result<TFirst> Merge<TFirst, TSecond>(this Result<TFirst> first, Result<TSecond> second)
        {
            if (first.IsSuccess && second.IsSuccess)
            {
                return first;
            }

            return new Result<TFirst>(Merge(first.Errors, second.Errors));
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
