using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Application.PaymentDetail.Queries.GetAllPaymentDetail
{
    public class GetAllPaymentDetailQuery :IRequest<List<PaymentDetailVm>>
    {
    }
}
