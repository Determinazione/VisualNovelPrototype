namespace PlayerProgress
{
    public interface IDataSaver<T>
    {
        bool SaveDataToFiles(string path);
    }
}
