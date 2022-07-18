using Authors_Api.Services.Interfaces;

namespace Authors_Api.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly ILogger<AuthorService> logger;
        private readonly TransientService transientService;
        private readonly ScopedService scopedService;
        private readonly SingletonService singletonService;

        public AuthorService(ILogger<AuthorService> logger, TransientService transientService, ScopedService scopedService, SingletonService singletonService)
        {
            this.logger = logger;
            this.transientService = transientService;
            this.scopedService = scopedService;
            this.singletonService = singletonService;
        }
        public void ExecuteTask()
        {

        }

        public Guid GetTransientGuid()
        {
            return transientService.Guid;
        }
        public Guid GetScopedGuid() 
        {
            return scopedService.Guid;
        }
        public Guid GetSingletonGuid() 
        {
            return singletonService.Guid;
        }
    }

    public class TransientService
    {
        public Guid Guid = Guid.NewGuid();
    } 
    public class ScopedService
    {
        public Guid Guid = Guid.NewGuid();
    }
    public class SingletonService
    {
        public Guid Guid = Guid.NewGuid();
    }
}
