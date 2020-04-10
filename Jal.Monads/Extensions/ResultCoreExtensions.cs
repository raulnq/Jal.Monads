using System;

namespace Jal.Monads
{
    public static class ResultCoreExtensions
    {
        public static O Match<T, E, O>(this Result<T, E> result, Func<T, O> onsuccess, Func<E, O> onfailure)
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
                return onfailure(result.Error);
            }
        }

        public static Result<O, E> Bind<T, E, O>(this Result<T, E> result, Func<T, Result<O, E>> onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (result.IsSuccess)
            {
                return onsuccess(result.Content);
            }

            return result.Error;
        }

        public static Result<O, E> Map<T, E, O>(this Result<T, E> result, Func<T, O> onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (result.IsSuccess)
            {
                return onsuccess(result.Content);
            }

            return result.Error;
        }

        public static O Match<E, O>(this Result<E> result, Func<O> onsuccess, Func<E, O> onfailure)
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
                return onfailure(result.Error);
            }
        }

        public static Result<E> Bind<E>(this Result<E> result, Func<Result<E>> onsuccess)
        {
            if (onsuccess == null)
            {
                throw new ArgumentNullException(nameof(onsuccess));
            }

            if (result.IsSuccess)
            {
                return onsuccess();
            }

            return result.Error;
        }

        
    }
}
