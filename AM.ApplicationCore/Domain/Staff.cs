using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff : Passenger
    {
        public DateTime EmploymentDate { get; set; }
        public string Function { get; set; }
        [DataType(DataType.Currency)]
        public float Salary { get; set; }
        public override string ToString()
        {
            return base.ToString()+" Employment date"+ this.EmploymentDate+" Function"+this.Function+"Salary "+this.Salary;
        }
        public override void PassengerType()
        {
            base.PassengerType();
           System.Console.WriteLine("I am a Staff Member");
        }
    }
}
