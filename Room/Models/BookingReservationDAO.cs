using DAL.Enities;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class BookingReservationDAO
    {
        public static List<BookingReservation> GetBookingReservations()
        {
            var listBookingReservation = new List<BookingReservation>();
            try
            {
                using var context = new FuminiHotelManagementContext();
                listBookingReservation = context.BookingReservations.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listBookingReservation;
        }

    }
}
