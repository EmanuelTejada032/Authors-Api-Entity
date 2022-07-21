using Authors_Api.Entities;
using Authors_Api.Services.Interfaces;

namespace Authors_Api.Services
{
    public class AuthorServiceADO : IAuthorService
    {
        public AuthorServiceADO(AuthorServiceADODependency authorServiceAdoDependency)
        {

        }
        public void ExecuteTask()
        {

        }

        public List<Author> Get()
        {
            return new List<Author>();
        }

        public Guid GetScopedGuid()
        {
            throw new NotImplementedException();
        }

        public Guid GetSingletonGuid()
        {
            throw new NotImplementedException();
        }

        public Guid GetTransientGuid()
        {
            throw new NotImplementedException();
        }
    }

    public class AuthorServiceADODependency
    {
        public AuthorServiceADODependency(YetAnotherDependency oneMoreDependency)
        {

        }
    }

    public class YetAnotherDependency
    {

    }
}
