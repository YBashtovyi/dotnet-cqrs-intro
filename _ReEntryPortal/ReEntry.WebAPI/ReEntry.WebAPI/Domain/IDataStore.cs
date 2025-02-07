namespace ReEntry.WebAPI.Domain
{
    public interface IDataStore
    {
        IProductRepository Products { get; }
        IOfferRepository Offers { get; }
        //IPolicyRepository Policies { get; }
        void CommitChanges();
    }
}