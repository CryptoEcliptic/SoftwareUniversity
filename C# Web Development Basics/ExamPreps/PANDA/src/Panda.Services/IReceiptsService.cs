using Panda.Data.Models;
using System.Linq;

namespace Panda.Services
{
    public interface IReceiptsService
    {
        void CreateReceipt(decimal weight, string recepientId, string packageId);

        IQueryable<Receipt> GetAllReceipts();
    }
}
