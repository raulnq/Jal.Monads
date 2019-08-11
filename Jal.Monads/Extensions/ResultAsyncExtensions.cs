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

        public static Task<Result<T, E>> OnBothAsync<T, E>(this Task<Result<T, E>> result, Action<T> onsuccess, Action<E> onfailure)
        {
            return MonitorAsync(result, onsuccess, onfailure);
        }

        public static Task<Result<E>> OnBothAsync<E>(this Task<Result<E>> result, Action onsuccess, Action<E> onfailure)
        {
            return MonitorAsync(result, onsuccess, onfailure);
        }

        public static Task<Result<T, E>> OnBothAsync<T, E>(this Task<Result<T, E>> result, Func<T, Task> onsuccess, Func<E, Task> onfailure)
        {
            return MonitorAsync(result, onsuccess, onfailure);
        }

        public static Task<Result<E>> OnBothAsync<E>(this Task<Result<E>> result, Func<Task> onsuccess, Func<E, Task> onfailure)
        {
            return MonitorAsync(result, onsuccess, onfailure);
        }

        public static Task<Result<E>> OnSuccessAsync<T, E>(this Task<Result<T, E>> result, Func<T, Task<Result<E>>> onsuccess)
        {
            return ResultCoreAsyncExtensions.BindAsync(result, onsuccess);
        }

        public static Task<Result<T, E>> OnFailureAsync<T, E>(this Task<Result<T, E>> result, Action<E> action)
        {
            return MonitorAsync(result, onfailure: action);
        }

        public static Task<Result<E>> OnFailureAsync<E>(this Task<Result<E>> result, Action<E> action)
        {
            return MonitorAsync(result, onfailure: action);
        }

        public static Task<Result<T, E>> OnFailureAsync<T, E>(this Task<Result<T, E>> result, Func<E, Task> action)
        {
            return MonitorAsync(result, onfailure: action);
        }

        public static Task<Result<E>> OnFailureAsync<E>(this Task<Result<E>> result, Func<E, Task> action)
        {
            return MonitorAsync(result, onfailure: action);
        }

        public static Task<Result<T, E>> OnSuccessAsync<T, E>(this Task<Result<T, E>> result, Action<T> onsuccess)
        {
            return MonitorAsync(result, onsuccess: onsuccess);
        }

        public static Task<Result<T, E>> OnSuccessAsync<T, E>(this Task<Result<T, E>> result, Func<T, Task> onsuccess)
        {
            return MonitorAsync(result, onsuccess: onsuccess);
        }

        public static Task<Result<E>> OnSuccessAsync<E>(this Task<Result<E>> result, Action onsuccess)
        {
            return MonitorAsync(result, onsuccess: onsuccess);
        }

        public static Task<Result<E>> OnSuccessAsync<E>(this Task<Result<E>> result, Func<Task> onsuccess)
        {
            return MonitorAsync(result, onsuccess: onsuccess);
        }

        public static async Task<Result<T, E>> MonitorAsync<T, E>(this Task<Result<T, E>> result, Action<T> onsuccess = null, Action<E> onfailure = null)
        {
            var r = await result;

            if (r.IsSuccess)
            {
                onsuccess?.Invoke(r.Content);
            }
            else
            {
                onfailure?.Invoke(r.Error);
            }

            return r;
        }

        public static async Task<Result<E>> MonitorAsync<E>(this Task<Result<E>> result, Action onsuccess = null, Action<E> onfailure = null)
        {
            var r = await result;

            if (r.IsSuccess)
            {
                onsuccess?.Invoke();
            }
            else
            {
                onfailure?.Invoke(r.Error);
            }

            return r;
        }

        public static async Task<Result<T, E>> MonitorAsync<T, E>(this Task<Result<T, E>> result, Func<T, Task> onsuccess = null, Func<E, Task> onfailure = null)
        {
            var r = await result;

            if (r.IsSuccess)
            {
                if (onsuccess != null)
                    await onsuccess?.Invoke(r.Content);
            }
            else
            {
                if (onfailure != null)
                    await onfailure?.Invoke(r.Error);
            }

            return r;
        }

        public static async Task<Result<E>> MonitorAsync<E>(this Task<Result<E>> result, Func<Task> onsuccess = null, Func<E, Task> onfailure = null)
        {
            var r = await result;

            if (r.IsSuccess)
            {
                if(onsuccess!=null)
                    await onsuccess.Invoke();
            }
            else
            {
                if (onfailure != null)
                    await onfailure?.Invoke(r.Error);
            }

            return r;
        }
    }
}
