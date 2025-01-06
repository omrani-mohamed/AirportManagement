using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethods
    {
        IList<DateTime> GetFlightDatesLINQ(string destination);
        void ShowFlightDetails(Plane plane);
        int ProgrammedFlightNumber(DateTime startDate);
        float DurationAverage(string destination);
        IList<Flight> OrderedDurationFlights();
        //IList<Traveller> SeniorTravellers(Flight flight);
        IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights();

    }
}
