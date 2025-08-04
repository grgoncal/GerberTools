using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GerberTools.Tools
{
    public static class UnsafeHandlers
    {
        public static void DoWork(Action action, Action<Exception>? errorAction = null, Action? finallyAction = null)
            => Handlers.DoWork(
                action,
                errorAction,
                finallyAction,
                true);

        public static async Task DoWork(Action action, Func<Exception, Task>? errorAction = null, Action? finallyAction = null)
            => await DoWork(
                action,
                CancellationToken.None,
                errorAction is not null ? new Func<Exception, CancellationToken, Task>((e, ct) => errorAction(e)) : null,
                finallyAction);

        public static async Task DoWork(Action action, Action<Exception>? errorAction = null, Func<Task>? finallyAction = null)
            => await DoWork(
                action,
                CancellationToken.None,
                errorAction,
                finallyAction is not null ? new Func<CancellationToken, Task>((_) => finallyAction()) : null);

        public static async Task DoWork(Action action, Func<Exception, Task>? errorAction = null, Func<Task>? finallyAction = null)
            => await DoWork(
                action,
                CancellationToken.None,
                errorAction is not null ? new Func<Exception, CancellationToken, Task>((e, ct) => errorAction(e)) : null,
                finallyAction is not null ? new Func<CancellationToken, Task>((_) => finallyAction()) : null);

        public static async Task DoWork(Action action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Action? finallyAction = null)
            => await Handlers.DoWork(action, cancellationToken, errorAction, finallyAction, true);

        public static async Task DoWork(Action action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null)
            => await Handlers.DoWork(action, cancellationToken, errorAction, finallyAction, true);

        public static async Task DoWork(Action action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null)
            => await Handlers.DoWork(action, cancellationToken, errorAction, finallyAction, true);

        public static T? DoWork<T>(Func<T> action, Action<Exception>? errorAction = null, Action? finallyAction = null)
            => Handlers.DoWork(
                   action,
                   errorAction,
                   finallyAction,
                   true);

        public static async Task<T?> DoWork<T>(Func<T> action, Func<Exception, Task>? errorAction = null, Action? finallyAction = null)
            => await DoWork(
                action,
                CancellationToken.None,
                errorAction is not null ? new Func<Exception, CancellationToken, Task>((e, _) => errorAction(e)) : null,
                finallyAction);

        public static async Task<T?> DoWork<T>(Func<T> action, Action<Exception>? errorAction = null, Func<Task>? finallyAction = null)
            => await DoWork(
                action,
                CancellationToken.None,
                errorAction,
                finallyAction is not null ? new Func<CancellationToken, Task>((_) => finallyAction()) : null);

        public static async Task<T?> DoWork<T>(Func<T> action, Func<Exception, Task>? errorAction = null, Func<Task>? finallyAction = null)
            => await DoWork(
                action,
                CancellationToken.None,
                errorAction is not null ? new Func<Exception, CancellationToken, Task>((e, _) => errorAction(e)) : null,
                finallyAction is not null ? new Func<CancellationToken, Task>((_) => finallyAction()) : null);


        public static async Task<T?> DoWork<T>(Func<T> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Action? finallyAction = null)
            => await Handlers.DoWork(action, cancellationToken, errorAction, finallyAction, true);

        public static async Task<T?> DoWork<T>(Func<T> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null)
            => await Handlers.DoWork(action, cancellationToken, errorAction, finallyAction, true);

        public static async Task<T?> DoWork<T>(Func<T> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null)
            => await Handlers.DoWork(action, cancellationToken, errorAction, finallyAction, true);

        public static void RetryDoWork(Action action, Action<Exception>? errorAction = null, Action? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => Handlers.RetryDoWork(
                   action,
                   errorAction,
                   finallyAction,
                   backoff,
                   executeErrorInsidePollyRetry,
                   true);

        public static async Task RetryDoWork(Action action, Func<Exception, Task>? errorAction = null, Action? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await RetryDoWork(
                action,
                CancellationToken.None,
                errorAction is not null ? new Func<Exception, CancellationToken, Task>((e, _) => errorAction(e)) : null,
                finallyAction,
                backoff,
                executeErrorInsidePollyRetry);

        public static async Task RetryDoWork(Action action, Action<Exception>? errorAction = null, Func<Task>? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await RetryDoWork(
                action,
                CancellationToken.None,
                errorAction,
                finallyAction is not null ? new Func<CancellationToken, Task>((_) => finallyAction()) : null,
                backoff,
                executeErrorInsidePollyRetry);

        public static async Task RetryDoWork(Action action, Func<Exception, Task>? errorAction = null, Func<Task>? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await RetryDoWork(
                action,
                CancellationToken.None,
                errorAction is not null ? new Func<Exception, CancellationToken, Task>((e, _) => errorAction(e)) : null,
                finallyAction is not null ? new Func<CancellationToken, Task>((_) => finallyAction()) : null,
                backoff,
                executeErrorInsidePollyRetry);

        public static async Task RetryDoWork(Action action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Action? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await Handlers.RetryDoWork(action, cancellationToken, errorAction, finallyAction, backoff, executeErrorInsidePollyRetry, true);

        public static async Task RetryDoWork(Action action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await Handlers.RetryDoWork(action, cancellationToken, errorAction, finallyAction, backoff, executeErrorInsidePollyRetry, true);

        public static async Task RetryDoWork(Action action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await Handlers.RetryDoWork(action, cancellationToken, errorAction, finallyAction, backoff, executeErrorInsidePollyRetry, true);



        public static T? RetryDoWork<T>(Func<T> action, Action<Exception>? errorAction = null, Action? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => Handlers.RetryDoWork(
                action,
                errorAction,
                finallyAction,
                backoff,
                executeErrorInsidePollyRetry,
                true);

        public static async Task<T?> RetryDoWork<T>(Func<T> action, Func<Exception, Task>? errorAction = null, Action? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await RetryDoWork(
                action,
                CancellationToken.None,
                errorAction is not null ? new Func<Exception, CancellationToken, Task>((e, _) => errorAction(e)) : null,
                finallyAction,
                backoff,
                executeErrorInsidePollyRetry);

        public static async Task<T?> RetryDoWork<T>(Func<T> action, Action<Exception>? errorAction = null, Func<Task>? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await RetryDoWork(
                action,
                CancellationToken.None,
                errorAction,
                finallyAction is not null ? new Func<CancellationToken, Task>((_) => finallyAction()) : null,
                backoff,
                executeErrorInsidePollyRetry);

        public static async Task<T?> RetryDoWork<T>(Func<T> action, Func<Exception, Task>? errorAction = null, Func<Task>? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await RetryDoWork(
                action,
                CancellationToken.None,
                errorAction is not null ? new Func<Exception, CancellationToken, Task>((e, _) => errorAction(e)) : null,
                finallyAction is not null ? new Func<CancellationToken, Task>((_) => finallyAction()) : null,
                backoff,
                executeErrorInsidePollyRetry);

        public static async Task<T?> RetryDoWork<T>(Func<T> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Action? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await Handlers.RetryDoWork(action, cancellationToken, errorAction, finallyAction, backoff, executeErrorInsidePollyRetry, true);

        public static async Task<T?> RetryDoWork<T>(Func<T> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await Handlers.RetryDoWork(action, cancellationToken, errorAction, finallyAction, backoff, executeErrorInsidePollyRetry, true);

        public static async Task<T?> RetryDoWork<T>(Func<T> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await Handlers.RetryDoWork(action, cancellationToken, errorAction, finallyAction, backoff, executeErrorInsidePollyRetry, true);

        public static async Task DoWorkAsync(Func<Task> action, Action<Exception>? errorAction = null, Action? finallyAction = null)
            => await DoWorkAsync(
                _ => action(),
                CancellationToken.None, 
                errorAction,
                finallyAction);

        public static async Task DoWorkAsync(Func<Task> action, Func<Exception, Task>? errorAction = null, Action? finallyAction = null)
            => await DoWorkAsync(
                _ => action(),
                CancellationToken.None,
                errorAction is not null ? new Func<Exception, CancellationToken, Task>((e, _) => errorAction(e)) : null,
                finallyAction);

        public static async Task DoWorkAsync(Func<Task> action, Action<Exception>? errorAction = null, Func<Task>? finallyAction = null)
            => await DoWorkAsync(
                _ => action(),
                CancellationToken.None, 
                errorAction,
                finallyAction is not null ? new Func<CancellationToken, Task>((_) => finallyAction()) : null);

        public static async Task DoWorkAsync(Func<Task> action, Func<Exception, Task>? errorAction = null, Func<Task>? finallyAction = null)
            => await DoWorkAsync(
                _ => action(),
                CancellationToken.None,
                errorAction is not null ? new Func<Exception, CancellationToken, Task>((e, _) => errorAction(e)) : null,
                finallyAction is not null ? new Func<CancellationToken, Task>((_) => finallyAction()) : null);

        public static async Task DoWorkAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Action? finallyAction = null)
            => await Handlers.DoWorkAsync(action, cancellationToken, errorAction, finallyAction, true);

        public static async Task DoWorkAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Action? finallyAction = null)
            => await Handlers.DoWorkAsync(action, cancellationToken, errorAction, finallyAction, true);

        public static async Task DoWorkAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null)
            => await Handlers.DoWorkAsync(action, cancellationToken, errorAction, finallyAction, true);

        public static async Task DoWorkAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null)
            => await Handlers.DoWorkAsync(action, cancellationToken, errorAction, finallyAction, true);



        public static async Task<T?> DoWorkAsync<T>(Func<Task<T>> action, Action<Exception>? errorAction = null, Action? finallyAction = null)
            => await DoWorkAsync(
                _ => action(),
                CancellationToken.None,
                errorAction, 
                finallyAction);

        public static async Task<T?> DoWorkAsync<T>(Func<Task<T>> action, Func<Exception, Task>? errorAction = null, Action? finallyAction = null)
            => await DoWorkAsync(
                _ => action(),
                CancellationToken.None,
                errorAction is not null ? new Func<Exception, CancellationToken, Task>((e, _) => errorAction(e)) : null,
                finallyAction);

        public static async Task<T?> DoWorkAsync<T>(Func<Task<T>> action, Action<Exception>? errorAction = null, Func<Task>? finallyAction = null)
            => await DoWorkAsync(
                _ => action(),
                CancellationToken.None,
                errorAction,
                finallyAction is not null ? new Func<CancellationToken, Task>((_) => finallyAction()) : null);

        public static async Task<T?> DoWorkAsync<T>(Func<Task<T>> action, Func<Exception, Task>? errorAction = null, Func<Task>? finallyAction = null)
            => await DoWorkAsync(
                _ => action(),
                CancellationToken.None,
                errorAction is not null ? new Func<Exception, CancellationToken, Task>((e, _) => errorAction(e)) : null,
                finallyAction is not null ? new Func<CancellationToken, Task>((_) => finallyAction()) : null);

        public static async Task<T?> DoWorkAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Action? finallyAction = null)
            => await Handlers.DoWorkAsync(action, cancellationToken, errorAction, finallyAction, true);

        public static async Task<T?> DoWorkAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Action? finallyAction = null)
            => await Handlers.DoWorkAsync(action, cancellationToken, errorAction, finallyAction, true);

        public static async Task<T?> DoWorkAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null)
            => await Handlers.DoWorkAsync(action, cancellationToken, errorAction, finallyAction, true);

        public static async Task<T?> DoWorkAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null)
            => await Handlers.DoWorkAsync(action, cancellationToken, errorAction, finallyAction, true);



        public static async Task RetryDoWorkAsync(Func<Task> action, Action<Exception>? errorAction = null, Action? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await RetryDoWorkAsync(
                _ => action(),
                CancellationToken.None,
                errorAction,
                finallyAction, 
                backoff,
                executeErrorInsidePollyRetry);

        public static async Task RetryDoWorkAsync(Func<Task> action, Func<Exception, Task>? errorAction = null, Action? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await RetryDoWorkAsync(
                _ => action(),
                CancellationToken.None,
                errorAction is not null ? new Func<Exception, CancellationToken, Task>((e, _) => errorAction(e)) : null,
                finallyAction, 
                backoff,
                executeErrorInsidePollyRetry);

        public static async Task RetryDoWorkAsync(Func<Task> action, Action<Exception>? errorAction = null, Func<Task>? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await RetryDoWorkAsync(
                _ => action(),
                CancellationToken.None,
                errorAction,
                finallyAction is not null ? new Func<CancellationToken, Task>((_) => finallyAction()) : null, 
                backoff,
                executeErrorInsidePollyRetry);

        public static async Task RetryDoWorkAsync(Func<Task> action, Func<Exception, Task>? errorAction = null, Func<Task>? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await RetryDoWorkAsync(
                _ => action(),
                CancellationToken.None,
                errorAction is not null ? new Func<Exception, CancellationToken, Task>((e, _) => errorAction(e)) : null,
                finallyAction is not null ? new Func<CancellationToken, Task>((_) => finallyAction()) : null, 
                backoff,
                executeErrorInsidePollyRetry);

        public static async Task RetryDoWorkAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Action? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await Handlers.RetryDoWorkAsync(action, cancellationToken, errorAction, finallyAction, backoff, executeErrorInsidePollyRetry, true);

        public static async Task RetryDoWorkAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Action? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await Handlers.RetryDoWorkAsync(action, cancellationToken, errorAction, finallyAction, backoff, executeErrorInsidePollyRetry, true);

        public static async Task RetryDoWorkAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await Handlers.RetryDoWorkAsync(action, cancellationToken, errorAction, finallyAction, backoff, executeErrorInsidePollyRetry, true);

        public static async Task RetryDoWorkAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await Handlers.RetryDoWorkAsync(action, cancellationToken, errorAction, finallyAction, backoff, executeErrorInsidePollyRetry, true);


        public static async Task<T?> RetryDoWorkAsync<T>(Func<Task<T>> action, Action<Exception>? errorAction = null, Action? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await RetryDoWorkAsync(_ => action(), 
                CancellationToken.None,
                errorAction, 
                finallyAction, 
                backoff,
                executeErrorInsidePollyRetry);

        public static async Task<T?> RetryDoWorkAsync<T>(Func<Task<T>> action, Func<Exception, Task>? errorAction = null, Action? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await RetryDoWorkAsync(
                _ => action(), 
                CancellationToken.None,
                errorAction is not null ? new Func<Exception, CancellationToken, Task>((e, _) => errorAction(e)) : null,
                finallyAction, 
                backoff,
                executeErrorInsidePollyRetry);

        public static async Task<T?> RetryDoWorkAsync<T>(Func<Task<T>> action, Action<Exception>? errorAction = null, Func<Task>? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await RetryDoWorkAsync(
                _ => action(), 
                CancellationToken.None,
                errorAction, 
                finallyAction is not null ? new Func<CancellationToken, Task>((_) => finallyAction()) : null,
                backoff,
                executeErrorInsidePollyRetry);

        public static async Task<T?> RetryDoWorkAsync<T>(Func<Task<T>> action, Func<Exception, Task>? errorAction = null, Func<Task>? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await RetryDoWorkAsync(
                _ => action(), 
                CancellationToken.None, errorAction is not null ? new Func<Exception, CancellationToken, Task>((e, _) => errorAction(e)) : null,
                finallyAction is not null ? new Func<CancellationToken, Task>((_) => finallyAction()) : null,
                backoff,
                executeErrorInsidePollyRetry);

        public static async Task<T?> RetryDoWorkAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Action? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await Handlers.RetryDoWorkAsync(action, cancellationToken, errorAction, finallyAction, backoff, executeErrorInsidePollyRetry, true);

        public static async Task<T?> RetryDoWorkAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Action? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await Handlers.RetryDoWorkAsync(action, cancellationToken, errorAction, finallyAction, backoff, executeErrorInsidePollyRetry, true);

        public static async Task<T?> RetryDoWorkAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await Handlers.RetryDoWorkAsync(action, cancellationToken, errorAction, finallyAction, backoff, executeErrorInsidePollyRetry, true);

        public static async Task<T?> RetryDoWorkAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null, IEnumerable<TimeSpan>? backoff = null, bool executeErrorInsidePollyRetry = false)
            => await Handlers.RetryDoWorkAsync(action, cancellationToken, errorAction, finallyAction, backoff, executeErrorInsidePollyRetry, true);
    }
}
