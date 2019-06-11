using Panda.Services;
using Panda.Web.ViewModels.Receipts;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.Web.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly IReceiptsService receiptService;

        public ReceiptsController(IReceiptsService receiptService)
        {
            this.receiptService = receiptService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var receipts = this.receiptService.GetAllReceipts()
                .Select(x => new ReceiptViewModel
                {
                    Id = x.Id,
                    Fee = x.Fee,
                    IssuedOn = x.IssuedOn,
                    Recipient = x.Recipient.Username

                }).ToList();

            return this.View(new ReceiptsListViewModel { Receipts = receipts });
        }
    }
}
