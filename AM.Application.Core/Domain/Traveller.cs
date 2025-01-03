using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Application.Core.Domain
{
    public class Traveller:Passenger
    {
        public string HealthInformation { get; set; }
        public string Nationality { get; set; }

        public override string ToString()
        {
            return base.ToString() + "HealthInformation : " + this + HealthInformation + "Nationality : " + this.Nationality;

        }

        public override string PassengerType()
        {
            return base.PassengerType() + ", I am a Traveller";
        }


    }
}
