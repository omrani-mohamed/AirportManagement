using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    [Owned]
    public class FullName
    {
        [MinLength(3, ErrorMessage = "longeur minimale 3 caracteres")]
        [MaxLength(25, ErrorMessage = "longeur maximale 25 caractere")]
        public String? FirstName { get; set; }

        [MinLength(3, ErrorMessage = "longeur minimale 3 caracteres")]
        [MaxLength(25, ErrorMessage = "longeur maximale 25 caractere")]
        public String? LastName { get; set; }

    }
}

