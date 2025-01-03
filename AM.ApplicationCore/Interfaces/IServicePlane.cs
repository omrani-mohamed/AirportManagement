using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlane : IService<Plane>
    {
        IList<Passenger> GetPassengers(Plane plane);
         IList<Flight> GetFlights(int n);

        bool IsFlighths(int n, Flight flight);

        void DeleteOldPlanes();
       
    }
}
