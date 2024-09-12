using AutoMapper;
using MediatR;
using PaymentAPI.Application.PaymentDetail.Queries;
using PaymentAPI.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Application.PaymentDetail.Commands.CreatePaymentDetail
{
    public class CreatePaymentDetailCommandHandler : IRequestHandler<CreatePaymentDetailCommand, PaymentDetailVm>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        public CreatePaymentDetailCommandHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {

            _paymentRepository = paymentRepository;
            _mapper = mapper;

        }
        public async Task<PaymentDetailVm> Handle(CreatePaymentDetailCommand request, CancellationToken cancellationToken)
        {

            var paymentDetail = new Domain.Entities.PaymentDetail()
            {
                CardNumber = request.CardNumber,
                CardOwnerName = request.CardOwnerName,
                ExpiryDate = request.ExpiryDate,
                //PaymentDetailId = request.PaymentDetailId,
                SecurityCode = request.SecurityCode,    

            };

            var results = await _paymentRepository.CreateAsync(paymentDetail);
            return _mapper.Map<PaymentDetailVm>(results);   
        }
    }



}
