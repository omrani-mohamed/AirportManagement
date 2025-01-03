// See https://aka.ms/new-console-template for more information
using AM.Application.Core.Domain;
using AM.Application.Core.Services;
using AM.Infrastructure;

Console.WriteLine("Hello, 4DS10!");

// Initialize passenger1 with FullName
Passenger passenger1 = new Passenger() {
    PassportNumber = "1111",
    FullName = new FullName {FirstName = "foulen", LastName = "fleni" },
    BirthDate = DateTime.Now,
    TelNumber = "99999999",
};

Console.WriteLine(passenger1);

// Initialize staff1 with FullName
Staff staff1 = new Staff() {
    FullName = new FullName {FirstName = "wahed", LastName = "ben abd lwahd" },
    EmploymentDate = DateTime.Now,
};

Console.WriteLine(staff1);

Plane plane = new Plane
{
    Capacity = 250,
    ManufactureDate = new DateTime(2024, 07, 27),
    PlaneId = 007,
    PlaneType = PlaneType.Airbus
};

Console.WriteLine(plane);

Plane plane1 = new Plane(PlaneType.Airbus,300,new DateTime (2024,03,05));

//initialiseur d'objets
Plane plane2 = new Plane { PlaneType = PlaneType.Airbus };

Console.WriteLine(plane2);
Console.WriteLine(plane1);

Traveller traveller1 = new Traveller();

// Initialize passenger2 with FullName
Passenger passenger2 = new Passenger() {
    FullName = new FullName { FirstName = "Mohamed Amine", LastName = "Omrani" },
    EmailAddress = "omrani.mohamedamine@esprit.tn"
};
Console.WriteLine(passenger2.CheckProfile("Mohamed Amine","Omrani", "omrani.mohamedamine@esprit.tn"));

// Passenger type output
Console.WriteLine(passenger1.PassengerType()); 
Console.WriteLine(staff1.PassengerType());  
Console.WriteLine(traveller1.PassengerType());

// Initialize FlightMethods
FlightMethods flightMethods = new FlightMethods{
    Flights = TestData.listFlights
};

// Display list of flights
Console.WriteLine();
Console.WriteLine("Liste des vols:");
foreach (var flight in flightMethods.Flights)
{
    Console.WriteLine("Destination: "+
        flight.Destination+", " +
        "Date: "+flight.FlightDate+", "+
        " Durée estimée: "+flight.EstimatedDuration+" minutes");
}

// Flights to Paris
Console.WriteLine();
List<DateTime> datesForParis = flightMethods.GetFlightDates("Paris");
Console.WriteLine("Dates des vols pour Paris : ");
foreach (var date in datesForParis)
{
    Console.WriteLine(date);
}
Console.WriteLine();

Console.WriteLine("Vols vers Paris :");
List<Flight> parisFlights = flightMethods.GetFlights("Destination", "Paris");
foreach (var flight in parisFlights)
{
    Console.WriteLine("Destination: "+flight.Destination+", Date: "+flight.FlightDate);
}

Console.WriteLine();
Console.WriteLine("Vols avec une durée estimée de 105 minutes :");
List<Flight> durationFlights = flightMethods.GetFlights("EstimatedDuration", "105");
foreach (var flight in durationFlights)
{
    Console.WriteLine("Destination: "+flight.Destination+", Durée: "+flight.EstimatedDuration+" minutes, Date: "+flight.FlightDate);
}

Console.WriteLine();
Console.WriteLine("Vols avec une avion de type Boing :");
List<Flight> BoingPlaneFlights = flightMethods.GetFlights("MyPlane", "BoingPlane");
foreach (var flight in BoingPlaneFlights)
{
    Console.WriteLine("PlaneType: " + flight.MyPlane + ", Destination: " + flight.Destination);
}

Console.WriteLine("Les details de la vol dont l'avion est de type Airbus : ");
flightMethods.ShowFlightDetails(TestData.Airbusplane);

Console.WriteLine("avec delegue");
flightMethods.FlightDetailsDel(TestData.Airbusplane);

Console.WriteLine();
Console.WriteLine("Le nombre des vols programmées pendant la semaine qui commance par cette date '2022, 01, 01' : ");
Console.WriteLine(flightMethods.ProgrammedFlightNumber(new DateTime(2022, 01, 01)));

Console.WriteLine("la moyenne de durée estimées des vols d’une destination :'Madrid' : ");
Console.WriteLine(flightMethods.DurationAverage("Madrid"));

Console.WriteLine("avec le delegue");
Console.WriteLine(flightMethods.DurationAverageDel("Madrid"));

Console.WriteLine();
var orderedFlights = flightMethods.OrderedDurationFlights();
Console.WriteLine("Les details des vols ordonnés par durée estimée (ordre décroissant) : ");
foreach (var flight in orderedFlights)
{
    Console.WriteLine("Flight Date: "+flight.FlightDate+", Destination: "+flight.Destination+", Estimated Duration: "+flight.EstimatedDuration+" hours");
}

Console.WriteLine();
//var seniorTravellers = flightMethods.SeniorTravellers(TestData.flight1);

//Console.WriteLine();
//Console.WriteLine("Les 3 passagers de type Traveller les plus âgés : ");
//foreach (var traveller in seniorTravellers)
//{
//    Console.WriteLine("LastName: "+traveller.FullName.LastName + " FirstName: " + traveller.FullName.FirstName + ", Date de naissance: "+traveller.BirthDate);
//}

Console.WriteLine();
var groupedFlights = flightMethods.DestinationGroupedFlights();

Console.WriteLine();
Console.WriteLine(TestData.captain.FullName.FirstName + " " +  TestData.captain.FullName.LastName);

Console.WriteLine();
TestData.captain.PassengerFullName();
Console.WriteLine(TestData.captain.FullName.FirstName + " " + TestData.captain.FullName.LastName);


AMContext context = new AMContext();
//context.Flights.Add(TestData.flight4);
//context.SaveChanges();
//context.Passengers.Add(TestData.traveller1);
//context.SaveChanges();

Console.WriteLine();
Console.WriteLine(context.Flights.First().MyPlane.Capacity);