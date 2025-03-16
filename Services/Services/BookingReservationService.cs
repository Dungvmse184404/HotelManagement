using DAL.Enities;
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
    }
}
