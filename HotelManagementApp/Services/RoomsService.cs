using HotelManagementApp.Database;
using HotelManagementApp.Entities;
using HotelManagementApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public SelectList GetAllLocalizations()
        {
            RoomsModel rooms = new RoomsModel();

            List<SelectListItem> localizations = new List<SelectListItem>();

            var list = (from l in _dbContext.Localization
                        select new SelectListItem
                        {
                            Text = "Piętro: " + l.Floor.ToString() + " " + l.Wing,
                            Value = l.Id.ToString()
                        });
            
            foreach (var l in list)
            {
                localizations.Add(l);
            }

            SelectList output = new SelectList(localizations, "Value", "Text");
            return output;
        }

        public async Task Add(RoomsModel room)
        {
            var entity = new RoomsEntity
            {
                RoomNumber = room.RoomNumber,
                Localization = room.Localization,
                IsUsable = room.IsUsable,
                NoOfSingleBeds = room.NoOfSingleBeds,
                NoOfDualBeds = room.NoOfDualBeds,
                NoOfBathrooms = room.NoOfBathrooms,
                CostPerNight = room.CostPerNight
            };

            await _dbContext.Rooms.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddLocalization(LocalizationModel localization)
        {
            var entity = new LocalizationEntity
            {
                Wing = localization.Wing,
                Floor = localization.Floor
            };

            await _dbContext.Localization.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
