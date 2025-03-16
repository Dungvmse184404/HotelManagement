using DAL;
using DAL.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class RoomTypeDAO
    {
        public static List<RoomType> GetRoomTypes()
        {
            var listRoomType = new List<RoomType>();
            try
            {
                using var dbContext = new FuminiHotelManagementContext();
                listRoomType = dbContext.RoomTypes.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listRoomType;

        }

        public static RoomType? GetRoomTypebyId(int roomTypeID)
        {
            using var dbContext = new FuminiHotelManagementContext();
            return dbContext.RoomTypes
                .FirstOrDefault(rt => rt.RoomTypeId == roomTypeID);
        }

    }
}
