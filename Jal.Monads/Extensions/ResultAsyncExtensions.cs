using System;
using System.Threading.Tasks;

namespace Jal.Monads.Extensions
{
    public static class ResultAsyncExtensions
    {

        //public static async Task<TOutput> ReturnAsync<TInput, TOutput>(this Task<Result<TInput>> result, Func<TInput, Task<TOutput>> onsuccess, Func<string, Task<TOutput>> onfailure)
        //{
        //    if (onfailure == null)
        //    {
        //        throw new ArgumentNullException(nameof(onfailure));
        //    }
        //    if (onsuccess == null)
        //    {
        //        throw new ArgumentNullException(nameof(onsuccess));
        //    }

        //    var r = await result;

        //    if (r.IsSuccess)
        //    {
        //        return await onsuccess(r.Content);
        //    }
        //    else
        //    {
        //        return await onfailure(string.Join(",", r.Error));
        //    }
        //}

        //public static async Task<TOutput> ReturnAsync<TOutput>(this Task<Result> result, Func<Task<TOutput>> onsuccess, Func<string, Task<TOutput>> onfailure)
        //{
        //    if (onfailure == null)
        //    {
        //        throw new ArgumentNullException(nameof(onfailure));
        //    }
        //    if (onsuccess == null)
        //    {
        //        throw new ArgumentNullException(nameof(onsuccess));
        //    }

        //    var r = await result;

        //    if (r.IsSuccess)
        //    {
        //        return await onsuccess();
        //    }
        //    else
        //    {
        //        return await onfailure(string.Join(",", r.Errors));
        //    }
        //}

        //public static async Task<TOutput> ReturnAsync<TInput, TOutput>(this Task<Result<TInput>> result, Func<TInput, Task<TOutput>> onsuccess, Func<string[], Task<TOutput>> onfailure)
        //{
        //    if (onfailure == null)
        //    {
        //        throw new ArgumentNullException(nameof(onfailure));
        //    }
        //    if (onsuccess == null)
        //    {
        //        throw new ArgumentNullException(nameof(onsuccess));
        //    }

        //    var r = await result;

        //    if (r.IsSuccess)
        //    {
        //        return await onsuccess(r.Content);
        //    }
        //    else
        //    {
        //        return await onfailure(r.Error);
        //    }
        //}

        //public static async Task<TOutput> ReturnAsync<TOutput>(this Task<Result> result, Func<Task<TOutput>> onsuccess, Func<string[], Task<TOutput>> onfailure)
        //{
        //    if (onfailure == null)
        //    {
        //        throw new ArgumentNullException(nameof(onfailure));
        //    }
        //    if (onsuccess == null)
        //    {
        //        throw new ArgumentNullException(nameof(onsuccess));
        //    }

        //    var r = await result;

        //    if (r.IsSuccess)
        //    {
        //        return await onsuccess();
        //    }
        //    else
        //    {
        //        return await onfailure(r.Errors);
        //    }
        //}

        //public static async Task<Result<TInput>> OnFailureAsync<TInput>(this Task<Result<TInput>> result, Func<string[], Task> onfailure)
        //{
        //    if (onfailure == null)
        //    {
        //        throw new ArgumentNullException(nameof(onfailure));
        //    }

        //    var r = await result;

        //    if (r.IsFailure)
        //    {
        //        await onfailure(r.Error);
        //    }

        //    return r;
        //}

        //public static async Task<Result> OnFailureAsync(this Task<Result> result, Func<string[], Task> onfailure)
        //{
        //    if (onfailure == null)
        //    {
        //        throw new ArgumentNullException(nameof(onfailure));
        //    }

        //    var r = await result;

        //    if (r.IsFailure)
        //    {
        //        await onfailure(r.Errors);
        //    }

        //    return r;
        //}

        
        //public static async Task<Result> OnFailureAsync(this Task<Result> result, Func<string[], Task<Result>> onfailure)
        //{
        //    if (onfailure == null)
        //    {
        //        throw new ArgumentNullException(nameof(onfailure));
        //    }

