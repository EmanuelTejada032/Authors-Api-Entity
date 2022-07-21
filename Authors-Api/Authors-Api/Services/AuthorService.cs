using Authors_Api.Entities;
using Authors_Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Authors_Api.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly ILogger<AuthorService> logger;
        private readonly ApplicationDbContext context;
        private readonly TransientService transientService;
        private readonly ScopedService scopedService;
        private readonly SingletonService singletonService;

        public AuthorService(ILogger<AuthorService> logger, ApplicationDbContext context, TransientService transientService, ScopedService scopedService, SingletonService singletonService)
        {
            this.logger = logger;
            this.context = context;
            this.transientService = transientService;
            this.scopedService = scopedService;
            this.singletonService = singletonService;
        }
        public void ExecuteTask()
        {

        }

        //This is is a silly testing code
        public List<Author> Get()
        {
            logger.LogDebug("Debug message from author service");
            logger.LogCritical("Something wrong in the authors GET services");
            logger.LogInformation("Getting all Authors");
            logger.LogDebug("Debug message from author service");
            return context.Authors.Include(x => x.Books).ToList();
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
