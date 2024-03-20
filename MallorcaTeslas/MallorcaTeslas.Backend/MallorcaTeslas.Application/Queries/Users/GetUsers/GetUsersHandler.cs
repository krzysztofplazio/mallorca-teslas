using AutoMapper;
using MallorcaTeslas.Application.Dtos.Users;
using MallorcaTeslas.Core.Dtos.Paginations;
using MallorcaTeslas.Core.Repositories.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Application.Queries.Users.GetUsers;

public class GetUsersHandler(IUsersRepository usersRepository, IMapper mapper) : IRequestHandler<GetUsersQuery, PagedItems<UserDto>>
{
    private readonly IUsersRepository _usersRepository = usersRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<PagedItems<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _usersRepository.GetUsers(request.PageNumber, request.PageSize, cancellationToken).ConfigureAwait(false);
        return _mapper.Map<PagedItems<UserDto>>(users);
    }
}
