
using xperteam.model;

namespace xperteam.dal.Repositories.Contract
{
    public interface IInvoiceRepository : IGenericRepository<Invoice>
    {
        #region Methods Work Models
        Task<Invoice> Register(Invoice model);
        #endregion
    }
}
