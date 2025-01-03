using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.services
{
    public class ServiceFlight : Service<Flight>, IServiceFlight
    {
        IUnitOfWork unitOfWork;
        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IList<Staff> GetStaffs(int id)
        {
            return unitOfWork.Repository<Flight>().GetById(id).Tickets.
                Select(t => t.MyPassenger).OfType<Staff>().ToList();

        }

        public IList<Traveller> GetTravellers(Domain.Plane plane, DateTime date)
        {
            return plane.Flights.Where(f => f.FlightDate==date).
                SelectMany(f=>f.Tickets).Select(t=>t.MyPassenger).OfType<Traveller>().ToList();
        }

        public IEnumerable<Flight> SortFlights()
        {
            return GetAll().OrderByDescending(f => f.FlightDate);
        }


    }
}
