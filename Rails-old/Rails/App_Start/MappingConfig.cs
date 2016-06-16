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

                config.CreateMap<Track, TrackIndexViewModel>();
                config.CreateMap<TramIndexViewModel, Track>();

                config.CreateMap<Track, SectorOptionsViewModel>();
                config.CreateMap<SectorOptionsViewModel, Track>();

                config.CreateMap<TramMaintenance, TramMaintenancePendingViewModel>().ForMember(x => x.Number, opt => opt.MapFrom(y => y.Tram.Number));
                config.CreateMap<TramMaintenancePendingViewModel, TramMaintenance>();

                config.CreateMap<TramMaintenance, TramMaintenanceSchedulePendingViewModel>()
                    .ForMember(x => x.SelectedStartDate, opt => opt.MapFrom(y => y.Start))
                    .ForMember(x => x.SelectedTechnician, opt => opt.MapFrom(y => y.UserId));



                //config.CreateMap<Tram, TramTransferViewModel>().

            });
        }
    }
}
