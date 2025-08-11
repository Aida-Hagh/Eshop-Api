using Common.Application;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.EditAddress
{
    public class EditUserAddressCommand : IBaseCommand
    {
        public EditUserAddressCommand(long userId, string province, string city, string postalCode,
    string postalAddress, PhoneNumber phoneNumber, string name, string family,long id, string nationalCode)
        {
            UserId = userId;
            Province = province;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            Name = name;
            Family = family;
            Id = id;
            NationalCode = nationalCode;
        }

        public long Id { get; private set; }
        public long UserId { get;  set; }
        public string Province { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string NationalCode { get; private set; }
    }
}
