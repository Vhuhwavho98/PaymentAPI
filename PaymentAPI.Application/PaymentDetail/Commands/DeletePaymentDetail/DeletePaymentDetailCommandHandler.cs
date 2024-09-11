using MediatR;
using PaymentAPI.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Application.PaymentDetail.Commands.DeletePaymentDetail
{
    public class DeletePaymentDetailCommandHandler : IRequestHandler<DeletePaymentDetailCommand, int>
    {
        private readonly IPaymentRepository _paymentRepository;
        public DeletePaymentDetailCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository; 
        }
        public Task<int> Handle(DeletePaymentDetailCommand request, CancellationToken cancellationToken)
        {
            return _paymentRepository.DeleteAsync(request.Id);
        }
    }
}
