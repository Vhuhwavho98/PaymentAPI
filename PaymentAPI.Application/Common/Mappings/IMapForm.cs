using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Application.Common.Mappings
{
    public interface IMapForm<T>
    {
        void Mapping(Profile profile);
    }
}
