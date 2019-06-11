using Panda.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.Services
{
    public interface IReceiptsService
    {
        void CreateReceipt(decimal weight, string recepientId, string packageId);

        IQueryable<Receipt> GetAllReceipts();
    }
}
