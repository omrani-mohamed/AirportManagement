using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.services
{


    public static class PassengerExtension
    {
        public static void PassengerFullName(this Passenger passenger)
        {
            
            passenger.FullName.FirstName = char.ToUpper(passenger.FullName.FirstName[0]) + passenger.FullName.FirstName.Substring(1).ToLower();
            passenger.FullName.LastName = char.ToUpper(passenger.FullName.LastName[0]) + passenger.FullName.LastName.Substring(1).ToLower();


        }
    }
}
