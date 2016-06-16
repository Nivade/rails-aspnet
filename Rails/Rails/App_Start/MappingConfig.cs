using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rails.Areas.Clean.Models;
using Rails.Areas.Remise.Models;
using Rails.Data;
using Rails.Models;
using Rails.Models.Domain;


namespace Rails.App_Start
{
    public static class MappingConfig
    {

        public static void RegisterMappings()
        {
            RailsDbContext db = new RailsDbContext();

            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<TramMaintenance, CleanQueueViewModel>()
                .ForMember(x => x.Number, opt => opt.MapFrom(y => y.Tram.Number))
                .ForMember(x => x.Description, opt => opt.MapFrom(y => y.Tram.TramType.Description))
                ;

                config.CreateMap<TramMaintenance, CleanFinishedViewModel>()
                .ForMember(x => x.Number, opt => opt.MapFrom(y => y.Tram.Number))
                .ForMember(x => x.Description, opt => opt.MapFrom(y => y.Tram.TramType.Description))
                .ForMember(x => x.Cleaner, opt => opt.MapFrom(y => y.User.FirstName + " " + y.User.LastName))
                ;

                config.CreateMap<TramMaintenance, CleanBusyViewModel>()
                .ForMember(x => x.Number, opt => opt.MapFrom(y => y.Tram.Number))
                .ForMember(x => x.Description, opt => opt.MapFrom(y => y.Tram.TramType.Description))
                .ForMember(x => x.Start, opt => opt.MapFrom(y => y.Start))
                .ForMember(x => x.Cleaner, opt => opt.MapFrom(y => y.User.FirstName + " " + y.User.LastName))
                ;

                config.CreateMap<Track, RemiseTrackModel>();

                config.CreateMap<Sector, RemiseSectorModel>().ForMember(x => x.Tram, opt => opt.MapFrom(y => y.Tram)).ForMember(x => x.TrackNumber, opt => opt.MapFrom(y => y.Track.Number)).ForMember(x => x.SectorNumber, opt => opt.MapFrom(y => y.Number)).ForMember(x => x.Blocked, opt => opt.MapFrom(y => y.Blocked));
            });
        }
    }
}
