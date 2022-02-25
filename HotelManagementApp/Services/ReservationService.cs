﻿using HotelManagementApp.Database;
using HotelManagementApp.Models;
using HotelManagementApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelManagementApp.Services
{
    public class ReservationService : IReservationService
    {
        private readonly AppDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;

        public ReservationService(AppDbContext dbContext, IHttpContextAccessor accessor, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _httpContextAccessor = accessor;
            _userManager = userManager;
        }

        public async Task Add(ReservationModel reservation)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            var entity = new ReservationsEntity
            {
                RoomId = reservation.RoomNumber,
                ReservationStart = reservation.ReservationStart,
                ReservationEnd = reservation.ReservationEnd,
                CustomerId = currentUser.Id,
                CustomerName = reservation.CustomerName,
                PhoneNumber = reservation.PhoneNumber
            };

            await _dbContext.Reservations.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReservationsEntity>> GetAll()
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            IQueryable<ReservationsEntity> reservationQuery = _dbContext.Reservations;
            reservationQuery = reservationQuery.Where(x => x.CustomerId == currentUser.Id);

            var reservations = await reservationQuery.ToListAsync();
            return reservations;
        }

        public async Task<string> GetUserPhone()
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            return currentUser.PhoneNumber;
        }

        public async Task RemoveReservation(string reservationData)
        {
            int parsedId = int.Parse(reservationData);

            _dbContext.Reservations.Remove(_dbContext.Reservations.Find(parsedId));
            await _dbContext.SaveChangesAsync();
        }

        public bool IsRoomAvaliableForReservation(ReservationModel reservation)
        {
            var currentReservation = _dbContext.Reservations
                .Where(x => x.RoomId == reservation.RoomNumber && (reservation.ReservationStart <= x.ReservationEnd && reservation.ReservationStart >= x.ReservationStart || x.ReservationStart <= reservation.ReservationEnd && x.ReservationStart >= reservation.ReservationStart))
                .FirstOrDefault();

            if(currentReservation != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsEndDateAfterStartDate(ReservationModel reservation)
        {
            if (reservation.ReservationEnd > reservation.ReservationStart)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
