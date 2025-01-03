using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.services
{
    public class Flightmethods : IFlightMethods
    {
        public Action<Plane> FlightDetailsDel;
        public Func<string, float> DurationAverageDel;
        public Flightmethods()
        {


           /* 
            FlightDetailsDel  = ShowFlightDetails2;
            DurationAverageDel  = DurationAverage;
            */
            FlightDetailsDel = p =>
            {
                var req = from f in Flights
                          where f.MyPlane == p
                          select new { f.Destination, f.FlightDate };
                foreach (var f in req)
                    Console.WriteLine(f);
            };

            DurationAverageDel = destination =>
            {
                int nbr = 0;

                var test = from f in Flights
                           where f.Destination == destination
                           select f.EstimatedDuration;

                return test.Average();
            };
            
        }

        public List<Flight> Flights { get; set; }=new List<Flight>(); 
        
       /* public List<DateTime> GetFlightDates(string destination) {

            List<DateTime> flightDates = new List<DateTime>();

           
            for (int i = 0; i < Flights.Count; i++)
            {
               
                if (Flights[i].Destination.Equals(destination, StringComparison.OrdinalIgnoreCase))
                {
                   
                    flightDates.Add(Flights[i].FlightDate);
                }
            }

            return flightDates;


        }*/

       public List<DateTime> GetFlightDates(string destination)
        {

            List<DateTime> flightDates = new List<DateTime>();

            foreach (Flight f in Flights)
            {
                
                if (f.Destination == destination)
                {
                    flightDates.Add(f.FlightDate);
                }
            }

            return flightDates;


        }


        //9
        public IEnumerable<DateTime> GetFlightDates2(string destination)
        {

            /*IEnumerable<DateTime> result = new List<DateTime>();

            result = from f in Flights
                     where f.Destination == destination
                     select f.FlightDate;
            return result;*/

            var reqlambda=Flights.Where(f => f.Destination == destination).Select(f => f.FlightDate);
            return reqlambda;


        }


        //8
        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.Destination == filterValue)
                            Console.WriteLine(flight.ToString());
                    }
                    break;

                case "Departure":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.Departure == filterValue)
                            Console.WriteLine(flight.ToString());
                    }
                    break;

                case "FlightId":
                    if (int.TryParse(filterValue, out int flightId))
                    {
                        foreach (Flight flight in Flights)
                        {
                            if (flight.FlightId == flightId)
                                Console.WriteLine(flight.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Valeur de FlightId non valide.");
                    }
                    break;

                case "EstimatedDuration":
                    if (float.TryParse(filterValue, out float duration))
                    {
                        foreach (Flight flight in Flights)
                        {
                            if (flight.EstimatedDuration == duration)
                                Console.WriteLine(flight.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Valeur de durée non valide.");
                    }
                    break;

                default:
                    Console.WriteLine("Filtre non supporté.");
                    break;
            }
        }
//10
        public void ShowFlightDetails2(Plane plane)
        {
            var req = from f in Flights
                      where f.MyPlane == plane
                      select new { f.Destination, f.FlightDate };
                foreach (var f in req)
                Console.WriteLine(f);
        }

        //11
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            /*int nbr = 0;

           var  test = from f in Flights
                   where f.FlightDate > startDate && (f.FlightDate-startDate).TotalDays >7
                   select f;

            return test.Count();*/
            var test = Flights.Where(f => f.FlightDate > startDate && (f.FlightDate - startDate).TotalDays > 7);
            return test.Count();

        }
        //12

        public float DurationAverage(string destination)
        {
            /*int nbr = 0;

            var test = from f in Flights
                       where f.Destination == destination
                       select f.EstimatedDuration;

            return test.Average();*/
            var test = Flights.Where(f => f.Destination == destination).Select(f => f.EstimatedDuration);
            return test.Average();
        }



        //13

        public IEnumerable<Flight> OrderedDurationFlights()
        {
          

            /*var test = from f in Flights
                       orderby f.EstimatedDuration descending
                       select f;

            
          
           return test;*/
            
            return Flights.OrderByDescending(f => f.EstimatedDuration).Select(f=>f);
        }

        //14

       /* public IEnumerable<Passenger>  SeniorTravellers(Flight flight)
        {
            /*var test = from f in flight.Passengers
                       where f is Traveller
                       orderby (f.BirthDate-DateTime.Now).TotalDays
                       select f;

            return test.Take(3);
            //var test = flight.Passengers.Where(f => f is Traveller).OrderBy(f => (f.BirthDate - DateTime.Now).TotalDays).Select(p=>p);
            return test.Take(3);

        }*/


        public IEnumerable<IGrouping<string,Flight>>  DestinationGroupedFlights()
        {
           /* var test = from f in Flights
                       group f by f.Destination;
                      

            return  test ;*/
           var test = Flights.GroupBy(f => f.Destination);
            return test;
        }
        //16
       

        //17
       

        public void ShowFlightDetails(Plane plane)
        {
           var flightDetails = Flights
                .Where(f => f.MyPlane.Equals(plane))
                .Select(f => new { f.FlightDate, f.Destination });

            foreach (var detail in flightDetails)
            {
                Console.WriteLine($"Flight to {detail.Destination} on {detail.FlightDate}");
            }
         
        }

        // Method to calculate average flight duration for a destination
        public double DurationAverage2(string destination)
        {
            return Flights
                .Where(f => f.Destination == destination)
                .Average(f => f.EstimatedDuration);
        }


        
    }


    



}

