using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Application.PaymentDetail.Commands.CreatePaymentDetail;
using PaymentAPI.Application.PaymentDetail.Queries.GetAllPaymentDetail;
using PaymentAPI.Application.PaymentDetail.Queries.GetPaymentDetailById;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetAllPaymentDetails()
        {
            var paymentsDetails = await Mediator.Send(new GetAllPaymentDetailQuery());  

            if(paymentsDetails == null)
            {
                return NotFound();
            }

            return Ok(paymentsDetails); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentDetailById(int id)
        {
            var paymentDetail = await Mediator.Send(new GetPaymentDetailByIdQuery() { PaymentDetailId= id});

            if(paymentDetail == null)
            {
                return NotFound(id);
            }
            return Ok(paymentDetail);

        }

        [HttpPost]
        public async Task<IActionResult> CreatePaymentDetail(CreatePaymentDetailCommand createPaymentDetailCommand)
        {
            await Mediator.Send(createPaymentDetailCommand);
            return Ok(CreatedAtAction(nameof(GetPaymentDetailById), createPaymentDetailCommand));
        }
    }

}
