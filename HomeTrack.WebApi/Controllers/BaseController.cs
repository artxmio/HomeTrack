using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HomeTrack.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BaseController : Controller
{
    private IMediator _mediator = null!;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()
        ?? throw new NullReferenceException("mediator was null.");

    internal Guid UserId => !User.Identity.IsAuthenticated ? Guid.Empty : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
}
