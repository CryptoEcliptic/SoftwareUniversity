using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FDMC.Domains;

namespace FDMC.Service
{
    public class CatsService : ICatsService
    {
        private readonly FDMCContext _context;

        public CatsService(FDMCContext context)
        {
            _context = context;
        }

        public IQueryable<Cat> GetAllCats()
        {
            var cats = this._context.Cat;

            return cats;
        }
    }
}
