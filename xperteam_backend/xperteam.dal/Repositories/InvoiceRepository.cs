using xperteam.dal.DBContext;
using xperteam.dal.Repositories.Contract;
using xperteam.model;

namespace xperteam.dal.Repositories
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        #region Properties
        private readonly XperteamContext _dbcontext;
        #endregion

        #region Constructor
        public InvoiceRepository(XperteamContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        #endregion

        #region Methods
        public async Task<Invoice> Register(Invoice model)
        {
            Invoice invoiceGenerated = new Invoice();
            using (var transaction = _dbcontext.Database.BeginTransaction())
            {
                try
                {
                }
                catch
                {

                    throw;
                }
                return invoiceGenerated;
            }
        }
        #endregion
    }
}
