using CleanArchitecture.Application.Blogs.Commands.CreateBlog;
using CleanArchitecture.Application.Blogs.Commands.DeleteBlog;
using CleanArchitecture.Application.Blogs.Commands.UpdateBlog;
using CleanArchitecture.Application.Blogs.Queries;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Security;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;
[Authorize]
public class BlogController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<BlogBreifDto>>> GetBlogsWithPagination([FromQuery] GetBlogsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateBlogCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateBlogCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteBlogCommand(id));

        return NoContent();
    }
}