        //    var r = await result;

        //    if (r.IsFailure)
        //    {
        //        return await onfailure(r.Errors);
        //    }

        //    return r;
        //}

        //public static async Task<Result> OnFailureAsync<TInput>(this Task<Result<TInput>> result, Func<string[], Task<Result>> onfailure)
        //{
        //    if (onfailure == null)
        //    {
        //        throw new ArgumentNullException(nameof(onfailure));
        //    }

        //    var r = await result;

        //    if (r.IsFailure)
        //    {
        //        return await onfailure(r.Error);
        //    }

        //    return r;
        //}

        //public static async Task<Result<TInput>> OnFailureAsync<TInput>(this Task<Result<TInput>> result, Func<string[], Task<Result<TInput>>> onfailure)
        //{
        //    if (onfailure == null)
        //    {
        //        throw new ArgumentNullException(nameof(onfailure));
        //    }

        //    var r = await result;

        //    if (r.IsFailure)
        //    {
        //        return await onfailure(r.Error);
        //    }

        //    return r;
        //}

        //public static async Task<Result<TInput>> OnSuccessAsync<TInput>(this Task<Result<TInput>> result, Func<TInput, Task> onsuccess)
        //{
        //    if (onsuccess == null)
        //    {
        //        throw new ArgumentNullException(nameof(onsuccess));
        //    }

        //    var r = await result;

        //    if (r.IsSuccess)
        //    {
        //        await onsuccess(r.Content);
        //    }

        //    return r;
        //}

        //public static async Task<Result> OnSuccessAsync(this Task<Result> result, Func<Task> onsuccess)
        //{
        //    if (onsuccess == null)
        //    {
        //        throw new ArgumentNullException(nameof(onsuccess));
        //    }

        //    var r = await result;

        //    if (r.IsSuccess)
        //    {
        //        await onsuccess();
        //    }

        //    return r;
        //}

        //public static async Task<Result> OnSuccessAsync(this Task<Result> result, Func<Task<Result>> onsuccess)
        //{
        //    if (onsuccess == null)
        //    {
        //        throw new ArgumentNullException(nameof(onsuccess));
        //    }

        //    var r = await result;

        //    if (r.IsSuccess)
        //    {
        //        return await onsuccess();
        //    }

        //    return Result.Failure(r.Errors);
        //}

        //public static async Task<Result> OnSuccessAsync<TInput>(this Task<Result<TInput>> result, Func<TInput, Task<Result>> onsuccess)
        //{
        //    if (onsuccess == null)
        //    {
        //        throw new ArgumentNullException(nameof(onsuccess));
        //    }

        //    var r = await result;

        //    if (r.IsSuccess)
        //    {
        //        return await onsuccess(r.Content);
        //    }

        //    return Result.Failure(r.Error);
        //}

        //public static async Task<Result<TOutput>> OnSuccessAsync<TOutput>(this Task<Result> result, Func<Task<Result<TOutput>>> onsuccess)
        //{
        //    if (onsuccess == null)
        //    {
        //        throw new ArgumentNullException(nameof(onsuccess));
        //    }

        //    var r = await result;

        //    if (r.IsSuccess)
        //    {
        //        return await onsuccess();
        //    }

        //    return new Result<TOutput>(r.Errors);
        //}

        //public static async Task<Result<TOutput>> OnSuccessAsync<TInput, TOutput>(this Task<Result<TInput>> result, Func<TInput, Task<Result<TOutput>>> onsuccess)
        //{
        //    if (onsuccess == null)
        //    {
        //        throw new ArgumentNullException(nameof(onsuccess));
        //    }

        //    var r = await result;

        //    if (r.IsSuccess)
        //    {
        //        return await onsuccess(r.Content);
        //    }

        //    return new Result<TOutput>(r.Error);
        //}

