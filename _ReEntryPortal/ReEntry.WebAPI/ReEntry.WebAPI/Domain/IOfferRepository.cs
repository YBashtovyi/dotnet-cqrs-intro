using ReEntry.WebAPI.Models;

namespace ReEntry.WebAPI.Domain
{
    public interface IOfferRepository
    {
        Offer WithNumber(string number);

        List<Offer> All();

        void Add(Offer offer);
    }
}