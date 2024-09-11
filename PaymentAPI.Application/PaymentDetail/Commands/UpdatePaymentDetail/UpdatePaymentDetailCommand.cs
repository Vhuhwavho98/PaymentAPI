using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Application.PaymentDetail.Commands.UpdatePaymentDetail
{
    public class UpdatePaymentDetailCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int PaymentDetailId { get; set; }
        public String CardOwnerName { get; set; }

        public String CardNumber { get; set; }

        public String ExpiryDate { get; set; }

        public String SecurityCode { get; set; }

    }
}
