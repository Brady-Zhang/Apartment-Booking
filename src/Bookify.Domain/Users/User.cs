using EasyBook.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Users
{
    public sealed class User : Entity
    {
        private User(Guid Id, Email email, FirstName firtName, LastName lastname) : base(Id)
        {
            Email = email;
            FirstName = firtName;
            LastName = lastname;
        }

        public Email Email { get; private set; }
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }

        public static User Create(Guid Id, Email email, FirstName firstName, LastName lastname)
        {
            var user = new User(Guid.NewGuid(), email, firstName, lastname);
            return user;
        }
    }
}
