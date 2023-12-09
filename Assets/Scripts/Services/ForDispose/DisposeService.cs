using System.Collections.Generic;
using UnityEngine;

namespace Services.ForDispose
{
    public class DisposeService : IDisposeService
    {
        private List<IDisposable> _disposables = new List<IDisposable>();

        public void AddDisposableElement(IDisposable disposable) =>
            _disposables.Add(disposable);

        public void RemoveDisposableElement(IDisposable disposable) =>
            _disposables.Remove(disposable);

        public void Dispose()
        {
            for (var i = _disposables.Count - 1; i >= 0; i--)
            {
                _disposables[i].Dispose();
            }
        }
    }
}