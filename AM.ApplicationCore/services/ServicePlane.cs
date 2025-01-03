using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.services
{
    
    public class ServicePlane : Service<Plane>, IServicePlane
        
    {
        IUnitOfWork unitOfWork;
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IList<Passenger> GetPassengers(Plane plane)
        {
            return unitOfWork.Repository<Plane>().GetById(plane.PlaneId).Flights
                .SelectMany(f=>f.Tickets.Select(t=>t.MyPassenger)).ToList();
        }

        public IList<Flight> GetFlights(int n)
        {
         return GetAll().OrderByDescending(p=>p.PlaneId).Take(n).SelectMany(p=>p.Flights).OrderBy(f=>f.FlightDate).ToList();  
        }

        public bool IsFlighths(int n, Flight flight)
        {
           int capacity= flight.MyPlane.capacity;
            int nbrePlace = flight.Tickets.Count;
            return capacity-nbrePlace >= n;

        }

        public void DeleteOldPlanes()
        {
            var oldPlanes = GetMany(p=> p.ManufactureDate.Year-DateTime.Now.Year>10).ToList();
            foreach (var plane in oldPlanes)
            {
               Delete(plane);
            }
            unitOfWork.Save();
        }

       


    }
}
