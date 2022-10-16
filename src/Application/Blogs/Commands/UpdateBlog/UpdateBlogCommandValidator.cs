using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CleanArchitecture.Application.Blogs.Commands.UpdateBlog;
public class UpdateBlogCommandValidator : AbstractValidator<UpdateBlogCommand>
{
    public UpdateBlogCommandValidator()
    {
          RuleFor(v => v.Title)
           .MaximumLength(100)
           .NotEmpty();

          RuleFor(v => v.Body)
            .NotEmpty()
            .MaximumLength(500);
    }
}
