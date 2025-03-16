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
    public class RoomInformationRepository : IRoomInformationRepository
    {
        public void DeleteRoomInformation(RoomInformation roomInfo) => RoomInformationDAO.DeleteRoomInformation(roomInfo);
        public RoomInformation GetRoomInformationById(int roomID) => RoomInformationDAO.GetRoomInformationById(roomID);
        public List<RoomInformation> GetRoomInformations() => RoomInformationDAO.GetRoomInformations();
        public void SaveRoomInformation(RoomInformation roomInfo) => RoomInformationDAO.SaveRoomInformation(roomInfo);
        public void UpdateRoomInformation(RoomInformation roomInfo)
        {
            var room = RoomInformationDAO.GetRoomInformationById(roomInfo.RoomId);
            if (room != null)
            {
                room.RoomNumber = roomInfo.RoomNumber;
                room.RoomTypeId = roomInfo.RoomTypeId;
                room.RoomStatus = roomInfo.RoomStatus;
                room.RoomPricePerDay = roomInfo.RoomPricePerDay;
                room.RoomMaxCapacity = roomInfo.RoomMaxCapacity;
                room.RoomDetailDescription = roomInfo.RoomDetailDescription;

                RoomInformationDAO.UpdateRoomInformation(room);
            }
        }
        
        public RoomType? GetRoomTypebyId(int roomTypeID) => RoomTypeDAO.GetRoomTypebyId(roomTypeID);
        public List<RoomType> GetRoomTypes() => RoomTypeDAO.GetRoomTypes();


        public List<RoomInformation> SearchRooms(decimal? price, int? typeId, byte? status)
            => RoomInformationDAO.GetRoomInformations()
                .Where(r => (!price.HasValue || r.RoomPricePerDay == price) &&
                            (!typeId.HasValue || r.RoomTypeId == typeId) &&
                            (!status.HasValue || r.RoomStatus == status))
                .ToList();
        
    }
}
