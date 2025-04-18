﻿using DAL.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IBookingReservationService
    {
        List<BookingReservation> GetBookingReservations();
        void CreateBookingReservation(int customerId);
        void UpdateTotalPriceAsync(int bookingId, decimal totalPrice);
    }
}
