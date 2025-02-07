using System.Security.Permissions;
using NoCqrs.DataAccess;
using ReEntry.WebAPI.Domain;

namespace ReEntry.WebAPI.DataAccess
{
    public class EFDataStore : IDataStore
    {
        private readonly InsuranceDbContext dbContext;
        private readonly IOfferRepository offerRepository;
        private readonly IProductRepository productRepository;
        //private readonly IPolicyRepository policyRepository;

        public IOfferRepository Offers => offerRepository;
        public IProductRepository Products => productRepository;
        //public IPolicyRepository Policies => policyRepository;

        public EFDataStore(InsuranceDbContext dbContext)
        {
            this.dbContext = dbContext;
            offerRepository = new EFOfferRepository(this.dbContext);
            productRepository = new EFProductRepository(this.dbContext);
            //policyRepository = new EFPolicyRepository(this.dbContext);
        }

        public void CommitChanges()
        {
            dbContext.SaveChanges();
        }
    }
}