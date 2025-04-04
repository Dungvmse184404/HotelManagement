using DAL.Enities;
using Microsoft.EntityFrameworkCore;
using Repositories.IRepositories;
using Repositories.Repositories;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class BookingReservationService : IBookingReservationService
    {
        private readonly IBookingReservationRepository _reservationRepository;

        public BookingReservationService()
        {
            _reservationRepository = new BookingReservationRepository();
        }

        public List<BookingReservation> GetBookingReservations()
            => _reservationRepository.GetBookingReservations();

        public void CreateBookingReservation(int customerId)
        {
            var booking = new BookingReservation
            {
                BookingDate = DateOnly.FromDateTime(DateTime.Now),
                CustomerId = customerId,
                BookingStatus = 1,
                TotalPrice = 0
            };
            _reservationRepository.AddBookingReservation(booking);
        }

        public void UpdateTotalPriceAsync(int bookingId, decimal totalPrice)
        {
            var booking = _reservationRepository.GetBookingReservationById(bookingId);
            if (booking != null)
            {
                booking.TotalPrice = totalPrice;
            }
            _reservationRepository.UpdateBookingReservation(booking);
        }

        
    }
}
