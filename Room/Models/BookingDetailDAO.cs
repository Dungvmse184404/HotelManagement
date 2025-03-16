using DAL;
using DAL.Enities;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class BookingDetailDAO
    {
        public static List<BookingDetail> GetBookingDetails()
        {
            var listBookingDetail = new List<BookingDetail>();
            try
            {
                using var context = new FuminiHotelManagementContext();
                listBookingDetail = context.BookingDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listBookingDetail;
        }

        public static BookingDetail? GetBookingDetailById(int bookingReservationId, int roomId)
        {
            using var dbContext = new FuminiHotelManagementContext();
            return dbContext.BookingDetails
                .FirstOrDefault(b => b.BookingReservationId == bookingReservationId && b.RoomId == roomId);
        }

        

    }
}
