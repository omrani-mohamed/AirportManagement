using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight : IService<Flight>
    {
        IList<Staff> GetStaff(int id);
        IList<Traveller> GetTravellers(Plane plane, DateTime date);
        public void DispalyNbrPassenger(DateTime startDate, DateTime endDate);
        public IEnumerable<Flight> SortFlights();
    }
}
