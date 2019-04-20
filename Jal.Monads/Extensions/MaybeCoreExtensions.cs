using System;
using static Jal.Monads.Maybe;

namespace Jal.Monads.Extensions
{
    public static class MaybeCoreExtensions
    {
        public static Maybe<O> Bind<T,O>(this Maybe<T> maybe, Func<T, Maybe<O>> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            if (maybe.HasValue)
            {
                return func(maybe.Value);
            }

            return None<O>();
        }

        public static Maybe<O> Map<T, O>(this Maybe<T> maybe, Func<T, O> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            if (maybe.HasValue)
            {
                return func(maybe.Value);
            }

            return None<O>();
        }

        public static O Match<T, O>(this Maybe<T> maybe, Func<T, O> some, Func<O> none)
        {
            if (some == null)
            {
                throw new ArgumentNullException(nameof(some));
            }
            if (none == null)
            {
                throw new ArgumentNullException(nameof(none));
            }

            if (maybe.HasValue)
            {
                return some(maybe.Value);
            }
            else
            {
                return none();
            }
        }
    }

    
}
