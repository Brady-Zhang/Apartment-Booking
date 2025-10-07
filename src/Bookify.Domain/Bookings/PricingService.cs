using Bookify.Domain.Shared;
using EasyBook.Domain.Apartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Bookings
{
    public class PricingService
    {
        public PricingDetails CalculatePrice(Apartment apartment, DateRange period)
        {
            var currency = apartment.Price.Currency;
            
            var priceForPeriod = new Money(apartment.Price.Amount * period.LengthInDays, currency);

            // Calculate amenity upcharges
            decimal percentageUpCharge = 0;
            foreach (var amenity in apartment.Amenities)
            {
                percentageUpCharge += amenity switch
                {
                    Amenity.GardenView or Amenity.MountainView => 0.05m,
                    Amenity.AirConditioning => 0.1m,
                    Amenity.Parking => 0.01m,
                    _ => 0
                };
            }

            var amenityUpCharge = Money.Zero(currency);
            if (percentageUpCharge > 0)
            {
                amenityUpCharge = new Money(priceForPeriod.Amount * percentageUpCharge, currency);
            }

            var totalPrice = Money.Zero();
            totalPrice += priceForPeriod;
            if (!apartment.CleaningFee.IsZero())
            {
                totalPrice += apartment.CleaningFee;
            }
            totalPrice += amenityUpCharge;

            return new PricingDetails(priceForPeriod, apartment.CleaningFee, amenityUpCharge, totalPrice);
        }
    }
}
