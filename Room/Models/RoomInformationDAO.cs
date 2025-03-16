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
    public class RoomInformationDAO
    {
        public static List<RoomInformation> GetRoomInformations()
        {

            var listRoomInformation = new List<RoomInformation>();
            try
            {
                using var dbContext = new FuminiHotelManagementContext();
                listRoomInformation = dbContext.RoomInformations.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listRoomInformation;

        }

        public static RoomInformation GetRoomInformationById(int roomID)
        {
            try
            {
                using var dbContext = new FuminiHotelManagementContext();
                return dbContext.RoomInformations.SingleOrDefault(i => i.RoomId.Equals(roomID));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void SaveRoomInformation(RoomInformation roomInfo)
        {
            try
            {
                using var dbContext = new FuminiHotelManagementContext();
                dbContext.RoomInformations.Add(roomInfo);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateRoomInformation(RoomInformation roomInfo)
        {
            try
            {
                using var dbContext = new FuminiHotelManagementContext();
                dbContext.Entry<RoomInformation>(roomInfo).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteRoomInformation(RoomInformation roomInfo)
        {
            try
            {
                using var dbContext = new FuminiHotelManagementContext();
                var roomInfo1 =
                    dbContext.RoomInformations.SingleOrDefault(r => r.RoomId == roomInfo.RoomId);
                dbContext.RoomInformations.Remove(roomInfo1);

                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
