using Bookify.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Bookings
{
    public static class BookingErrors
    {
        public static Error NotFound = new("Booking.NotFound", "The booking was not found.");

        public static Error Overlap = new("Booking.Overlap", "The booking overlaps with an existing booking.");

        public static Error NotReserved = new("Booking.NotReserved", "The booking is not in reserved status.");

        public static Error NotConfirmed = new("Booking.NotConfirmed", "The booking is not in confirmed status.");

        public static Error AlreadyStarted = new("Booking.AlreadyStarted", "The booking has already started.");
    }
}
