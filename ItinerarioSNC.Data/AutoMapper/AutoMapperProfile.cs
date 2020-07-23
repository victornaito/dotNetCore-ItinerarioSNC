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
                    cfg.CreateMap<PessoaFisicaDto, PessoaFisica>();
                    cfg.CreateMap<AnaliseAgendamentoDto, AnaliseAgendamento>();
                });

        public AutoMapperProfile(IMapper iMapper)
        {
            this.mapper = iMapper;

        }

        public static BaseEntity Map<BaseDto, BaseEntity>(BaseDto source)
        {
            dynamic mapper = Config.CreateMapper().Map<BaseDto, BaseEntity>(source);
            return mapper;
        }
    }
}
