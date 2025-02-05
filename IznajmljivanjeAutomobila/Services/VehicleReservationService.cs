using IznajmljivanjeAutomobila.Data;
using IznajmljivanjeAutomobila.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IznajmljivanjeAutomobila.Services
{
    public class VehicleReservationService
    {
        private readonly ApplicationDbContext _context;

        // Konstruktor za injektovanje AppDbContext
        public VehicleReservationService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Metod za dodavanje rezervacije u bazu
        public async Task AddReservationAsync(VehicleReservation reservation)
        {
            _context.VehicleReservations.Add(reservation);
            await _context.SaveChangesAsync();
        }

        // Metod za dobijanje svih rezervacija iz baze
        public async Task<List<VehicleReservation>> GetAllReservationsAsync()
        {
            return await _context.VehicleReservations.ToListAsync();
        }
    }
}
