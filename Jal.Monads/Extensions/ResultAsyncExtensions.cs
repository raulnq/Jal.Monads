using System;
using System.Threading.Tasks;

namespace Jal.Monads.Extensions
{
    public static class ResultAsyncExtensions
    {

        public static async Task<O> MatchAsync<T, E, O>(this Task<Result<T, E>> result, Func<T, Task<O>> onsuccess, Func<E, Task<O>> onfailure)
        {
            if (onfailure == null)
            {
                throw new ArgumentNullException(nameof(onfailure));
            }
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            var r = await result;

            if (r.IsSuccess)
            {
                return await onsuccess(r.Content);
            }
            else
            {
                return await onfailure(r.Error);
            }
        }

        public static async Task<Result<T, E>> MonitorAsync<T, E>(this Task<Result<T, E>> result, Func<T, Task> onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            var r = await result;

            if (r.IsSuccess)
            {
                await onsuccess(r.Content);
            }

            return r;
        }

        public static async Task<Result<T, E>> MonitorAsync<T, E>(this Task<Result<T, E>> result, Action<T> onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            var r = await result;

            if (r.IsSuccess)
            {
                onsuccess(r.Content);
            }

            return r;
        }

        public static async Task<Result<T, E>> MonitorAsync<T, E>(this Task<Result<T, E>> result, Func<E, Task> onfailure)
        {
            if (onfailure == null)
            {
                throw new ArgumentNullException(nameof(onfailure));
            }

            var r = await result;

            if (!r.IsSuccess)
            {
                await onfailure(r.Error);
            }

            return r;
        }

        public static async Task<Result<T, E>> MonitorAsync<T, E>(this Task<Result<T, E>> result, Action<E> onfailure)
        {
            if (onfailure == null)
            {
                throw new ArgumentNullException(nameof(onfailure));
            }

            var r = await result;

            if (!r.IsSuccess)
            {
                onfailure(r.Error);
            }

            return r;
        }

        public static async Task<Result<T, E>> MonitorAsync<T, E>(this Task<Result<T, E>> result, Func<T, Task> onsuccess, Func<E, Task> onfailure)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (onfailure == null)
            {
                throw new ArgumentNullException(nameof(onfailure));
            }

            var r = await result;

            if (r.IsSuccess)
            {
                await onsuccess(r.Content);
            }
            else
            {
                await onfailure(r.Error);
            }

            return r;
        }

        public static async Task<Result<T, E>> MonitorAsync<T, E>(this Task<Result<T, E>> result, Action<T> onsuccess, Action<E> onfailure)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (onfailure == null)
            {
                throw new ArgumentNullException(nameof(onfailure));
            }

            var r = await result;

            if (r.IsSuccess)
            {
                onsuccess(r.Content);
            }
            else
            {
                onfailure(r.Error);
            }

            return r;
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

            return Result<O, E>.Return(r.Error);
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

