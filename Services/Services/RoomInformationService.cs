using DAL.Enities;
using Repositories.IRepositories;
using Repositories.Repositories;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class RoomInformationService : IRoomInformationService
    {
        private readonly IRoomInformationRepository _roomInformationRepository;
        public RoomInformationService()
        {
            _roomInformationRepository = new RoomInformationRepository();
        }

        public void DeleteRoomInformation(RoomInformation roomInfo)
            => _roomInformationRepository.DeleteRoomInformation(roomInfo);
        public RoomInformation GetRoomInformationById(int roomID)
            => _roomInformationRepository.GetRoomInformationById(roomID);
        public List<RoomInformation> GetRoomInformations()
            => _roomInformationRepository.GetRoomInformations();
        public void SaveRoomInformation(RoomInformation roomInfo)
        {
            ValidateRoomInformation(roomInfo);
            _roomInformationRepository.SaveRoomInformation(roomInfo);
        }
        public void UpdateRoomInformation(RoomInformation roomInfo)
        {
            //ValidateRoomInformation(roomInfo);
            _roomInformationRepository.UpdateRoomInformation(roomInfo);
        }

        public RoomType? GetRoomTypebyId(int roomTypeID)
            => _roomInformationRepository.GetRoomTypebyId(roomTypeID);
        public List<RoomType> GetRoomTypes()
            => _roomInformationRepository.GetRoomTypes();



        public RoomInformation ValidateRoomInformation(RoomInformation room)
        {
            var RoomList = _roomInformationRepository.GetRoomInformations();
            if (room == null)
                throw new ArgumentNullException(nameof(room), "Thông tin phòng không được null.");

            if (string.IsNullOrWhiteSpace(room.RoomNumber))
                throw new ArgumentException("Số phòng không được để trống.");
            if (room.RoomNumber.Length > 50)
                throw new ArgumentException("Số phòng tối đa 50 ký tự.");
            foreach (var r in RoomList)
            {
                if (r.RoomNumber == room.RoomNumber || r.RoomId == room.RoomId)
                    throw new ArgumentException("Số phòng đã tồn tại trong hệ thống.");
            }

            if (!string.IsNullOrWhiteSpace(room.RoomDetailDescription) && room.RoomDetailDescription.Length > 220)
                throw new ArgumentException("Mô tả phòng tối đa 220 ký tự.");

            if (room.RoomMaxCapacity <= 0)
                throw new ArgumentException("Sức chứa phòng phải là số nguyên dương.");

            if (room.RoomTypeId <= 0)
                throw new ArgumentException("Loại phòng không hợp lệ.");

            if (room.RoomStatus < 0 || room.RoomStatus > 1)
                throw new ArgumentException("Trạng thái phòng phải là 0 hoặc 1.");

            if (room.RoomPricePerDay < 0)
                throw new ArgumentException("Giá phòng phải là số dương.");

            return room;
        }

        public List<RoomInformation> SearchRooms(decimal? price, int? typeId, byte? status)
           => _roomInformationRepository.SearchRooms(price, typeId, status);


        //public void GenerateRoomId
    }
}
