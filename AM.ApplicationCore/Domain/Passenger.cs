using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //public int Id { get; set; }
        [Display(Name = "Date of birth")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }

        [Key]
        [StringLength(7, ErrorMessage = "Passport number must be 7 characters.")]
        public string PassportNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }

        public FullName FullName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "TelNumber must contain exactly 8 digits.")]
        public string? TelNumber { get; set; }
        //public ICollection<Flight>? Flights { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public override string ToString()
        {
            return "FirstName :" + this.FullName.FirstName + " LastName : " + this.FullName.LastName + " BirthDate : " + this.BirthDate + " TelNumber : " + this.TelNumber;
        }

        //public bool CheckProfile(string firstName, string lastName)
        //{
        //    return this.FirstName.Equals(firstName) && this.LastName.Equals(lastName);
        //}

        //public bool CheckProfile(string firstName, string lastName, string email)
        //{
        //    return this.FirstName == firstName && this.LastName == lastName && this.EmailAddress == email;
        //}

        public bool CheckProfile(string firstName, string lastName, string email = null)
        {
            if (email != null)
            {
                return this.FullName.FirstName == firstName && this.FullName.LastName == lastName && this.EmailAddress == email;
            }
            else
            {
                return this.FullName.FirstName == firstName && this.FullName.LastName == lastName;
            }
        }

        public virtual string PassengerType()
        {
            return "I am a passenger";
        }

    }
}

