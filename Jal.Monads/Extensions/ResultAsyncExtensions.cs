using System;
using System.Threading.Tasks;
using static Jal.Monads.Extensions.ResultCoreAsyncExtensions;

namespace Jal.Monads.Extensions
{

    public static class ResultAsyncExtensions
    {
       

        public static Task<Result<E>> OnSuccessAsync<E>(this Result<E> result, Func<Task<Result<E>>> onsuccess)
        {
            return ResultCoreAsyncExtensions.BindAsync(result, onsuccess);
        }

        public static Task<Result<E>> OnSuccessAsync<E>(this Task<Result<E>> result, Func<Task<Result<E>>> onsuccess)
        {
            return ResultCoreAsyncExtensions.BindAsync(result, onsuccess);
        }

        public static Task<Result<O, E>> OnSuccessAsync<E, O>(this Result<E> result, Func<Task<Result<O, E>>> onsuccess)
        {
            return ResultCoreAsyncExtensions.BindAsync(result, onsuccess);
        }

        public static Task<Result<O, E>> OnSuccessAsync<E, O>(this Task<Result<E>> result, Func<Task<Result<O, E>>> onsuccess)
        {
            return ResultCoreAsyncExtensions.BindAsync(result, onsuccess);
        }

        public static Task<Result<O, E>> OnSuccessAsync<T, E, O>(this Result<T, E> result, Func<T, Task<Result<O, E>>> onsuccess)
        {
            return ResultCoreAsyncExtensions.BindAsync(result, onsuccess);
        }

        public static Task<Result<O, E>> OnSuccessAsync<T, E, O>(this Task<Result<T, E>> result, Func<T, Task<Result<O, E>>> onsuccess)
        {
            return ResultCoreAsyncExtensions.BindAsync(result, onsuccess);
        }

        public static Task<Result<E>> OnSuccessAsync<T, E>(this Result<T, E> result, Func<T, Task<Result<E>>> onsuccess)
        {
            return ResultCoreAsyncExtensions.BindAsync(result, onsuccess);
        }

        public static Task<Result<E>> OnSuccessAsync<T, E>(this Task<Result<T, E>> result, Func<T, Task<Result<E>>> onsuccess)
        {
            return ResultCoreAsyncExtensions.BindAsync(result, onsuccess);
        }
    }
}
