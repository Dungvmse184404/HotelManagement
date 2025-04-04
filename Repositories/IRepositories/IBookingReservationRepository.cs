using DAL.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface IBookingReservationRepository
    {
        List<BookingReservation> GetBookingReservations();
        BookingReservation GetBookingReservationById(int reservationId);
        void AddBookingReservation(BookingReservation booking);
        void UpdateBookingReservation(BookingReservation booking);
    }
}
