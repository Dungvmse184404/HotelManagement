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
    public class BookingDetailService : IBookingDetailService
    {
        private readonly IBookingDetailRepository _detailRepository;

        public BookingDetailService()
        {
            _detailRepository = new BookingDetailRepository();
        }

        public BookingDetail? GetBookingDetailById(int bookingReservationId, int roomId)
            => _detailRepository.GetBookingDetailById(bookingReservationId, roomId);

        public List<BookingDetail> GetBookingDetails()
            => _detailRepository.GetBookingDetails();
    }
}
