using System;
using System.Collections.Generic;
using NoCqrs.Domain;

namespace NoCqrs.Init
{
    public class Offers
    {
        public static Offer StandardOneYearOCOfferValidUntil(Product product, string number, DateTime validityEnd)
        {
            return new Offer
            (
                Guid.NewGuid(), 
                number,
                product,
                Persons.Kowalski(),
                Persons.Kowalski(),
                Cars.OldFordFocus(),
                TimeSpan.FromDays(365), 
                //Money.Euro(500),
                500,
                validityEnd.AddDays(-30),
                new Dictionary<Cover, Decimal>()
                {
                    {
                        product.Covers.WithCode("OC"), 
                        500
                        //Money.Euro(500) 
                    }
                }
            );
        }

        public static Offer RejectedOfferValidUntil(Product product, string number, DateTime validityEnd)
        {
            var offer = StandardOneYearOCOfferValidUntil(product, number, validityEnd);
            offer.Reject();
            return offer;
        }
        
        public static Offer ConvertedOfferValidUntil(Product product, string number ,DateTime validityEnd)
        {
            var offer = StandardOneYearOCOfferValidUntil(product, number, validityEnd);
            offer.Convert();
            return offer;
        }
    }
}