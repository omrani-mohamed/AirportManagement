using AM.Application.Core.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Application.Core.Interfaces
{
    public interface IServicePlane : IService<Plane>
    {
        IList<Passenger> GetPassengers(Plane plane);
        IList<Flight> GetFlights(int n);
        bool AvailablePlane (int n, Flight flight);
        public void DeleteOldPlanes();
    }
}
