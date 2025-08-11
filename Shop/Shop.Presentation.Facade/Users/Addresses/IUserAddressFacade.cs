using Common.Application;
using MediatR;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.DeleteAddress;
using Shop.Application.Users.EditAddress;
using Shop.Application.Users.SetActiveAddress;
using Shop.Query.Users.Addresses.GetById;
using Shop.Query.Users.Addresses.GetList;
using Shop.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Users.Addresses
{
    public interface IUserAddressFacade
    {
        Task<OperationResult> AddAddress(AddUserAddressCommand command);
        Task<OperationResult> EditAddress(EditUserAddressCommand command);
        Task<OperationResult> DeleteAddress(DeleteUserAddressCommand command);

        Task<AddressDto?> GetById(long userAddressId);
        Task<List<AddressDto>> GetList(long userId);
        Task<OperationResult> SetActiveAddress(SetActiveUserAddressCommand command);

    }



    internal class UserAddressFacade : IUserAddressFacade
    {
        private readonly IMediator _mediator;

        public UserAddressFacade(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<OperationResult> AddAddress(AddUserAddressCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditAddress(EditUserAddressCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DeleteAddress(DeleteUserAddressCommand command)
        {
            return await _mediator.Send(command);

        }

        public async Task<AddressDto?> GetById(long userAddressId)
        {
            return await _mediator.Send(new GetUserAddressByIdQuery(userAddressId));

        }

        public async Task<List<AddressDto>> GetList(long userId)
        {
            return await _mediator.Send(new GetUserAddressesListQuery(userId));
        }
        public async Task<OperationResult> SetActiveAddress(SetActiveUserAddressCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}