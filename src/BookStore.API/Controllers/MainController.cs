using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

[ApiController]
// [EnableCors("AllowOrigin")]
public abstract class MainController : ControllerBase
{
}