using HotelManagementApp.Models;

namespace HotelManagementApp.Services
{
    public interface IRoomsService
    {
        RoomsModel GetRoom(string id);
        string RoomLocalization(int id);
    }
}
