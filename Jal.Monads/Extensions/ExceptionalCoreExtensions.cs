using System;


namespace Jal.Monads
{
    public static class ExceptionalCoreExtensions
    {
        public static O Match<T, O>(this Exceptional<T> exceptional, Func<T, O> func, Func<Exception, O> exception)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            if (!exceptional.HasException)
            {
                return func(exceptional.Value);
            }
            else
            {
                return exception(exceptional.Exception);
            }
        }
    }
}
