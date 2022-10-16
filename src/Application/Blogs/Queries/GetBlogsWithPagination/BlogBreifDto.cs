using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Blogs.Queries;
public class BlogBreifDto : IMapFrom<Blog>
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public DateTime CreationDate { get; set; }
}
