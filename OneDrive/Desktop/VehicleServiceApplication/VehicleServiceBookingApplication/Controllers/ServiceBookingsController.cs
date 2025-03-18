using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleServiceBookingApplication.Data;
using VehicleServiceBookingApplication.Models;

namespace VehicleServiceBookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ServiceBookingsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ServiceBookingsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/ServiceBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceBookings>>> GetServiceBookings()
        {
          if (_context.ServiceBookings == null)
          {
              return NotFound();
          }
            return await _context.ServiceBookings.ToListAsync();
        }

        // GET: api/ServiceBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceBookings>> GetServiceBookings(int id)
        {
          if (_context.ServiceBookings == null)
          {
              return NotFound();
          }
            var serviceBookings = await _context.ServiceBookings.FindAsync(id);

            if (serviceBookings == null)
            {
                return NotFound();
            }

            return serviceBookings;
        }

        // PUT: api/ServiceBookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceBookings(int id, ServiceBookings serviceBookings)
        {
            if (id != serviceBookings.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(serviceBookings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceBookingsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ServiceBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceBookings>> PostServiceBookings(ServiceBookings serviceBookings)
        {
          if (_context.ServiceBookings == null)
          {
              return Problem("Entity set 'ApplicationDBContext.ServiceBookings'  is null.");
          }
            _context.ServiceBookings.Add(serviceBookings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceBookings", new { id = serviceBookings.BookingId }, serviceBookings);
        }

        // DELETE: api/ServiceBookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceBookings(int id)
        {
            if (_context.ServiceBookings == null)
            {
                return NotFound();
            }
            var serviceBookings = await _context.ServiceBookings.FindAsync(id);
            if (serviceBookings == null)
            {
                return NotFound();
            }

            _context.ServiceBookings.Remove(serviceBookings);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceBookingsExists(int id)
        {
            return (_context.ServiceBookings?.Any(e => e.BookingId == id)).GetValueOrDefault();
        }
    }
}
