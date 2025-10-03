using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBook.Domain.Apartments
{
    public record Address(
        string Country,
        string State,
        string City,
        string ZipCode,
        string Street);
}
