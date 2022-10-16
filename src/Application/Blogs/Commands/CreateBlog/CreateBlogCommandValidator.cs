using CleanArchitecture.Application.Blogs.Commands.CreateBlog;
using FluentValidation;

namespace CleanArchitecture.Application.Blogs.Commands.CreateTodoItem;

public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
{
    public CreateBlogCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(100)
            .NotEmpty();

        RuleFor(v => v.Body)
            .NotEmpty()
            .MaximumLength(500);
    }
}
