using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.services;
using AM.Infrastructure;

Console.WriteLine("Hello, World!");
Plane plane = new Plane();
plane.capacity = 200;
plane.ManufactureDate = new DateTime(1995, 12, 26);
plane.PlaneId = 12345;
plane.PlaneType = PlaneType.Airbus;
//Console.WriteLine(plane.ToString());
// Plane plane1 = new Plane (200, new DateTime(2005, 05, 25),PlaneType.Boing);
//Console.WriteLine(plane1.ToString());



Plane plane2 = new Plane
{
    PlaneType = PlaneType.Airbus,
    capacity = 125,
    PlaneId = 12345678,
    ManufactureDate = new DateTime(1875, 12, 12),
};

//Console.WriteLine(plane2.ToString());



Passenger passenger = new Passenger()
{
    FullName = new FullName { FirstName = "Rayen", LastName = "Jlassi" },
    EmailAdress = "Rayen.jlassi@esprit.tn"
};
/*Console.WriteLine(passenger.ToString());    
//
*/
passenger.PassengerType();

Console.WriteLine();
Staff staff = new Staff();
staff.PassengerType();

Console.WriteLine();

// Creer un voyageur
Traveller traveller = new Traveller { };
traveller.PassengerType();

Flightmethods flightMethods = new Flightmethods();
flightMethods.Flights = TestData.listFlights;
Console.WriteLine(flightMethods.Flights.ToString());

foreach (var item in flightMethods.GetFlightDates("Paris"))
{
    Console.WriteLine(item.ToString());
}

flightMethods.GetFlights("Destination", "Paris");
flightMethods.ShowFlightDetails(TestData.Airbusplane);



Console.WriteLine("==========Destination Duration Average ===============");
Console.WriteLine(flightMethods.DurationAverage("Paris"));

Console.WriteLine("====ordered Duration Average====");


foreach (var item in flightMethods.OrderedDurationFlights())
{
    Console.WriteLine(item.ToString());
}


/*Console.WriteLine("===Senior Traveller======");
foreach (var item in flightMethods.SeniorTravellers(TestData.flight1))
{

    Console.WriteLine(item);
}
*/
// Ajouter des vols à la liste pour les tests
flightMethods.Flights.Add(new Flight { MyPlane = new Plane { PlaneId = 1 }, Destination = "Paris", FlightDate = new DateTime(2024, 5, 3), EstimatedDuration = 2.5f });
flightMethods.Flights.Add(new Flight { MyPlane = new Plane { PlaneId = 1 }, Destination = "Madrid", FlightDate = new DateTime(2024, 5, 5), EstimatedDuration = 1.5f });
flightMethods.Flights.Add(new Flight { MyPlane = new Plane { PlaneId = 2 }, Destination = "Paris", FlightDate = new DateTime(2024, 5, 10), EstimatedDuration = 3.0f });

Console.WriteLine("==========Destination Duration Average ===============");
Console.WriteLine(flightMethods.DurationAverage("Paris"));
Console.WriteLine(flightMethods.DurationAverageDel("Paris"));
Console.WriteLine("===Flight details======");
flightMethods.FlightDetailsDel(TestData.BoingPlane);
flightMethods.ShowFlightDetails2(TestData.BoingPlane);

TestData.traveller1.PassengerFullName();
Console.WriteLine(TestData.traveller1.ToString());

AMContextcs context = new AMContextcs();

//context.Flights.Add(TestData.flight2);
//context.SaveChanges();

//context.Passengers.Add(TestData.traveller1);
//context.SaveChanges();
//context.Passengers.Add(TestData.traveller2);
//context.SaveChanges();
//context.Flights.Add(TestData.flight2);
//context.SaveChanges();
//Console.WriteLine(context.Flights.Last().MyPlane.capacity);

// Simulation d'implémentation des services spécifiques
IUnitOfWork unitOfWork = new UnitOfWork(); // Instanciez votre unité de travail appropriée
IServicePlane servicePlane = new ServicePlane(unitOfWork);
IServiceFlight serviceFlight = new ServiceFlight(unitOfWork);

Console.WriteLine("\n===== Tests des méthodes spécifiques =====");

// 1. Retourner les voyageurs d’un avion donné
Console.WriteLine("\n1. Liste des voyageurs pour un avion donné:");
Plane plane1 = new Plane { PlaneId = 1, PlaneType = PlaneType.Airbus, ManufactureDate = new DateTime(2010, 6, 20), capacity = 150 };
var passengers = servicePlane.GetPassengers(plane1);
foreach (var p in passengers)
{
    Console.WriteLine($"- {p.FullName}");
}

// 2. Retourner les vols ordonnés par date de départ des n derniers avions
int nLastPlanes = 3;
Console.WriteLine("\n2. Vols ordonnés par date de départ:");
var orderedFlights = servicePlane.GetFlights(nLastPlanes);
foreach (var flight in orderedFlights)
{
    Console.WriteLine($"Vol {flight.FlightId}, Départ: {flight.FlightDate}");
}

// 3. Vérifier si on peut réserver n places pour un vol donné
// Flight flightToCheck = new Flight { FlightId = 101, Capacity = 200, ReservedSeats = 150 };
int seatsToReserve = 30;
Console.WriteLine("\n3. Vérification de réservation:");
//bool canReserve = serviceFlight.IsFlighths(seatsToReserve, flightToCheck);
//Console.WriteLine($"Peut-on réserver {seatsToReserve} places? {canReserve}");

// 4. Supprimer tous les avions de plus de 10 ans
Console.WriteLine("\n4. Suppression des avions de plus de 10 ans...");
servicePlane.DeleteOldPlanes();
Console.WriteLine("Les avions de plus de 10 ans ont été supprimés.");

// 5. Retourner la liste des staffs d’un vol donné
int flightId = 101;
Console.WriteLine("\n5. Liste des staffs pour un vol donné:");
var staffList = serviceFlight.GetStaffs(flightId);
foreach (var s in staffList)
{
    Console.WriteLine($"- {s.FullName}");
}



