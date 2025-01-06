using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : Service<Flight>, IServiceFlight
    {
        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        public IList<Staff> GetStaff(int id)
        {
            return GetById(id).Tickets
                .Select(t => t.MyPassenger)
                .OfType<Staff>()
                .ToList();
        }
        public IList<Traveller> GetTravellers(Plane plane, DateTime date)
        {
            return plane.Flights.Where(f => f.FlightDate == date)
                .SelectMany(f => f.Tickets)
                .Select(t => t.MyPassenger)
                .OfType<Traveller>()
                .ToList();
        }
        public void DispalyNbrPassenger(DateTime startDate, DateTime endDate)
        {
            var query = GetMany(f => f.FlightDate >= startDate
            && f.FlightDate <= endDate)
                .SelectMany(f => f.Tickets)
                .GroupBy(t => t.MyFlight.FlightDate)
                .Select(t => new { group = t.Key, count = t.Count() });

            foreach (var item in query)
            {
                Console.WriteLine("Date Vol = " + item.group
                    + " Nb Passenger = " + item.count);
            }
        }
        public IEnumerable<Flight> SortFlights()
        {
            return GetAll().OrderByDescending(f => f.FlightDate);
        }
    }
}