            return Result<E>.Return(r.Error);
        }
        /************************************/
        public static async Task<O> MatchAsync<E, O>(this Task<Result<E>> result, Func<Task<O>> onsuccess, Func<E, Task<O>> onfailure)
        {
            if (onfailure == null)
            {
                throw new ArgumentNullException(nameof(onfailure));
            }
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            var r = await result;

            if (r.IsSuccess)
            {
                return await onsuccess();
            }
            else
            {
                return await onfailure(r.Error);
            }
        }

        public static async Task<Result<E>> MonitorAsync<E>(this Task<Result<E>> result, Func<Task> onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            var r = await result;

            if (r.IsSuccess)
            {
                await onsuccess();
            }

            return r;
        }

        public static async Task<Result<E>> MonitorAsync<E>(this Task<Result<E>> result, Action onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            var r = await result;

            if (r.IsSuccess)
            {
                onsuccess();
            }

            return r;
        }

        public static async Task<Result<E>> MonitorAsync<E>(this Task<Result<E>> result, Func<E, Task> onfailure)
        {
            if (onfailure == null)
            {
                throw new ArgumentNullException(nameof(onfailure));
            }

            var r = await result;

            if (!r.IsSuccess)
            {
                await onfailure(r.Error);
            }

            return r;
        }

        public static async Task<Result<E>> MonitorAsync<E>(this Task<Result<E>> result, Action<E> onfailure)
        {
            if (onfailure == null)
            {
                throw new ArgumentNullException(nameof(onfailure));
            }

            var r = await result;

            if (!r.IsSuccess)
            {
                onfailure(r.Error);
            }

            return r;
        }

        public static async Task<Result<E>> MonitorAsync<E>(this Task<Result<E>> result, Func<Task> onsuccess, Func<E, Task> onfailure)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (onfailure == null)
            {
                throw new ArgumentNullException(nameof(onfailure));
            }

            var r = await result;

            if (r.IsSuccess)
            {
                await onsuccess();
            }
            else
            {
                await onfailure(r.Error);
            }

            return r;
        }

        public static async Task<Result<E>> MonitorAsync<E>(this Task<Result<E>> result, Action onsuccess, Action<E> onfailure)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (onfailure == null)
            {
                throw new ArgumentNullException(nameof(onfailure));
            }

            var r = await result;

            if (r.IsSuccess)
            {
                onsuccess();
            }
            else
            {
                onfailure(r.Error);
            }

            return r;
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

            return Result<E>.Return(r.Error);
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

            return Result<O, E>.Return(r.Error);
        }
        /************************************/

        public static Task<O> Return<T, E, O>(this Task<Result<T, E>> result, Func<T, Task<O>> onsuccess, Func<E, Task<O>> onfailure)
        {
            return MatchAsync(result, onsuccess, onfailure);
        }

        public static Task<Result<T, E>> OnSuccess<T, E>(this Task<Result<T, E>> result, Func<T, Task> onsuccess)
        {
            return MonitorAsync(result, onsuccess);
        }

        public static Task<Result<T, E>> OnSuccess<T, E>(this Task<Result<T, E>> result, Action<T> onsuccess)
        {
            return MonitorAsync(result, onsuccess);
        }

        public static Task<Result<T, E>> OnFailure<T, E>(this Task<Result<T, E>> result, Func<E, Task> onfailure)
        {
            return MonitorAsync(result, onfailure);
        }

        public static Task<Result<T, E>> OnFailure<T, E>(this Task<Result<T, E>> result, Action<E> onfailure)
        {
            return MonitorAsync(result, onfailure);
        }

        public static Task<Result<T, E>> OnBoth<T, E>(this Task<Result<T, E>> result, Func<T, Task> onsuccess, Func<E, Task> onfailure)
        {
            return MonitorAsync(result, onsuccess, onfailure);
        }

        public static Task<Result<T, E>> OnBoth<T, E>(this Task<Result<T, E>> result, Action<T> onsuccess, Action<E> onfailure)
        {
            return MonitorAsync(result, onsuccess, onfailure);
        }

        public static Task<Result<O, E>> OnSuccess<T, E, O>(this Task<Result<T, E>> result, Func<T, Task<Result<O, E>>> onsuccess)
        {
            return BindAsync(result, onsuccess);
        }

        public static Task<Result<E>> OnSuccess<T, E>(this Task<Result<T, E>> result, Func<T, Task<Result<E>>> onsuccess)
        {
            return BindAsync(result, onsuccess);
        }
        /************************************/

        public static Task<O> Return<E, O>(this Task<Result<E>> result, Func<Task<O>> onsuccess, Func<E, Task<O>> onfailure)
        {
            return MatchAsync(result, onsuccess, onfailure);
        }

        public static Task<Result<E>> OnSuccess<E>(this Task<Result<E>> result, Func<Task> onsuccess)
        {
            return MonitorAsync(result, onsuccess);
        }

        public static Task<Result<E>> OnSuccess<E>(this Task<Result<E>> result, Action onsuccess)
        {
            return MonitorAsync(result, onsuccess);
        }

        public static Task<Result<E>> OnFailure<E>(this Task<Result<E>> result, Func<E, Task> onfailure)
        {
            return MonitorAsync(result, onfailure);
        }

        public static Task<Result<E>> OnFailure<E>(this Task<Result<E>> result, Action<E> onfailure)
        {
            return MonitorAsync(result, onfailure);
        }

        public static Task<Result<E>> OnBoth<E>(this Task<Result<E>> result, Func<Task> onsuccess, Func<E, Task> onfailure)
        {
            return MonitorAsync(result, onsuccess, onfailure);
        }

        public static Task<Result<E>> OnBoth<E>(this Task<Result<E>> result, Action onsuccess, Action<E> onfailure)
        {
            return MonitorAsync(result, onsuccess, onfailure);
        }

        public static Task<Result<E>> OnSuccess<E>(this Task<Result<E>> result, Func<Task<Result<E>>> onsuccess)
        {
            return BindAsync(result, onsuccess);
        }

        public static Task<Result<O, E>> OnSuccess<E, O>(this Task<Result<E>> result, Func<Task<Result<O, E>>> onsuccess)
        {
            return BindAsync(result, onsuccess);
        }
        //public static async Task<Result> MergeAsync(this Task<Result> first, Task<Result> second)
        //{
        //    var rfirst = await first;

        //    var rsecond = await second;

        //    if (rfirst.IsSuccess && rsecond.IsSuccess)
        //    {
        //        return Result.Success();
        //    }

        //    return Result.Failure(Merge(rfirst.Errors, rsecond.Errors));
        //}

        //public static async Task<Result<TFirst>> MergeAsync<TFirst, TSecond>(this Task<Result<TFirst>> first, Task<Result<TSecond>> second)
        //{
        //    var rfirst = await first;

        //    var rsecond = await second;

        //    if (rfirst.IsSuccess && rsecond.IsSuccess)
        //    {
        //        return rfirst;
        //    }

        //    return new Result<TFirst>(Merge(rfirst.Error, rsecond.Error));
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
