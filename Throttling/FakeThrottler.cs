using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Polygon.Data
{
    internal sealed class FakeThrottler : IThrottler
    {
#if NET45
        private static readonly Lazy<Task> _completedTask = new Lazy<Task>(() => Task.Run(() => {}));
#endif

        private FakeThrottler() { }

        public static IThrottler Instance { get; } = new FakeThrottler();

        public Int32 MaxRetryAttempts { get; } = 1;

#if NET45
        public Task WaitToProceed(CancellationToken _) => _completedTask.Value;
#else
        public Task WaitToProceed(CancellationToken _) => Task.CompletedTask;
#endif

        public Boolean CheckHttpResponse(HttpResponseMessage response) => true;
    }
}