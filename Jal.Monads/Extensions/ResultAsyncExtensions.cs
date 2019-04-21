using System;
using System.Threading.Tasks;
using static Jal.Monads.Extensions.ResultCoreAsyncExtensions;

namespace Jal.Monads.Extensions
{

    public static class ResultAsyncExtensions
    {
       

        public static Task<Result<E>> OnSuccess<E>(this Result<E> result, Func<Task<Result<E>>> onsuccess)
        {
            return ResultCoreAsyncExtensions.Bind(result, onsuccess);
        }

        public static Task<Result<E>> OnSuccess<E>(this Task<Result<E>> result, Func<Task<Result<E>>> onsuccess)
        {
            return ResultCoreAsyncExtensions.Bind(result, onsuccess);
        }

        public static Task<Result<O, E>> OnSuccess<E, O>(this Result<E> result, Func<Task<Result<O, E>>> onsuccess)
        {
            return ResultCoreAsyncExtensions.Bind(result, onsuccess);
        }

        public static Task<Result<O, E>> OnSuccess<E, O>(this Task<Result<E>> result, Func<Task<Result<O, E>>> onsuccess)
        {
            return ResultCoreAsyncExtensions.Bind(result, onsuccess);
        }

        public static Task<Result<O, E>> OnSuccess<T, E, O>(this Result<T, E> result, Func<T, Task<Result<O, E>>> onsuccess)
        {
            return ResultCoreAsyncExtensions.Bind(result, onsuccess);
        }

        public static Task<Result<O, E>> OnSuccess<T, E, O>(this Task<Result<T, E>> result, Func<T, Task<Result<O, E>>> onsuccess)
        {
            return ResultCoreAsyncExtensions.Bind(result, onsuccess);
        }

        public static Task<Result<E>> OnSuccess<T, E>(this Result<T, E> result, Func<T, Task<Result<E>>> onsuccess)
        {
            return ResultCoreAsyncExtensions.Bind(result, onsuccess);
        }

        public static Task<Result<E>> OnSuccess<T, E>(this Task<Result<T, E>> result, Func<T, Task<Result<E>>> onsuccess)
        {
            return ResultCoreAsyncExtensions.Bind(result, onsuccess);
        }
    }
}
