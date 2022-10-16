using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Events;

    public class BlogCreatedEvent : BaseEvent
    {
        public BlogCreatedEvent(Blog item)
        {
            Item = item;
        }

        public Blog Item { get; }
    }
