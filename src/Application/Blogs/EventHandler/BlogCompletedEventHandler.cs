using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Blogs.EventHandler;
public class BlogCompletedEventHandler : INotificationHandler<BlogCompletedEvent>
{
    private readonly ILogger<BlogCompletedEvent> _logger;
    public BlogCompletedEventHandler(ILogger<BlogCompletedEvent> logger)
    {
        _logger = logger;
    }
    public Task Handle(BlogCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
