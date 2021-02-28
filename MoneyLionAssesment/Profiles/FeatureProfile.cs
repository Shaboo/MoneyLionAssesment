using AutoMapper;
using MoneyLionAssesment.DTO.Feature;
using MoneyLionAssesment.Models;

namespace MoneyLionAssesment.Profiles
{
    public class FeatureProfile : Profile
    {
        public FeatureProfile()
        {
            CreateMap<Feature, FeatureReadDTO>();
            CreateMap<FeatureCreateDTO, Feature>();
        }
    }
}
