using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Blogs.Commands.DeleteBlog;
public record DeleteBlogCommand(int Id) : IRequest;
public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteBlogCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Blogs
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Blog), request.Id);
        }

        _context.Blogs.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}