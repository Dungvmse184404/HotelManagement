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

        public static BookingReservation GetBookingReservationById(int reservationId)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                return context.BookingReservations.FirstOrDefault(b => b.BookingReservationId == reservationId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void AddBookingReservation(BookingReservation booking)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                context.BookingReservations.Add(booking);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateBookingReservation(BookingReservation booking)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                context.Entry<BookingReservation>(booking).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteBookingReservation(BookingReservation booking)
        {
            try
            {
                using var context = new FuminiHotelManagementContext();
                var deleting = context.BookingReservations.FirstOrDefault(b => b.BookingReservationId == booking.BookingReservationId);
                context.BookingReservations.Remove(deleting);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
