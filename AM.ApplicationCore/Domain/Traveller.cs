using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Traveller : Passenger
    {
        public string HealthInformation { get; set; }
        public string Nationality { get; set; }

        public override string ToString()
        {
            return base.ToString()+" health information "+this.HealthInformation+"nationality"+this.Nationality;
        }

        public override void PassengerType()
        {
            base.PassengerType();
            System.Console.WriteLine("I am a traveller");
        }

    }
    

}
