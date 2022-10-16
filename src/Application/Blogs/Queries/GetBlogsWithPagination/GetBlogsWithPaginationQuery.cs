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
public class GetBlogsWithPaginationQuery : IRequest<PaginatedList<BlogBreifDto>>
{
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetBlogsWithPaginationQueryHandler : IRequestHandler<GetBlogsWithPaginationQuery, PaginatedList<BlogBreifDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBlogsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<BlogBreifDto>> Handle(GetBlogsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Blogs
            .Where(x => x.Id == request.ListId)
            .OrderBy(x => x.Title)
            .ProjectTo<BlogBreifDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}

