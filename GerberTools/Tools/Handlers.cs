﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Polly;

namespace GerberTools.Tools
{
    internal static class Handlers
    {
        public static async Task DoWorkAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Action? finallyAction = null, bool shouldThrow = true)
        {
            try
            {
                await action(cancellationToken);
            }
            catch (Exception ex)
            {
                if (errorAction is not null)
                    errorAction(ex);

                if (shouldThrow)
                    throw;
            }
            finally
            {
                if (finallyAction is not null)
                    finallyAction();
            }
        }

        public static async Task DoWorkAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Action? finallyAction = null, bool shouldThrow = true)
        {
            try
            {
                await action(cancellationToken);
            }
            catch (Exception ex)
            {
                if (errorAction is not null)
                    await errorAction(ex, cancellationToken);

                if (shouldThrow)
                    throw;
            }
            finally
            {
                if (finallyAction is not null)
                    finallyAction();
            }
        }

        public static async Task DoWorkAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null, bool shouldThrow = true)
        {
            try
            {
                await action(cancellationToken);
            }
            catch (Exception ex)
            {
                if (errorAction is not null)
                    errorAction(ex);

                if (shouldThrow)
                    throw;
            }
            finally
            {
                if (finallyAction is not null)
                    await finallyAction(cancellationToken);
            }
        }

        public static async Task DoWorkAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null, bool shouldThrow = true)
        {
            try
            {
                await action(cancellationToken);
            }
            catch (Exception ex)
            {
                if (errorAction is not null)
                    await errorAction(ex, cancellationToken);

                if (shouldThrow)
                    throw;
            }
            finally
            {
                if (finallyAction is not null)
                    await finallyAction(cancellationToken);
            }
        }


        public static async Task<T?> DoWorkAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Action? finallyAction = null, bool shouldThrow = true)
        {
            try
            {
                return await action(cancellationToken);
            }
            catch (Exception ex)
            {
                if (errorAction is not null)
                    errorAction(ex);

                if (shouldThrow)
                    throw;
            }
            finally
            {
                if (finallyAction is not null)
                    finallyAction();
            }

            return default;
        }

        public static async Task<T?> DoWorkAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Action? finallyAction = null, bool shouldThrow = true)
        {
            try
            {
                return await action(cancellationToken);
            }
            catch (Exception ex)
            {
                if (errorAction is not null)
                    await errorAction(ex, cancellationToken);

                if (shouldThrow)
                    throw;
            }
            finally
            {
                if (finallyAction is not null)
                    finallyAction();
            }

            return default;
        }

        public static async Task<T?> DoWorkAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null, bool shouldThrow = true)
        {
            try
            {
                return await action(cancellationToken);
            }
            catch (Exception ex)
            {
                if (errorAction is not null)
                    errorAction(ex);

                if (shouldThrow)
                    throw;
            }
            finally
            {
                if (finallyAction is not null)
                    await finallyAction(cancellationToken);
            }

            return default;
        }

        public static async Task<T?> DoWorkAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null, bool shouldThrow = true)
        {
            try
            {
                return await action(cancellationToken);
            }
            catch (Exception ex)
            {
                if (errorAction is not null)
                    await errorAction(ex, cancellationToken);

                if (shouldThrow)
                    throw;
            }
            finally
            {
                if (finallyAction is not null)
                    await finallyAction(cancellationToken);
            }

            return default;
        }



        public static async Task RetryDoWorkAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Action? finallyAction = null, int retryCount = 3, IEnumerable<TimeSpan>? backoff = null, bool shouldThrow = true)
        {
            try
            {
                backoff ??= Backoff.Create();

                var retryPolicy = Policy
                    .Handle<Exception>()
                    .WaitAndRetryAsync(backoff, (ex, retryCount) =>
                    {
                        if (errorAction is not null)
                            errorAction(ex);
                    });


                await retryPolicy.ExecuteAsync(async () => await action(cancellationToken));
            }
            catch (Exception ex)
            {
                if (errorAction is not null)
                    errorAction(ex);

                if (shouldThrow)
                    throw;
            }
            finally
            {
                if (finallyAction is not null)
                    finallyAction();
            }
        }

        public static async Task RetryDoWorkAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Action? finallyAction = null, int retryCount = 3, IEnumerable<TimeSpan>? backoff = null, bool shouldThrow = true)
        {
            try
            {
                backoff ??= Backoff.Create();

                var retryPolicy = Policy
                    .Handle<Exception>()
                    .WaitAndRetryAsync(backoff, async (ex, retryCount) =>
                    {
                        if (errorAction is not null)
                            await errorAction(ex, cancellationToken);
                    });


                await retryPolicy.ExecuteAsync(async () => await action(cancellationToken));
            }
            catch (Exception ex)
            {
                if (errorAction is not null)
                    await errorAction(ex, cancellationToken);

                if (shouldThrow)
                    throw;
            }
            finally
            {
                if (finallyAction is not null)
                    finallyAction();
            }
        }

        public static async Task RetryDoWorkAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null, int retryCount = 3, IEnumerable<TimeSpan>? backoff = null, bool shouldThrow = true)
        {
            try
            {
                backoff ??= Backoff.Create();

                var retryPolicy = Policy
                    .Handle<Exception>()
                    .WaitAndRetryAsync(backoff, (ex, retryCount) =>
                    {
                        if (errorAction is not null)
                            errorAction(ex);
                    });


                await retryPolicy.ExecuteAsync(async () => await action(cancellationToken));
            }
            catch (Exception ex)
            {
                if (errorAction is not null)
                    errorAction(ex);

                if (shouldThrow)
                    throw;
            }
            finally
            {
                if (finallyAction is not null)
                    await finallyAction(cancellationToken);
            }
        }

        public static async Task RetryDoWorkAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null, int retryCount = 3, IEnumerable<TimeSpan>? backoff = null, bool shouldThrow = true)
        {
            try
            {
                backoff ??= Backoff.Create();

                var retryPolicy = Policy
                    .Handle<Exception>()
                    .WaitAndRetryAsync(backoff, async (ex, retryCount) =>
                    {
                        if (errorAction is not null)
                            await errorAction(ex, cancellationToken);
                    });


                await retryPolicy.ExecuteAsync(async () => await action(cancellationToken));
            }
            catch (Exception ex)
            {
                if (errorAction is not null)
                    await errorAction(ex, cancellationToken);

                if (shouldThrow)
                    throw;
            }
            finally
            {
                if (finallyAction is not null)
                    await finallyAction(cancellationToken);
            }
        }


        public static async Task<T?> RetryDoWorkAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Action? finallyAction = null, int retryCount = 3, IEnumerable<TimeSpan>? backoff = null, bool shouldThrow = true)
        {
            try
            {
                backoff ??= Backoff.Create();

                var retryPolicy = Policy
                    .Handle<Exception>()
                    .WaitAndRetryAsync(backoff, (ex, retryCount) =>
                    {
                        if (errorAction is not null)
                            errorAction(ex);
                    });


                return await retryPolicy.ExecuteAsync(async () => await action(cancellationToken));
            }
            catch (Exception ex)
            {
                if (errorAction is not null)
                    errorAction(ex);

                if (shouldThrow)
                    throw;
            }
            finally
            {
                if (finallyAction is not null)
                    finallyAction();
            }

            return default;
        }

        public static async Task<T?> RetryDoWorkAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Action? finallyAction = null, int retryCount = 3, IEnumerable<TimeSpan>? backoff = null, bool shouldThrow = true)
        {
            try
            {
                backoff ??= Backoff.Create();

                var retryPolicy = Policy
                    .Handle<Exception>()
                    .WaitAndRetryAsync(backoff, async (ex, retryCount) =>
                    {
                        if (errorAction is not null)
                            await errorAction(ex, cancellationToken);
                    });


                return await retryPolicy.ExecuteAsync(async () => await action(cancellationToken));
            }
            catch (Exception ex)
            {
                if (errorAction is not null)
                    await errorAction(ex, cancellationToken);

                if (shouldThrow)
                    throw;
            }
            finally
            {
                if (finallyAction is not null)
                    finallyAction();
            }

            return default;
        }

        public static async Task<T?> RetryDoWorkAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken, Action<Exception>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null, int retryCount = 3, IEnumerable<TimeSpan>? backoff = null, bool shouldThrow = true)
        {
            try
            {
                backoff ??= Backoff.Create();

                var retryPolicy = Policy
                    .Handle<Exception>()
                    .WaitAndRetryAsync(backoff, (ex, retryCount) =>
                    {
                        if (errorAction is not null)
                            errorAction(ex);
                    });


                return await retryPolicy.ExecuteAsync(async () => await action(cancellationToken));
            }
            catch (Exception ex)
            {
                if (errorAction is not null)
                    errorAction(ex);

                if (shouldThrow)
                    throw;
            }
            finally
            {
                if (finallyAction is not null)
                    await finallyAction(cancellationToken);
            }

            return default;
        }

        public static async Task<T?> RetryDoWorkAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken, Func<Exception, CancellationToken, Task>? errorAction = null, Func<CancellationToken, Task>? finallyAction = null, int retryCount = 3, IEnumerable<TimeSpan>? backoff = null, bool shouldThrow = true)
        {
            try
            {
                backoff ??= Backoff.Create();

                var retryPolicy = Policy
                    .Handle<Exception>()
                    .WaitAndRetryAsync(backoff, async (ex, retryCount) =>
                    {
                        if (errorAction is not null)
                            await errorAction(ex, cancellationToken);
                    });


                return await retryPolicy.ExecuteAsync(async () => await action(cancellationToken));
            }
            catch (Exception ex)
            {
                if (errorAction is not null)
                    await errorAction(ex, cancellationToken);

                if (shouldThrow)
                    throw;
            }
            finally
            {
                if (finallyAction is not null)
                    await finallyAction(cancellationToken);
            }

            return default;
        }
    }
}
