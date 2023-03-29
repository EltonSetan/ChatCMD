namespace ChatCMD
{
    public interface IApiClient
    {
        Task<T> PostAsync<T>(string uri, object data);
    }
}
