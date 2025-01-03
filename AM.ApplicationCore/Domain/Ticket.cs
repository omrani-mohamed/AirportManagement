using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    [PrimaryKey(nameof(PassengerFK), nameof(FlightFK))]
    public class Ticket
    {
        public double Prix { get; set; }
        public int Siege { get; set; }
        public bool VIP { get; set; }
        //[Key,Column(Order = 1)]
        [ForeignKey("MyPassenger")]
        public string PassengerFK { get; set; }
        //[Key,Column(Order =0)]
        [ForeignKey("MyFlight")]
        public int FlightFK { get; set; }

        public virtual Passenger MyPassenger { get; set; }
        public virtual Flight MyFlight { get; set; }


    }
}
