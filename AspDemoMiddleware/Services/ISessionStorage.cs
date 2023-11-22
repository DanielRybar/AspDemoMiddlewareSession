namespace AspDemoMiddleware.Services
{
    public interface ISessionStorage<T>
    {
        T? LoadOrCreate(string key); 
        void Save(string key, T value);
    }
}
