using System.Text.Json.Serialization;

namespace OsmanliMakina_N_Tier
{
    public static class ServicesCollectionExtentions
    {
        public static void AddApiServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllersWithViews().AddJsonOptions(x =>
x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        }
    }
}
