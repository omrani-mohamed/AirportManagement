using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType
    {
        Boeing,
        Airbus,
        
    }
    public class Plane
    {
        /*private int capacity;

        public int capacity
        {
            get { return myVar; }
            set { myVar = value; }
        }*/

        [Range(0, int.MaxValue)]
        public int capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        
        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }

        public virtual ICollection<Flight> Flights{get; set;}
        public override string ToString()
        {
            return "Plane ID: " + this.PlaneId + " Plane Type: " + this.PlaneType + " manufacture date: " + this.ManufactureDate;
        }
        public Plane (PlaneType pt, int capacity, DateTime date)
        {
            this.capacity = capacity;
            this.ManufactureDate = ManufactureDate;
            this.PlaneType = PlaneType;
        }
        public Plane()
        {

        }



    }
}
