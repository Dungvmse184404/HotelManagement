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
    public class BookingDetailRepository : IBookingDetailRepository
    {
        public BookingDetail? GetBookingDetailById(int bookingReservationId, int roomId) => BookingDetailDAO.GetBookingDetailById(bookingReservationId, roomId);
        public List<BookingDetail> GetBookingDetails() => BookingDetailDAO.GetBookingDetails();
    }
}
