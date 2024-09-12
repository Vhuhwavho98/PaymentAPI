using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Application.PaymentDetail.Commands.CreatePaymentDetail;
using PaymentAPI.Application.PaymentDetail.Commands.DeletePaymentDetail;
using PaymentAPI.Application.PaymentDetail.Commands.UpdatePaymentDetail;
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePaymentDetail(UpdatePaymentDetailCommand updatePaymentDetailCommand, int id)
        {
            if (id == updatePaymentDetailCommand.PaymentDetailId)
            {
                await Mediator.Send(updatePaymentDetailCommand);
                return Ok();
            }
            return BadRequest();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentDetail(DeletePaymentDetailCommand deletePaymentDetailCommand, int id)
        {
            if (id == deletePaymentDetailCommand.Id)
            {
                await Mediator.Send(deletePaymentDetailCommand);
                return Ok();
            }
            return BadRequest();
        }
    }

}
