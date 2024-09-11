using AutoMapper;
using MediatR;
using PaymentAPI.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Application.PaymentDetail.Queries.GetPaymentDetailById
{
    public class GetPaymentDetailByIdQueryHandler : IRequestHandler<GetPaymentDetailByIdQuery, PaymentDetailVm>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        public GetPaymentDetailByIdQueryHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
            
        }
        public async Task<PaymentDetailVm> Handle(GetPaymentDetailByIdQuery request, CancellationToken cancellationToken)
        {
            var paymentDetail = await _paymentRepository.GetByIdAsync(request.PaymentDetailId);
            return _mapper.Map<PaymentDetailVm>(paymentDetail);
        }
    }
}
