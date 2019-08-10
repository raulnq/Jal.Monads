using System;
using System.Threading.Tasks;
using static Jal.Monads.Result;

namespace Jal.Monads.Extensions
{
    public static class ResultCoreAsyncExtensions
    {
        public static Task<Result<O, E>> BindAsync<T, E, O>(this Result<T, E> result, Func<T, Task<Result<O, E>>> onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (result.IsSuccess)
            {
                return onsuccess(result.Content);
            }

            return Task.FromResult(Failure<O, E>(result.Error));
        }

        public static async Task<Result<O, E>> BindAsync<T, E, O>(this Task<Result<T, E>> result, Func<T, Task<Result<O, E>>> onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            var r = await result;

            if (r.IsSuccess)
            {
                return await onsuccess(r.Content);
            }

            return r.Error;
        }

        public static Task<Result<E>> BindAsync<E>(this Result<E> result, Func<Task<Result<E>>> onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (result.IsSuccess)
            {
                return onsuccess();
            }

            return Task.FromResult(Failure(result.Error));
        }

        public static async Task<Result<E>> BindAsync<E>(this Task<Result<E>> result, Func<Task<Result<E>>> onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            var r = await result;

            if (r.IsSuccess)
            {
                return await onsuccess();
            }

            return r.Error;
        }

        public static Task<Result<E>> BindAsync<T, E>(this Result<T, E> result, Func<T, Task<Result<E>>> onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (result.IsSuccess)
            {
                return onsuccess(result.Content);
            }

            return Task.FromResult(Failure(result.Error));
        }

        public static Task<Result<O, E>> BindAsync<E, O>(this Result<E> result, Func<Task<Result<O, E>>> onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (result.IsSuccess)
            {
                return onsuccess();
            }

            return Task.FromResult(Failure<O, E>(result.Error));
        }

        public static async Task<Result<E>> BindAsync<T, E>(this Task<Result<T, E>> result, Func<T, Task<Result<E>>> onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            var r = await result;

            if (r.IsSuccess)
            {
                return await onsuccess(r.Content);
            }

            return r.Error;
        }

        public static async Task<Result<O, E>> BindAsync<E, O>(this Task<Result<E>> result, Func<Task<Result<O, E>>> onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            var r = await result;

            if (r.IsSuccess)
            {
                return await onsuccess();
            }

            return r.Error;
        }
    }
}
