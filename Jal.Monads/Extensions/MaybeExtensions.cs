using System;

namespace Jal.Monads.Extensions
{

    public static class MaybeExtensions
    {
        public static Maybe<T> AsMaybe<T, E>(this T value)
        {
            return value;
        }


        public static O Match<T, O>(this Maybe<T> maybe, Func<T, O> some, O @default=default)
        {
            return MaybeCoreExtensions.Match(maybe, some, () => @default);
        }
    }
}
