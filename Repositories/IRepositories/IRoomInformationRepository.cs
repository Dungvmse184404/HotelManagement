using DAL.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface IRoomInformationRepository
    {
        List<RoomInformation> GetRoomInformations();
        RoomInformation GetRoomInformationById(int roomID);
        void SaveRoomInformation(RoomInformation roomInfo);
        void UpdateRoomInformation(RoomInformation roomInfo);
        void DeleteRoomInformation(RoomInformation roomInfo);
        List<RoomInformation> SearchRooms(decimal? price, int? typeId, byte? status);
        //----------------RoomType--------------------
        List<RoomType> GetRoomTypes();
        RoomType? GetRoomTypebyId(int roomTypeID);
    }
}
