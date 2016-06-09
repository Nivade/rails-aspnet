using Rails.Models;
using Rails.Models.View;


namespace Rails
{
    public static class MappingConfig
    {

        public static void RegisterMaps()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            AutoMapper.Mapper.Initialize(config =>
            {
                
                config.CreateMap<Tram, TramSettingsViewModel>();
                config.CreateMap<TramSettingsViewModel, Tram>()
                    .ForMember(x => x.TramTypeId, opt => opt.MapFrom(y => y.SelectedTramTypeId))
                    .ForMember(x => x.DepotId, opt => opt.MapFrom(y => y.SelectedDepotId));

                config.CreateMap<Tram, TramIndexViewModel>();
                config.CreateMap<TramIndexViewModel, Tram>();

                //config.CreateMap<Tram, TramTransferViewModel>().

            });
        }
    }
}
