using AutoMapper;
using filed.Domain.Models;
using filed.Resources;

namespace filed.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<PaymentResource, Payment>();
        }
    }
}