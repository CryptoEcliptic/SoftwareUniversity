using Panda.Data;
using Panda.Data.Models;
using System;
using System.Linq;

namespace Panda.Services
{
    public class ReceiptService : IReceiptsService
    {
        private const decimal FeeCoefficient = 2.67m;
        private readonly PandaDbContext context;
        private readonly IUsersService usersService;

        public ReceiptService(PandaDbContext context, IUsersService usersService)
        {
            this.context = context;
            this.usersService = usersService;
        }

        public void CreateReceipt(decimal weight, string recepientId, string packageId)
        {
            var receipt = new Receipt
            {
                IssuedOn = DateTime.UtcNow,
                Fee = weight * FeeCoefficient,
                PackageId = packageId,
                RecipientId = recepientId
            };

            context.Receipts.Add(receipt);
            context.SaveChanges();
        }

        public IQueryable<Receipt> GetAllReceipts()
        {
            var receipts = this.context.Receipts;
            return receipts;
        }
    }
}
