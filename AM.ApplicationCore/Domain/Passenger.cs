using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.services;
namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //public int Id { get; set; }
        [Display(Name = "Date of bearth ")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Key, StringLength(7)]
        public string PassportNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        //[EmailAddress]
        public string EmailAdress { get; set; }
        
         public FullName FullName { get; set; }

        [RegularExpression(@"^(\d{8})$", ErrorMessage = "Invalid Phone number")]
        public string TelNumber { get; set; }
        public virtual  ICollection<Ticket> Tickets { get; set; }
        //public ICollection<Flight> Flights { get; set; }

        public override string ToString()
        {
            return "First Name"+this.FullName.FirstName+"Last Name"+this.FullName.LastName;
        }
        //10

        public bool CheckProfile(string firstName, string lastName)
        {
            return this.FullName.FirstName == firstName && this.FullName.LastName == lastName;
        }

     /*  public bool CheckProfile(string firstName, string lastName,String email)
        {
            return this.FirstName == firstName && this.LastName == lastName&&this.EmailAdress==email;
        }*/
        public bool CheckProfile(string firstName, string lastName, String email=null)
        {
            if(email == null)
            {
                return this.FullName.FirstName == firstName && this.FullName.LastName == lastName;
            }
            return this.FullName.FirstName == firstName && this.FullName.LastName == lastName && this.EmailAdress == email;
        }



        //11


        public virtual void PassengerType()
        {
            System.Console.WriteLine("I am a passenger");
        }


       
    }
}
