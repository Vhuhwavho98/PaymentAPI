using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Domain.Entities
{
    public class PaymentDetail
    {
        [Key]
        public int PaymentDetailId { get; set; }
        public String CardOwnerName { get; set; }

        [Column(TypeName ="nvarchar(16)")]
        public String CardNumber { get; set; }

        //  mm/yy  e.g 05/26 which is may 2026
        [Column(TypeName ="nvarchar(5)")]
        public String ExpiryDate { get; set; }

        [Column(TypeName ="nvarchar(3)")]
        public String SecurityCode { get; set; }
    }
}
