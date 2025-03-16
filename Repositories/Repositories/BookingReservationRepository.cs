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
        
    }
}
