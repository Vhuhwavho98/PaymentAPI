using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentAPI.Application.Common.Mappings;
using AutoMapper;
using PaymentAPI.Domain.Entities;

namespace PaymentAPI.Application.PaymentDetail.Queries
{
    public class PaymentDetailVm : IMapForm<Domain.Entities.PaymentDetail>
    {
        public int Id { get; set; }

        public int PaymentDetailId { get; set; }
        public String CardOwnerName { get; set; }

        public String CardNumber { get; set; }

        public String ExpiryDate { get; set; }

        public String SecurityCode { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.PaymentDetail, PaymentDetailVm>().ReverseMap();
        }
    }
}
