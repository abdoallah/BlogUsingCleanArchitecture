using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using MediatR;

namespace CleanArchitecture.Application.Blogs.Queries;
public class GetBlogsWithPaginationQuery : IRequest<List<BlogBreifDto>>
{
 
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetBlogsWithPaginationQueryHandler : IRequestHandler<GetBlogsWithPaginationQuery, List<BlogBreifDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBlogsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<BlogBreifDto>> Handle(GetBlogsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return  _context.Blogs
            .OrderBy(x => x.Title)
            .ProjectTo<BlogBreifDto>(_mapper.ConfigurationProvider).ToList();
            
    }
}

