using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Blogs.Commands.UpdateBlog;
public record UpdateBlogCommand : IRequest
{
    public int Id { get; init; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public DateTime CreationDate { get; set; }
}
public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateBlogCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Blogs
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Blog), request.Id);
        }

        entity.Title = request.Title;
        entity.Body = request.Body;
        entity.CreationDate = request.CreationDate;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}