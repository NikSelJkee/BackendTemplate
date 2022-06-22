using AutoMapper;
using BackendTemplate.Application.Common.Mappings;
using BackendTemplate.Domain.Entities;

namespace BackendTemplate.Application.Games.Queries.GetGame
{
    public class GameDto : IMapFrom<Game>
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public string Descriptopn { get; set; } = null!;
        public int Genre { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public DateTime Release { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Game, GameDto>()
                .ForMember(p => p.Genre, opt => opt.MapFrom(s => (int)s.Genre))
                .ForMember(p => p.Descriptopn, opt => opt.MapFrom(s => s.Info.Description))
                .ForMember(p => p.Rating, opt => opt.MapFrom(s => s.Info.Rating))
                .ForMember(p => p.Release, opt => opt.MapFrom(s => s.Info.Release));
        }
    }
}
