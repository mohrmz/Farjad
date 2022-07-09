using Microsoft.EntityFrameworkCore;
using Scorpion.Endpoints.WebApi.Extentions.DependencyInjection;
using Scorpion.Samples.Infrastructures.Data.Sql.Commands.Common;
using Scorpion.Samples.Infrastructures.Data.Sql.Queries.Common;
using Zamin.Extensions.DependencyInjection;

namespace Scorpion.Samples.Endpoints.WebAPI
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            string cnn = "Server=.; Initial Catalog=ScorpionSample; User Id=sa; Password=1qaz!QAZ";
            builder.Services.AddZaminParrotTranslator(c =>
            {
                c.ConnectionString = cnn;
                c.AutoCreateSqlTable = true;
                c.SchemaName = "dbo";
                c.TableName = "ParrotTranslations";
                c.ReloadDataIntervalInMinuts = 1;
            });

            builder.Services.AddZaminWebUserInfoService(true);

            builder.Services.AddZaminAutoMapperProfiles(option =>
            {
                option.AssmblyNamesForLoadProfiles = "Scorpion.Samples";
            });

            builder.Services.AddZaminMicrosoftSerializer();

            builder.Services.AddZaminInMemoryCaching();

            builder.Services.AddDbContext<SampleCommandDbContext>(c => c.UseSqlServer(cnn));
            builder.Services.AddDbContext<SampleQueryDbContext>(c => c.UseSqlServer(cnn));
            builder.Services.AddScorpionApiCore("Scorpion");
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseScorpionApiExceptionHandler();
            //app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwagger();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();


            return app;
        }
    }
}
