using System.Data.Entity;

namespace ChoiceCenium.Model
{
    public class Context : DbContext 
    {
        public Context() : base("ChoiceCeniumContext")
        {
            System.Data.Entity.Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<Context>());
        }

        public DbSet<Hotelinfo> HotelInfos { get; set; }
        public DbSet<KjedeInfo> KjedeInfos { get; set; }
    }
}
