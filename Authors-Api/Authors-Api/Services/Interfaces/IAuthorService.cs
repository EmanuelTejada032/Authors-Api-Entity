namespace Authors_Api.Services.Interfaces
{
    public interface IAuthorService
    {
        void ExecuteTask();
        Guid GetTransientGuid();

        Guid GetScopedGuid();
        Guid GetSingletonGuid();
    }
}
