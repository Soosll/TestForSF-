using Infrastructure.General;

namespace Infrastructure.Handlers.CoroutineHandler
{
    public class CoroutineRunnerHandler : ICoroutineRunnerHandler
    {
        public ICoroutineRunner CoroutineRunner { get;  set; }
    }
}