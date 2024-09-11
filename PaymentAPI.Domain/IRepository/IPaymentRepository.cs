using PaymentAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Domain.IRepository
{
    public interface IPaymentRepository
    {

        Task<IEnumerable<PaymentDetail>> GetAllAsync();
        Task<PaymentDetail> GetByIdAsync(int id);
        Task<PaymentDetail> CreateAsync(PaymentDetail paymentDetail);
        Task<int> UpdateAsync(PaymentDetail paymentDetail,int id);
        Task<int> DeleteAsync(int id);
    }
}
