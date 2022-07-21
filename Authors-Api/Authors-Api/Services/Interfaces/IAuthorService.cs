using Authors_Api.Entities;

namespace Authors_Api.Services.Interfaces
{
    public interface IAuthorService
    {
        List<Author> Get();
        void ExecuteTask();
        Guid GetTransientGuid();

        Guid GetScopedGuid();
        Guid GetSingletonGuid();
    }
}
