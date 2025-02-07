using Microsoft.EntityFrameworkCore;
using ReEntry.WebAPI;
using ReEntry.WebAPI.Domain;
using ReEntry.WebAPI.Models;

namespace NoCqrs.DataAccess
{
    public class EFOfferRepository : IOfferRepository
    {
        private readonly InsuranceDbContext dbContext;

        public EFOfferRepository(InsuranceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Offer WithNumber(string number)
        {
            return dbContext
                .Offers
                //.Include(o=>o.Covers).ThenInclude(c => c.Cover)
                //.Include(p => p.Product)
                .FirstOrDefault(o => o.Number == number);
        }

        public List<Offer> All()
        {
            return dbContext
                .Offers
                //.Include(o => o.Covers).ThenInclude(c => c.Cover)
                //.Include(p => p.Product)
                .ToList();
        }


        public void Add(Offer offer)
        {
            dbContext.Offers.Add(offer);
        }
    }
}