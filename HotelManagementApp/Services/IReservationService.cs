using HotelManagementApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelManagementApp.Entities;

namespace HotelManagementApp.Services
{
    public interface IReservationService
    {
        Task Add(ReservationModel reservation);
        Task<IEnumerable<ReservationsEntity>> GetAll();
        Task<string> GetUserPhone();
        void RemoveReservation(string reservationData);
    }
}
