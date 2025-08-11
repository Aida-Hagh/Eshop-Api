using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Users.Addresses.GetList;

internal class GetUserAddressesListQueryHandler : IQueryHandler<GetUserAddressesListQuery, List<AddressDto>>
{
    private readonly DapperContext _dapperContext;

    public GetUserAddressesListQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<List<AddressDto>> Handle(GetUserAddressesListQuery request, CancellationToken cancellationToken)
    {
        var sql = $"Select * from {_dapperContext.UserAddresses} where UserId=@userId";
        using var context = _dapperContext.CreateConnection();
        var result = await context.QueryAsync<AddressDto>(sql, new { userId = request.UserId });
        return result.ToList();
    }
}
