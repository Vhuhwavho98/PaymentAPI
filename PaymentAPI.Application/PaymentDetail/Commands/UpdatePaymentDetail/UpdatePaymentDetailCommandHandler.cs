using AutoMapper;
using MediatR;
using PaymentAPI.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Application.PaymentDetail.Commands.UpdatePaymentDetail
{
    public class UpdatePaymentDetailCommandHandler : IRequestHandler<UpdatePaymentDetailCommand, int>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        public UpdatePaymentDetailCommandHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository; 
            
        }
        public async Task<int> Handle(UpdatePaymentDetailCommand request, CancellationToken cancellationToken)
        {
            var updatedData = new Domain.Entities.PaymentDetail()
            {
                CardNumber = request.CardNumber,
                CardOwnerName = request.CardOwnerName,
                //PaymentDetailId = request.PaymentDetailId,
                ExpiryDate = request.ExpiryDate,
                SecurityCode = request.SecurityCode
            };

            return await _paymentRepository.UpdateAsync(updatedData,request.PaymentDetailId);
           
        }
    }
}
