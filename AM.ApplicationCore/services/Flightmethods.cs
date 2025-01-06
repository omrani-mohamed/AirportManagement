using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public Action<Plane> FlightDetailsDel;

        public Func<string, float> DurationAverageDel;

        public FlightMethods()
        {
            //FlightDetailsDel = ShowFlightDetails;
            //DurationAverageDel = DurationAverage;
            FlightDetailsDel = p =>
            {
                var req = from f in Flights
                          where f.MyPlane == p
                          select f;
                foreach (var v in req)
                {
                    Console.WriteLine("Flight Date : " + v.FlightDate + " Flight Destination : " + v.Destination);
                }
            };
            DurationAverageDel = d =>
            {
                return (from f in Flights
                        where f.Destination == d
                        select f.EstimatedDuration)
                          .Average();
            };
        }
        public List<Flight> Flights { get; set; } = new List<Flight> { };

        //public List<DateTime> GetFlightDates(string destination)
        //{
        //    List<DateTime> flightDates = new List<DateTime>();

        //    for (int i = 0; i < Flights.Count; i++)
        //    {
        //        if (Flights[i].Destination == destination)
        //        {
        //            flightDates.Add(Flights[i].FlightDate);
        //        }
        //    }
        //    return flightDates;
        //}
        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> flightDates = new List<DateTime>();

            foreach (var flight in Flights)
            {
                if (flight.Destination == destination)
                {
                    flightDates.Add(flight.FlightDate);
                }
            }

            return flightDates;
        }
        public List<Flight> GetFlights(string filterType, string filterValue)
        {
            List<Flight> filteredFlights = new List<Flight>();

            foreach (var flight in Flights)
            {
                switch (filterType)
                {
                    case "Destination":
                        if (flight.Destination.Equals(filterValue, StringComparison.OrdinalIgnoreCase))
                        {
                            filteredFlights.Add(flight);
                        }
                        break;

                    case "FlightDate":
                        if (DateTime.TryParse(filterValue, out DateTime flightDate) && flight.FlightDate.Date == flightDate.Date)
                        {
                            filteredFlights.Add(flight);
                        }
                        break;

                    case "EffectiveArrival":
                        if (DateTime.TryParse(filterValue, out DateTime effectiveArrival) && flight.EffectiveArrival.Date == effectiveArrival.Date)
                        {
                            filteredFlights.Add(flight);
                        }
                        break;

                    case "EstimatedDuration":
                        if (double.TryParse(filterValue, out double estimatedDuration) && flight.EstimatedDuration == estimatedDuration)
                        {
                            filteredFlights.Add(flight);
                        }
                        break;

                    case "MyPlane":
                        if (Enum.TryParse(filterValue, out PlaneType planeType) && flight.MyPlane.PlaneType == planeType)
                        {
                            filteredFlights.Add(flight);
                        }
                        break;

                    case "Capacity":
                        if (int.TryParse(filterValue, out int capacity) && flight.MyPlane.Capacity == capacity)
                        {
                            filteredFlights.Add(flight);
                        }
                        break;

                    case "ManufactureDate":
                        if (DateTime.TryParse(filterValue, out DateTime manufactureDate) && flight.MyPlane.ManufactureDate.Date == manufactureDate.Date)
                        {
                            filteredFlights.Add(flight);
                        }
                        break;

                    default:
                        break;
                }
            }

            return filteredFlights;
        }


        public IList<DateTime> GetFlightDatesLINQ(string destination)
        {
            //return Flights.Where(f => f.Destination.Equals(destination))
            //    .Select(f => f.FlightDate)
            //    .ToList();
            var req = Flights.Where(f => f.Destination == destination)
                .Select(f => f.FlightDate);
            return req.ToList();
        }
        public void ShowFlightDetails(Plane plane)
        {
            //var req = from f in Flights
            //          where f.MyPlane == plane
            //          select f;
            var req = Flights.Where(f => f.MyPlane == plane)
                .Select(f => f);
            foreach (var v in req)
            {
                Console.WriteLine("Flight Date : " + v.FlightDate + " Flight Destination : " + v.Destination);
            }
        }
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //var req = from f in Flights
            //          where DateTime.Compare(f.FlightDate, startDate) > 0
            //          && (f.FlightDate - startDate).TotalDays < 7
            //          select f;
            //return req.Count();
            var req = Flights.Where(f => DateTime.Compare(f.FlightDate, startDate) > 0)
                .Select(f => (f.FlightDate - startDate).TotalDays < 7)
                .Count();
            return req;
        }
        public float DurationAverage(string destination)
        {
            //var req = from f in Flights
            //          where f.Destination == destination
            //          select f.EstimatedDuration;
            //return req.Average();
            return Flights.Where(f => f.Destination == destination)
              .Select(f => f.EstimatedDuration)
              .Average();
        }
        public IList<Flight> OrderedDurationFlights()
        {
            //var req = from f in Flights
            //          orderby f.EstimatedDuration descending
            //          select f;

            //return req.ToList();
            return Flights.OrderByDescending(f => f.EstimatedDuration).ToList();
        }
        //public IList<Traveller> SeniorTravellers(Flight flight)
        //{
        //    //var req = from p in flight.Passengers.OfType<Traveller>()
        //    //          orderby p.BirthDate
        //    //          select p;

        //    //return req.Take(3).ToList();
        //    return flight.Passengers.OfType<Traveller>()
        //       .OrderBy(p => p.BirthDate)
        //       .Take(3)
        //       .ToList();
        //}
        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            //var req = from f in Flights
            //          group f by f.Destination;
            //foreach (var f in req)
            //{
            //    Console.WriteLine("Destination : " + f.Key);
            //    foreach(var f2 in f)
            //        Console.WriteLine("Decollage : " + f2.FlightDate);
            //}
            //return req;
            var groupedFlights = Flights.GroupBy(f => f.Destination);

            foreach (var group in groupedFlights)
            {
                Console.WriteLine("Destination : " + group.Key);
                foreach (var flight in group)
                {
                    Console.WriteLine("Decollage : " + flight.FlightDate);
                }
            }

            return groupedFlights;
        }
    }
}

