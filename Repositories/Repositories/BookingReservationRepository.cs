using DAL.Enities;
using DataAccessLayer.Models;
using Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class BookingReservationRepository : IBookingReservationRepository
    {
        public List<BookingReservation> GetBookingReservations() => BookingReservationDAO.GetBookingReservations();

        public void AddBookingReservation(BookingReservation booking) =>
                BookingReservationDAO.AddBookingReservation(booking);

        public BookingReservation GetBookingReservationById(int reservationId) =>
                BookingReservationDAO.GetBookingReservationById(reservationId);

        public void UpdateBookingReservation(BookingReservation booking)
        {
            var booked = BookingReservationDAO.GetBookingReservationById(booking.BookingReservationId);
            if (booked != null)
            {
                booked.TotalPrice = booking.TotalPrice;
                booked.BookingStatus = booking.BookingStatus;
            }
        }

    }
}
