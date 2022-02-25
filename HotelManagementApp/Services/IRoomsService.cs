using HotelManagementApp.Entities;
using HotelManagementApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace HotelManagementApp.Services
{
    public interface IRoomsService
    {
        RoomsModel GetRoom(string id);
        string RoomLocalization(int id);
        Task Add(RoomsModel room);
        Task AddLocalization(LocalizationModel localization);
        SelectList GetAllLocalizations();
    }
}
