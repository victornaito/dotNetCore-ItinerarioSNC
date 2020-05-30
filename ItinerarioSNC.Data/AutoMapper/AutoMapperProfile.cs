using AutoMapper;
using ItinerarioSNC.Domain.Dtos;
using ItinerarioSNC.Domain.Entities;

namespace ItinerarioSNC.Infra.Data.AutoMapper
{
    public class AutoMapperProfile
    {
        public readonly IMapper mapper;

        private static MapperConfiguration Config =

                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PessoaFisica, PessoaFisicaDto>();
                });

        public AutoMapperProfile(IMapper iMapper)
        {
            this.mapper = iMapper;

        }

        public static BaseEntity Map<BaseDto, BaseEntity>(BaseDto source)
        {
            return Config.CreateMapper().Map<BaseDto, BaseEntity>(source);
        }
    }
}