        //public static async Task<Result<TOutput>> OnBothAsync<TInput, TOutput>(this Task<Result<TInput>> result, Func<TInput, Task<Result<TOutput>>> onsuccess, Func<string[], Task<Result<TOutput>>> onfailure)
        //{
        //    if (onsuccess == null)
        //    {
        //        throw new ArgumentNullException(nameof(onsuccess));
        //    }

        //    if (onfailure == null)
        //    {
        //        throw new ArgumentNullException(nameof(onfailure));
        //    }

        //    var r = await result;

        //    if (r.IsSuccess)
        //    {
        //        return await onsuccess(r.Content);
        //    }
        //    else
        //    {
        //        return await onfailure(r.Error);
        //    }
        //}

        //public static async Task<Result<TInput>> OnBothAsync<TInput>(this Task<Result<TInput>> result, Func<Task> onboth)
        //{
        //    if (onboth == null)
        //    {
        //        throw new ArgumentNullException(nameof(onboth));
        //    }

        //    await onboth();

        //    return await result;
        //}

        //public static async Task<Result> OnBothAsync<TInput>(this Task<Result<TInput>> result, Func<TInput, Task<Result>> onsuccess, Func<string[], Task<Result>> onfailure)
        //{
        //    if (onsuccess == null)
        //    {
        //        throw new ArgumentNullException(nameof(onsuccess));
        //    }

        //    if (onfailure == null)
        //    {
        //        throw new ArgumentNullException(nameof(onfailure));
        //    }

        //    var r = await result;

        //    if (r.IsSuccess)
        //    {
        //        return await onsuccess(r.Content);
        //    }
        //    else
        //    {
        //        return await onfailure(r.Error);
        //    }
        //}

        //public static async Task<Result> OnBothAsync(this Task<Result> result, Func<Task<Result>> onsuccess, Func<string[], Task<Result>> onfailure)
        //{
        //    if (onsuccess == null)
        //    {
        //        throw new ArgumentNullException(nameof(onsuccess));
        //    }

        //    if (onfailure == null)
        //    {
        //        throw new ArgumentNullException(nameof(onfailure));
        //    }

        //    var r = await result;

        //    if (r.IsSuccess)
        //    {
        //        return await onsuccess();
        //    }
        //    else
        //    {
        //        return await onfailure(r.Errors);
        //    }
        //}

        //public static async Task<Result> OnBothAsync(this Task<Result> result, Func<Task> onboth)
        //{
        //    if (onboth == null)
        //    {
        //        throw new ArgumentNullException(nameof(onboth));
        //    }

        //    await onboth();

        //    return await result;
        //}

        //public static async Task<Result> OnBothAsync(this Task<Result> result, Func<Task> onsuccess, Func<string[], Task> onfailure)
        //{
        //    if (onsuccess == null)
        //    {
        //        throw new ArgumentNullException(nameof(onsuccess));
        //    }

        //    if (onfailure == null)
        //    {
        //        throw new ArgumentNullException(nameof(onfailure));
        //    }

        //    var r = await result;

        //    if (r.IsSuccess)
        //    {
        //        await onsuccess();
        //    }
        //    else
        //    {
        //        await onfailure(r.Errors);
        //    }

        //    return r;
        //}

        //public static async Task<Result<TInput>> OnBothAsync<TInput>(this Task<Result<TInput>> result, Func<Task> onsuccess, Func<string[], Task> onfailure)
        //{
        //    if (onsuccess == null)
        //    {
        //        throw new ArgumentNullException(nameof(onsuccess));
        //    }

        //    if (onfailure == null)
        //    {
        //        throw new ArgumentNullException(nameof(onfailure));
        //    }

        //    var r = await result;

        //    if (r.IsSuccess)
        //    {
        //        await onsuccess();
        //    }
        //    else
        //    {
        //        await onfailure(r.Error);
        //    }

        //    return r;
        //}

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
