using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecordWebApi
{
    public record NewContact(
    [Required] string FirstName,
    [Required] string LastName,
    [Required] int? Age
    );

    public record Contact(
    int Id,
    string FirstName,
    string LastName,
    int Age
    );
}
