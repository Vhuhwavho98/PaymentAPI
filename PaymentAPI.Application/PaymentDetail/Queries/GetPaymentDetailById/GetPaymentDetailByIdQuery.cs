using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Application.PaymentDetail.Queries.GetPaymentDetailById
{
    public class GetPaymentDetailByIdQuery :IRequest<PaymentDetailVm>
    {
        public  int PaymentDetailId { get; set; }
    }
}
