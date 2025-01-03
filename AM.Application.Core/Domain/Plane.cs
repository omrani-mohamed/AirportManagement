using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Application.Core.Domain
{
    public enum PlaneType { Boing, Airbus };
    public class Plane
    {
		private int capacity;

        //public int Capacity
        //{
        //	get { return capacity; }
        //	set { capacity = value; }
        //}
        [Range(0, int.MaxValue, ErrorMessage = "Capacity must be a positive integer.")]
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
        public override string ToString()
        {
            return "Capacity:" + this.capacity + " ManufactureDate : " + this.ManufactureDate + " PlaneId : " + this.PlaneId + " PlaneType : " + this.PlaneType;
        }
        public Plane() {}

        public Plane (PlaneType pt, int capacity, DateTime date)
        {
            this.capacity = capacity;
            this.ManufactureDate = date;
            this.PlaneType = pt;

        }
    }
}
