using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Application.PaymentDetail.Commands.DeletePaymentDetail
{
    public class DeletePaymentDetailCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
