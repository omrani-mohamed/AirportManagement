using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public string Pilote { get; set; }
        public string AirlineLogo { get; set; }
        public string Destination { get; set; }
        public string Departure { get; set; }
        public int FlightId { get; set; }
        public DateTime FlightDate { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public float EstimatedDuration { get; set; }
        [ForeignKey("MyPlane")]
        public int PlaneId { get; set; }
        //[ForeignKey("PlaneId")]
        public virtual Plane MyPlane { get; set; }
        public virtual  ICollection<Ticket> Tickets { get; set; }

        public override string ToString()
        {
            return "Flight ID: " + this.FlightId + " Departure: " + this.Departure + " Destination: " + this.Destination+"flightDate"+this.FlightDate;
        }
    }
}
