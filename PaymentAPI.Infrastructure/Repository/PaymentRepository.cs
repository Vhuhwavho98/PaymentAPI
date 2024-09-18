using Microsoft.EntityFrameworkCore;
using PaymentAPI.Domain.Entities;
using PaymentAPI.Domain.IRepository;
using PaymentAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Infrastructure.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentDetailDbContext _paymentDetailDbContext;
        public PaymentRepository(PaymentDetailDbContext paymentDetailDbContext)
        {
            _paymentDetailDbContext = paymentDetailDbContext;
        }
        public async Task<PaymentDetail> CreateAsync(PaymentDetail paymentDetail)
        {
            await _paymentDetailDbContext.AddAsync(paymentDetail);   
            await _paymentDetailDbContext.SaveChangesAsync();
            return paymentDetail;
        }

        public async Task<int> DeleteAsync(int id)
        {
            await _paymentDetailDbContext.PaymentDetails.Where(model => model.PaymentDetailId == id).ExecuteDeleteAsync();
            return 0;
        }

        public async Task<IEnumerable<PaymentDetail>> GetAllAsync()
        {
            return await _paymentDetailDbContext.PaymentDetails.ToListAsync();
        }

        public async Task<PaymentDetail> GetByIdAsync(int id)
        {
            return await _paymentDetailDbContext.PaymentDetails.Where(model => model.PaymentDetailId == id).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateAsync(PaymentDetail paymentDetail, int id)
        {
            await _paymentDetailDbContext.PaymentDetails.Where(model => model.PaymentDetailId == id).ExecuteUpdateAsync(setters =>
           setters.SetProperty(m => m.CardOwnerName, paymentDetail.CardOwnerName)
           .SetProperty(m => m.CardNumber, paymentDetail.CardNumber)
           .SetProperty(m => m.SecurityCode, paymentDetail.SecurityCode)
           .SetProperty(m => m.ExpiryDate, paymentDetail.ExpiryDate));
            return 0;
        }
    }
}
