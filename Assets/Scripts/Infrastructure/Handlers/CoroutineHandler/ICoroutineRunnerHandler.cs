using Infrastructure.General;

namespace Infrastructure.Handlers.CoroutineHandler
{
    public interface ICoroutineRunnerHandler
    {
        ICoroutineRunner CoroutineRunner { get; set; }
    }
}