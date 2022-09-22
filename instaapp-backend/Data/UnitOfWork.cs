using instaapp_backend.Core.IConfiguration;
using Microsoft.AspNetCore.Identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace instaapp_backend.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly OTPContext _context;
        private readonly ILogger _logger;
        public ICodeServiceRepository Codes { get; private set; }

        public ICompanyAgreementRepository Agreement { get; private set; }

        public ICompanyRepository Companis { get; private set; }

        public ILogTransactionRepository Logs { get; private set; }
        public IServiceRepository Services { get; private set; }

        public ISupplierRepository Suppliers { get; private set; }

        public UnitOfWork(OTPContext context, ILoggerFactory logger, IPasswordHasher<Company> passwordHasher, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _logger = logger.CreateLogger("logs");

            Codes = new CodeServiceRepository(context, _logger);
            Agreement = new CompanyAgreementRepository(context, _logger);
            Companis = new CompanyRepository(context, _logger, passwordHasher, httpClientFactory);
            Logs = new LogTransactionRepository(context, _logger, httpClientFactory);
            Services = new ServiceRepository(context, _logger);
            Suppliers = new SupplierRepository(context, _logger);

        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
