namespace Services.ForDispose
{
    public interface IDisposable
    {
        void Dispose();
        
        public bool NeedToClear { get; set; }
    }
}