using HotelManagementApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelManagementApp.Entities;
using System;

namespace HotelManagementApp.Services
{
    public interface IReservationService
    {
        Task Add(ReservationModel reservation);
        Task<IEnumerable<ReservationsEntity>> GetAll();
        Task<string> GetUserPhone();
        Task RemoveReservation(string reservationData);
        bool IsRoomAvaliableForReservation(ReservationModel reservation);
        bool IsEndDateAfterStartDate(ReservationModel reservation);
    }
}
