using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Rails.Data;
using Rails.Models.Domain;
using Rails.Models.Domain.Enums;


namespace Rails.Services
{

    public interface ITramService
    {
        IEnumerable<Tram> GetEnRoute();

        IEnumerable<Tram> GetDirty();

        TramState GetState(int number);

    }



    public interface ISectorService
    {

        bool Block(int number);

        bool Unblock(int number);

    }



    public class SectorService : ISectorService
    {

        public RailsDbContext Context { get; private set; } = new RailsDbContext();


        public bool Block(int number)
        {
            Sector sector = Context.Sectors.FirstOrDefault(x => x.Number == number);
            if (sector == null)
                return false;

            Connection connection = Context.Connections.FirstOrDefault(x => x.SectorFromId == sector.Id);
            if (connection != null)
            {
                Sector connectedSector = connection.SectorTo;
                Block(connectedSector.Number);
            }

            sector.Blocked = true;
            sector.TramId = null;
            Context.Entry(sector).State = EntityState.Modified;
            Context.SaveChanges();

            return true;
        }



        public bool Unblock(int number)
        {
            Sector sector = Context.Sectors.FirstOrDefault(x => x.Number == number);
            if (sector == null)
                return false;

            sector.Blocked = false;
            Context.Entry(sector).State = EntityState.Modified;
            Context.SaveChanges();

            return true;
        }

    }



    public class TramService
    {

        public  RailsDbContext Context { get; private set; } = new RailsDbContext();

    }

}