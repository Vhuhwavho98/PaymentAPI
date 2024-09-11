using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private ISender _mediator;

        protected ISender Mediator => _mediator ?? HttpContext.RequestServices.GetRequiredService<ISender>();   
    }
}
