using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;
using MediatR;

namespace CleanArchitecture.Application.Blogs.Commands.CreateBlog;
public record CreateBlogCommand :IRequest<int>
{
    public string? Title { get; set; }
    public string? Body { get; set; }
    public DateTime CreationDate { get; set; }
}
public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateBlogCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var entity = new Blog
        {
            Body = request.Body,
            Title = request.Title,
            CreationDate = request.CreationDate
        };

        entity.AddDomainEvent(new BlogCreatedEvent(entity));

        _context.Blogs.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
