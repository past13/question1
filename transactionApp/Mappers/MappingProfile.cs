namespace transactioApp.Helper
{
    using AutoMapper;
    using Models.Dto;
    using Models.Xml;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TransactionItem, TransactionDto>();
            CreateMap<PaymentDetails, PaymentDetailsDto>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => decimal.Parse(src.Amount)));
        }
    }
}