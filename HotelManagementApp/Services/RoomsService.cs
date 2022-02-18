using HotelManagementApp.Database;
using HotelManagementApp.Entities;
using HotelManagementApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace HotelManagementApp.Services
{
    public class RoomsService : IRoomsService
    {
        private readonly AppDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;

        public RoomsService(AppDbContext dbContext, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public RoomsModel GetRoom(string id)
        {
            int parsedId = int.Parse(id);

            IQueryable<RoomsEntity> rooms = _dbContext.Rooms;

            var room = rooms.Where(r => r.RoomNumber == parsedId).FirstOrDefault();

            var roomToPass = new RoomsModel
            {
                RoomNumber = room.RoomNumber,
                FullLocalization = RoomLocalization(room.Localization),
                IsUsable = room.IsUsable,
                NoOfSingleBeds = room.NoOfSingleBeds,
                NoOfDualBeds = room.NoOfDualBeds,
                NoOfBathrooms = room.NoOfBathrooms,
                CostPerNight = room.CostPerNight
            };
            return roomToPass;
        }

        public string RoomLocalization(int id)
        {
            string roomLocalization = string.Empty;

            IQueryable<LocalizationEntity> localizations = _dbContext.Localization;

            var localization = localizations.Where(l => l.Id == id).FirstOrDefault();
            roomLocalization = "Piętro: " + localization.Floor.ToString() + ", skrzydło: " + localization.Wing.ToString();

            return roomLocalization;
        }
    }
}
