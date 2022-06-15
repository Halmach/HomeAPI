using AutoMapper;
using HomeAPI.Configuration;
using HomeAPI.Contracts.Models.Home;

namespace HomeAPI
{
    /// <summary>
    /// Настройки маппинга всех сущностей приложения
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// В конструкторе настроим соответствие сущностей при маппинге
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Address, AddressInfo>();
            CreateMap<HomeOptions, InfoResponse>()
                .ForMember(m => m.AddressInfo,
                    opt => opt.MapFrom(src => src.Address));
        }
    }
}
