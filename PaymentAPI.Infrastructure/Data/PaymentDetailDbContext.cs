using Microsoft.EntityFrameworkCore;
using PaymentAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Infrastructure.Data
{
    public class PaymentDetailDbContext : DbContext
    {
        public PaymentDetailDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PaymentDetail> PaymentDetails { get; set; }
    }
}
