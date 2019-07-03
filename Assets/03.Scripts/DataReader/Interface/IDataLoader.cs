namespace PlayerProgress
{
    public interface IDataLoader<T>
    {
        T LoadDataFromFiles(string path);
    }
}
