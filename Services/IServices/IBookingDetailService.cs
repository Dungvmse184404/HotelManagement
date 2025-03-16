using DAL.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IBookingDetailService
    {
        List<BookingDetail> GetBookingDetails();
        BookingDetail? GetBookingDetailById(int bookingReservationId, int roomId);
    }
}
