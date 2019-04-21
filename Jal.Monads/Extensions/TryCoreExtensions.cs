using System;

namespace Jal.Monads.Extensions
{
    public delegate Exceptional<T> Try<T>();

    public static class TryCoreExtensions
    {
        public static Try<T> AsTry<T>(this Func<T> func)
        {
            return () => Exceptional<T>.Return(func());
        }

        public static Exceptional<T> Run<T>(this Try<T> @try)
        {
            try
            {
                return @try();
            }
            catch (Exception e)
            {
                return Exceptional<T>.Return(e);
            }
        }


        public static Try<O> Bind<T, O>(this Try<T> @try, Func<T, Try<O>> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            Try<O> f = () => @try.Run().Match(t => func(t).Run(), exception => Exceptional<O>.Return(exception));
            
            return f;
        }

        public static Try<O> Map<T, O>(this Try<T> @try, Func<T, O> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            Try<O> f = () => @try.Run().Match(t => Exceptional<O>.Return(func(t)), exception => Exceptional<O>.Return(exception));

            return f;
        }

        public static R Match<T, R>(this Try<T> @try, Func<T, R> success, Func<Exception, R> failure)
        {
            if (success == null) throw new ArgumentNullException(nameof(success));

            if (failure == null) throw new ArgumentNullException(nameof(failure));

            var res = @try.Run();
            return res.HasException
                ? failure(res.Exception)
                : success(res.Value);
        }
    }
}
