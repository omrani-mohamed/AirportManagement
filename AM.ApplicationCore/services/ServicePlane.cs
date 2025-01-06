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
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        IUnitOfWork unitOfWork;
        public ServicePlane(IUnitOfWork unityOfWork) : base(unityOfWork)
        {
            this.unitOfWork = unityOfWork;
        }
        public IList<Passenger> GetPassengers(Plane plane)
        {
            return unitOfWork.Repository<Plane>().GetById(plane.PlaneId)
                .Flights.SelectMany(f => f.Tickets.Select(t => t.MyPassenger))
                .ToList();
        }

        public IList<Flight> GetFlights(int n)
        {
            return GetAll().OrderByDescending(p => p.PlaneId).Take(n).
                SelectMany(p => p.Flights).OrderBy(f => f.FlightDate)
               .ToList();
        }
        public bool AvailablePlane(int n, Flight flight)
        {
            int capacity = flight.MyPlane.Capacity;
            int nbrPlace = flight.Tickets.Count;
            return (capacity - nbrPlace) >= n;
        }
        public void DeleteOldPlanes()
        {
            foreach (Plane plane in GetMany(p => DateTime.Now.Year - p.ManufactureDate.Year > 10))
            {
                Delete(plane);
            }
        }
    }
}

