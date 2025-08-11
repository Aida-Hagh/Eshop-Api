using Common.Application;
using Common.Application.Validation;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Http;
using Shop.Domain.UserAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.Edit
{
    public class EditUserCommand : IBaseCommand
    {
        public EditUserCommand(long userId, string name, string family,
            string phoneNumber, string email, IFormFile? avatarName, Gender gender)
        {
            UserId = userId;
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            AvatarName = avatarName;
            Gender = gender;
        }

        public long UserId { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public IFormFile? AvatarName { get; set; }
        public Gender Gender { get; private set; }
    }
}
