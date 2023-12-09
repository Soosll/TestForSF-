namespace Services.ForDispose
{
    public interface IDisposeService
    {
        void AddDisposableElement(IDisposable disposable);

        void RemoveDisposableElement(IDisposable disposable);
        
        void Dispose();
    }
}