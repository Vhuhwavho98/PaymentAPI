using MediatR;
using PaymentAPI.Application.PaymentDetail.Queries;
using PaymentAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Application.PaymentDetail.Commands.CreatePaymentDetail
{
    public class CreatePaymentDetailCommand : IRequest<PaymentDetailVm>
    {

        public String CardOwnerName { get; set; }

        public String CardNumber { get; set; }

        public String ExpiryDate { get; set; }

        public String SecurityCode { get; set; }
    }
}
