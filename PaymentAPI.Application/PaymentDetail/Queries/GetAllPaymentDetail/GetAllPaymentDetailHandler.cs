using AutoMapper;
using MediatR;
using PaymentAPI.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Application.PaymentDetail.Queries.GetAllPaymentDetail
{
    public class GetAllPaymentDetailHandler : IRequestHandler<GetAllPaymentDetailQuery, List<PaymentDetailVm>>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        public GetAllPaymentDetailHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }
        public async Task<List<PaymentDetailVm>> Handle(GetAllPaymentDetailQuery request, CancellationToken cancellationToken)
        {
            var paymentDetails = await _paymentRepository.GetAllAsync();
            return _mapper.Map<List<PaymentDetailVm>>(paymentDetails);
        }
    }
}
