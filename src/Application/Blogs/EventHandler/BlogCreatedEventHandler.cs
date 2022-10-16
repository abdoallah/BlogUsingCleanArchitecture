using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Events;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Blogs.EventHandler;
public class BlogCreatedEventHandler
{
    private readonly ILogger<BlogCreatedEvent> _logger;

    public BlogCreatedEventHandler(ILogger<BlogCreatedEvent> logger)
    {
        _logger = logger;
    }

    public Task Handle(BlogCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
