using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GerberTools.Tools
{
    public static class SafeHandlers
    {
        public static async Task DoWorkAsync(Func<CancellationToken, Task> action, Action<Exception>? errorAction = null, Action? finallyAction = null)
            => await DoWorkAsync(action, CancellationToken.None, errorAction, finallyAction);

        public static async Task DoWorkAsync(Func<CancellationToken, Task> action, Func<Exception, CancellationToken, Task>? errorAction = null, Action? finallyAction = null)
            => await DoWorkAsync(action, CancellationToken.None, errorAction, finallyAction);

        public static async Task DoWorkAsync(Func<CancellationToken, Task> action, Action<Exception>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null)
            => await DoWorkAsync(action, CancellationToken.None, errorAction, finallyAction);

        public static async Task DoWorkAsync(Func<CancellationToken, Task> action, Func<Exception, CancellationToken, Task>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null)
            => await DoWorkAsync(action, CancellationToken.None, errorAction, finallyAction);

        public static async Task DoWorkAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Action? finallyAction = null)
            => await Handlers.DoWorkAsync(action, cancellationToken, errorAction, finallyAction, false);

        public static async Task DoWorkAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Action? finallyAction = null)
            => await Handlers.DoWorkAsync(action, cancellationToken, errorAction, finallyAction, false);

        public static async Task DoWorkAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null)
            => await Handlers.DoWorkAsync(action, cancellationToken, errorAction, finallyAction, false);

        public static async Task DoWorkAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null)
            => await Handlers.DoWorkAsync(action, cancellationToken, errorAction, finallyAction, false);




        public static async Task<T?> DoWorkAsync<T>(Func<CancellationToken, Task<T>> action, Action<Exception>? errorAction = null, Action? finallyAction = null)
            => await DoWorkAsync(action, CancellationToken.None, errorAction, finallyAction);

        public static async Task<T?> DoWorkAsync<T>(Func<CancellationToken, Task<T>> action, Func<Exception, CancellationToken, Task>? errorAction = null, Action? finallyAction = null)
            => await DoWorkAsync(action, CancellationToken.None, errorAction, finallyAction);

        public static async Task<T?> DoWorkAsync<T>(Func<CancellationToken, Task<T>> action, Action<Exception>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null)
            => await DoWorkAsync(action, CancellationToken.None, errorAction, finallyAction);

        public static async Task<T?> DoWorkAsync<T>(Func<CancellationToken, Task<T>> action, Func<Exception, CancellationToken, Task>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null)
            => await DoWorkAsync(action, CancellationToken.None, errorAction, finallyAction);

        public static async Task<T?> DoWorkAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Action? finallyAction = null)
            => await Handlers.DoWorkAsync(action, cancellationToken, errorAction, finallyAction, false);

        public static async Task<T?> DoWorkAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Action? finallyAction = null)
            => await Handlers.DoWorkAsync(action, cancellationToken, errorAction, finallyAction, false);

        public static async Task<T?> DoWorkAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null)
            => await Handlers.DoWorkAsync(action, cancellationToken, errorAction, finallyAction, false);

        public static async Task<T?> DoWorkAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null)
            => await Handlers.DoWorkAsync(action, cancellationToken, errorAction, finallyAction, false);




        public static async Task RetryDoWorkAsync(Func<CancellationToken, Task> action, Action<Exception>? errorAction = null, Action? finallyAction = null, int retryCount = 3, IEnumerable<TimeSpan>? backoff = null)
            => await RetryDoWorkAsync(action, CancellationToken.None, errorAction, finallyAction, retryCount, backoff);

        public static async Task RetryDoWorkAsync(Func<CancellationToken, Task> action, Func<Exception, CancellationToken, Task>? errorAction = null, Action? finallyAction = null, int retryCount = 3, IEnumerable<TimeSpan>? backoff = null)
            => await RetryDoWorkAsync(action, CancellationToken.None, errorAction, finallyAction, retryCount, backoff);

        public static async Task RetryDoWorkAsync(Func<CancellationToken, Task> action, Action<Exception>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null, int retryCount = 3, IEnumerable<TimeSpan>? backoff = null)
            => await RetryDoWorkAsync(action, CancellationToken.None, errorAction, finallyAction, retryCount, backoff);

        public static async Task RetryDoWorkAsync(Func<CancellationToken, Task> action, Func<Exception, CancellationToken, Task>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null, int retryCount = 3, IEnumerable<TimeSpan>? backoff = null)
            => await RetryDoWorkAsync(action, CancellationToken.None, errorAction, finallyAction, retryCount, backoff);

        public static async Task RetryDoWorkAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Action? finallyAction = null, int retryCount = 3, IEnumerable<TimeSpan>? backoff = null)
            => await Handlers.RetryDoWorkAsync(action, cancellationToken, errorAction, finallyAction, retryCount, backoff, false);

        public static async Task RetryDoWorkAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Action? finallyAction = null, int retryCount = 3, IEnumerable<TimeSpan>? backoff = null)
            => await Handlers.RetryDoWorkAsync(action, cancellationToken, errorAction, finallyAction, retryCount, backoff, false);

        public static async Task RetryDoWorkAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null, int retryCount = 3, IEnumerable<TimeSpan>? backoff = null)
            => await Handlers.RetryDoWorkAsync(action, cancellationToken, errorAction, finallyAction, retryCount, backoff, false);

        public static async Task RetryDoWorkAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null, int retryCount = 3, IEnumerable<TimeSpan>? backoff = null)
            => await Handlers.RetryDoWorkAsync(action, cancellationToken, errorAction, finallyAction, retryCount, backoff, false);




        public static async Task<T?> RetryDoWorkAsync<T>(Func<CancellationToken, Task<T>> action, Action<Exception>? errorAction = null, Action? finallyAction = null, int retryCount = 3, IEnumerable<TimeSpan>? backoff = null)
            => await RetryDoWorkAsync(action, CancellationToken.None, errorAction, finallyAction, retryCount, backoff);

        public static async Task<T?> RetryDoWorkAsync<T>(Func<CancellationToken, Task<T>> action, Func<Exception, CancellationToken, Task>? errorAction = null, Action? finallyAction = null, int retryCount = 3, IEnumerable<TimeSpan>? backoff = null)
            => await RetryDoWorkAsync(action, CancellationToken.None, errorAction, finallyAction, retryCount, backoff);

        public static async Task<T?> RetryDoWorkAsync<T>(Func<CancellationToken, Task<T>> action, Action<Exception>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null, int retryCount = 3, IEnumerable<TimeSpan>? backoff = null)
            => await RetryDoWorkAsync(action, CancellationToken.None, errorAction, finallyAction, retryCount, backoff);

        public static async Task<T?> RetryDoWorkAsync<T>(Func<CancellationToken, Task<T>> action, Func<Exception, CancellationToken, Task>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null, int retryCount = 3, IEnumerable<TimeSpan>? backoff = null)
            => await RetryDoWorkAsync(action, CancellationToken.None, errorAction, finallyAction, retryCount, backoff);

        public static async Task<T?> RetryDoWorkAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Action? finallyAction = null, int retryCount = 3, IEnumerable<TimeSpan>? backoff = null)
            => await Handlers.RetryDoWorkAsync(action, cancellationToken, errorAction, finallyAction, retryCount, backoff, false);

        public static async Task<T?> RetryDoWorkAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Action? finallyAction = null, int retryCount = 3, IEnumerable<TimeSpan>? backoff = null)
            => await Handlers.RetryDoWorkAsync(action, cancellationToken, errorAction, finallyAction, retryCount, backoff, false);

        public static async Task<T?> RetryDoWorkAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null, int retryCount = 3, IEnumerable<TimeSpan>? backoff = null)
            => await Handlers.RetryDoWorkAsync(action, cancellationToken, errorAction, finallyAction, retryCount, backoff, false);

        public static async Task<T?> RetryDoWorkAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null, int retryCount = 3, IEnumerable<TimeSpan>? backoff = null)
            => await Handlers.RetryDoWorkAsync(action, cancellationToken, errorAction, finallyAction, retryCount, backoff, false);
    }
}
