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
