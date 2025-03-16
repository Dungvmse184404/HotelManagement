using DAL.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface IBookingDetailRepository
    {
        List<BookingDetail> GetBookingDetails();
        BookingDetail? GetBookingDetailById(int bookingReservationId, int roomId);
    }
}
