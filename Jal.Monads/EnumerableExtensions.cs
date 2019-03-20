using System;
using System.Collections.Generic;

namespace Jal.Monads
{
    public static class EnumerableExtensions
    {
        //public static Result ForEach<TElement>(this IEnumerable<TElement> array, Func<TElement, Result> itemfunc)
        //{
        //    foreach (var element in array)
        //    {
        //        var result = itemfunc(element);

        //        if (result.IsFailure)
        //        {
        //            return result;
        //        }
        //    }

        //    return Result.Success();
        //}

        //public static Result<TContent> ForEach<TElement, TContent>(this IEnumerable<TElement> array, Func<TElement, Result> itemfunc, Func<TContent> endfunc)
        //{
        //    foreach (var element in array)
        //    {
        //        var result = itemfunc(element);

        //        if (result.IsFailure)
        //        {
        //            return Result.Failure<TContent>(result.Errors);
        //        }
        //    }

        //    return Result.Success<TContent>(endfunc());
        //}
    }
}